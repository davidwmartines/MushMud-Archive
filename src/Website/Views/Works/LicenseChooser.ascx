<%@ CONTROL language="C#" inherits="System.Web.Mvc.ViewUserControl" %>
<style type="text/css">
	/** Edit me to fit your particular look **/
	#cc_js_lic-menu
	{
		width: 500px;
		margin: 0 auto; /*border: 1px solid #ddd;*/
	}
	.cc_js_body
	{
		background-color: #fff;
		color: #343434;
		font: 71%/145% "Lucida Grande" , verdana, sans-serif;
		padding: 0;
		margin: 0;
		text-align: center;
	}
	#cc_js_header-main
	{
		width: 93%;
		min-width: 700px;
		margin: 0 3%;
		padding: 10px 0 2px 1%;
		text-align: left;
		font-size: 11px !important;
	}
	/* -- elements */a.cs_js_a, a:link.cs_js_a
	{
		text-decoration: none;
		color: #00b;
	}
	a:hover.cs_js_a
	{
		text-decoration: underline;
	}
	#cc_js_license_selected
	{
		border: 1px solid #c2e0cf;
		text-align: center;
		padding: 3%;
		margin-bottom: 2.7%;
	}
	#cc_js_jurisdiction_box
	{
		/* border: 1px solid black; */
		padding: 0.5% 2% 1% 2%;
		margin-bottom: 1%;
	}
	#cc_js_lic-menu h2
	{
		/* text-decoration: underline; */ /* border-bottom: 1px solid black; */
		padding: 3% 0 1% 0;
		border: none;
	}
	#cc_js_lic-result
	{
		padding: 0;
		margin: 0;
	}
	select#cc_js_jurisdiction
	{
		margin-bottom: 2%;
	}
	textarea#cc_js_result
	{
		width: 9%;
		border: 1px solid #ccc;
		color: gray;
		margin-top: 1%;
	}
	a.cc_js_a img
	{
		border: none;
		text-decoration: none;
	}
	#cc_js_more_info
	{
		border: 1px solid #eee;
		padding: 0.5% 2% 1% 2%;
		margin-bottom: 1%;
		margin-top: 1%;
		width: 87%;
	}
	#cc_js_more_info table
	{
		width: 65%;
	}
	#cc_js_more_info .header
	{
		width: 35%;
	}
	#cc_js_more_info input
	{
		width: 100%;
		border: 1px solid #ccc;
	}
	#cc_js_required
	{
		border-top: 1px solid #ccc;
		border-bottom: 1px solid #ccc;
		padding: 4% 2%;
		margin-bottom: 1%;
		margin-top: 2px; /* background: #efefef; 
    background: #eef6e6;*/
	}
	#cc_js_work_title
	{
		font-style: italic;
	}
	#cc_js_optional
	{
		border: 1px solid #eee;
		padding: 0.5% 2% 1% 2%;
		margin-bottom: 1%;
		margin-top: 1%;
		width: 87%;
	}
	.cc_js_cc-button
	{
		padding-bottom: 1%;
	}
	.cc_js_info
	{
		vertical-align: middle;
	}
	img.cc_js_info
	{
		float: right;
	}
	#cc_js_jurisdiction_box
	{
		clear: left;
	}
	#cc_js_lic-menu p
	{
		padding: 3px 0 5px 0;
		margin: 0 0 5px 0;
	}
	.cc_js_tooltip
	{
		background: white;
		border: 2px solid gray;
		padding: 3px 10px 3px 10px;
		width: 300px;
		text-align: left;
	}
	.cc_js_tooltip .cc_js_icon
	{
		float: left;
		padding-right: 4%;
		padding-bottom: 20%;
	}
	.cc_js_tooltipimage
	{
		border: 2px solid gray;
	}
	.cc_js_infobox
	{
		cursor: help;
	}
	.cc_js_question
	{
		cursor: help; /*color:          #00b;*/
		border-bottom: 1px dashed #66b;
	}
	.cc_js_hidden
	{
		display: none;
	}
	#cc_js_required .cc_js_question
	{
		border: none;
	}
	#cc_js_want_cc_license_at_all
	{
		background-color: #eef6e6;
		font-size: 1.35em;
		padding: 0.25em;
		padding-left: 0;
	}
	#cc_js_want_cc_license_at_all span
	{
		margin-right: 1.5em;
		padding: 0.5em;
	}
	#cc_js_want_cc_license_at_all span span
	{
		margin: 0;
		padding: 0;
	}
	#cc_js_required p
	{
		padding-bottom: 50px;
	}
	#cc_js_remix-label span
	{
		background: url('http://creativecommons.org/images/deed/remix.png') no-repeat top left;
		padding-left: 60px;
		padding-bottom: 60px;
	}
	#cc_js_nc-label span
	{
		background: url('http://creativecommons.org/images/deed/nc.png') no-repeat top left;
		padding-left: 60px;
		padding-bottom: 60px;
	}
	#cc_js_sa-label span
	{
		background: url('http://creativecommons.org/images/deed/sa.png') no-repeat top left;
		padding-left: 60px;
		padding-bottom: 60px;
	}
</style>
<div>
	You can read about each license at the <a href="http://creativecommons.org/about/licenses" target="_blank">Creative Commons website</a>.
</div>
<div id="cc_js_widget_container" style="margin-top:3em">
	You can also choose a license by selecting the conditions from the list below:

	<script type="text/javascript" src="http://api.creativecommons.org/jswidget/tags/0.97/complete.js?locale=en_US&amp;jurisdictions=disabled&amp;want_a_license=definitely"></script>

	
</div>
