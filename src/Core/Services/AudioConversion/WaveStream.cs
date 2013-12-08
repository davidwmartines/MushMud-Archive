﻿//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  This material may not be duplicated in whole or in part, except for 
//  personal use, without the express written consent of the author. 
//
//  Email:  ianier@hotmail.com
//
//  Copyright (C) 1999-2003 Ianier Munoz. All Rights Reserved.

/*
 * Modified ReadHeader to work with various unknown header chunks
 * before reaching the "frmt " chunk - DM.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace MusicCompany.Core.Services.AudioConversion
{
	public enum WaveFormats
	{
		Pcm = 1,
		Float = 3
	}

	[StructLayout(LayoutKind.Sequential)]
	public class WaveFormat
	{
		public short wFormatTag;
		public short nChannels;
		public int nSamplesPerSec;
		public int nAvgBytesPerSec;
		public short nBlockAlign;
		public short wBitsPerSample;
		public short cbSize;

		public WaveFormat(int rate, int bits, int channels)
		{
			wFormatTag = (short)WaveFormats.Pcm;
			nChannels = (short)channels;
			nSamplesPerSec = rate;
			wBitsPerSample = (short)bits;
			cbSize = 0;

			nBlockAlign = (short)(channels * (bits / 8));
			nAvgBytesPerSec = nSamplesPerSec * nBlockAlign;
		}
	}
	
	
	public class WaveStream : Stream, IDisposable
	{
		private Stream m_Stream;
		private long m_DataPos;
		private long m_Length;

		private WaveFormat m_Format;

		public WaveFormat Format
		{
			get { return m_Format; }
		}

		private string ReadChunk(BinaryReader reader)
		{
			byte[] ch = new byte[4];
			reader.Read(ch, 0, ch.Length);
			string chunk = System.Text.Encoding.ASCII.GetString(ch);
			return chunk;
		}

		private void ReadHeader()
		{
			BinaryReader Reader = new BinaryReader(m_Stream);

			string chunk = ReadChunk(Reader);
			if ( chunk != "RIFF" )
				throw new Exception("Expected chunk to be RIFF but was " + chunk);

			Reader.ReadInt32(); // File length minus first 8 bytes of RIFF description, we don't use it

			chunk = ReadChunk(Reader);
			if ( chunk != "WAVE" )
				throw new Exception("Exptected chunk to be WAVE but was " + chunk);

			//read chunks until we get to fmt
			while (ReadChunk(Reader) != "fmt ")
				;
			
			int FormatLength = Reader.ReadInt32();
      if ( FormatLength < 16) // bad format chunk length
				throw new Exception("FormatLength < 16");

			m_Format = new WaveFormat(22050, 16, 2); // initialize to any format
			m_Format.wFormatTag = Reader.ReadInt16();
			m_Format.nChannels = Reader.ReadInt16();
			m_Format.nSamplesPerSec = Reader.ReadInt32();
			m_Format.nAvgBytesPerSec = Reader.ReadInt32();
			m_Format.nBlockAlign = Reader.ReadInt16();
			m_Format.wBitsPerSample = Reader.ReadInt16(); 
      if ( FormatLength > 16)
      {
        m_Stream.Position += (FormatLength-16);
      }
			//TODO: skip all the crap up until "data" - other header info is messing this up...

			// assume the data chunk is aligned
			while(m_Stream.Position < m_Stream.Length && ReadChunk(Reader) != "data")
				;

			if ( m_Stream.Position >= m_Stream.Length )
				throw new Exception("m_Stream.Position >= m_Stream.Length");

			m_Length = Reader.ReadInt32();
			m_DataPos = m_Stream.Position;

			Position = 0;
		}

		public WaveStream(string fileName) : this(new FileStream(fileName, FileMode.Open))
		{
		}
		public WaveStream(Stream S)
		{
			m_Stream = S;
			ReadHeader();
		}
		~WaveStream()
		{
			Dispose();
		}
		public new void Dispose()
		{
			if (m_Stream != null)
				m_Stream.Close();
			GC.SuppressFinalize(this);
		}

		public override bool CanRead
		{
			get { return true; }
		}
		public override bool CanSeek
		{
			get { return true; }
		}
		public override bool CanWrite
		{
			get { return false; }
		}
		public override long Length
		{
			get { return m_Length; }
		}
		public override long Position
		{
			get { return m_Stream.Position - m_DataPos; }
			set { Seek(value, SeekOrigin.Begin); }
		}
		public override void Close()
		{
			Dispose();
		}
		public override void Flush()
		{
		}
		public override void SetLength(long len)
		{
			throw new InvalidOperationException();
		}
		public override long Seek(long pos, SeekOrigin o)
		{
			switch(o)
			{
				case SeekOrigin.Begin:
					m_Stream.Position = pos + m_DataPos;
					break;
				case SeekOrigin.Current:
					m_Stream.Seek(pos, SeekOrigin.Current);
					break;
				case SeekOrigin.End:
					m_Stream.Position = m_DataPos + m_Length - pos;
					break;
			}
			return this.Position;
		}
		public override int Read(byte[] buf, int ofs, int count)
		{
			int toread = (int)Math.Min(count, m_Length - Position);
			return m_Stream.Read(buf, ofs, toread);
		}
		public override void Write(byte[] buf, int ofs, int count)
		{
			throw new InvalidOperationException();
		}

		public long DataLength
		{
			get
			{
				return m_Length;
			}
		}
	}
}
