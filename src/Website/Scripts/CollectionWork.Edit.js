if(!window.Shared)window.Shared={};Shared.Common=new function(){var e="ui-state-highlight",d="#userMessage",_my=this;_my.ProgressImageUrl="/content/progress.gif";_my.ProgressImage='<img src="'+_my.ProgressImageUrl+'" />';_my.SuggestTagsUrl="/Works/SuggestTags";_my.InitialUserMessage=null;_my.Ready=function(){var a="#txtSearch";$(a).autocomplete("/Music/AutoCompleteSearchTerm/",{delay:40,selectFirst:true,multiple:true,highlight:false});$("#lnkSearch").click(function(e){e.preventDefault();var b=$(a),d=b.val();if(d!=""){var c=$(this).parents("form");c.submit()}});$(".navTab").each(function(){var a=$(this),c=a.find("a"),b=c.attr("href");if(document.location.href.indexOf(b)!=-1){a.addClass("ui-state-active");return false}});$(d).click(function(){$(d).fadeOut(100)});_my.InitialUserMessage!=null&&_my.ShowUserMessage(_my.InitialUserMessage)};_my.HijaxButtonHoverStates=function(){var a="ui-state-hover";$(".fg-button:not(.ui-state-disabled)").hover(function(){$(this).addClass(a)},function(){$(this).removeClass(a)})};_my.ShowUserMessage=function(a){var b=$(d);b.toggleClass("ui-state-error",a.Type==0).toggleClass(e,a.Type==1).toggleClass("Warning",a.Type==2).html(a.Message).show();a.Type!=0&&b.delay(2500).fadeOut(100)};_my.ShowUserMessages=function(c){var a=$(d);a.toggleClass(e);a.empty();var b=true;$.each(c,function(e,c){a.append($("<div></div>"));var d=a.find("div:last");d.toggleClass("Error",c.Type==0);d.toggleClass("Info",c.Type==1);d.toggleClass("Warning",c.Type==2);d.html(c.Message);if(c.Type==0)b=false});a.show();b&&a.delay(2500).fadeOut(100)};_my.IsEmpty=function(a){return a.replace(/\s/g,"")==""};_my.FileSize=function(a){var c=["bytes","kb","MB","GB","TB","PB"],b=Math.floor(Math.log(a)/Math.log(1024));return (a/Math.pow(1024,Math.floor(b))).toFixed(2)+" "+c[b]};_my.ParseJson=function(jsonString){return eval("("+jsonString+")")}};$(function(){Shared.Common.Ready();Shared.Common.HijaxButtonHoverStates()});if(!window.CollectionWork)window.CollectionWork={};CollectionWork.Edit=new function(){var a=this;a.HijaxAll=function(){var a=$(".collectionWorkForm");!a&&alert("no form");CollectionWork.CollectionWorkForm.HijaxForm(a)}};$(function(){CollectionWork.Edit.HijaxAll()});if(!window.CollectionWork)window.CollectionWork={};CollectionWork.CollectionWorkForm=new function(){var a=this;a.HijaxForm=function(b){var a=true;b.find("a.licenseHelp").click(function(d){d.preventDefault();var b=$("#modalWindow"),c=$(d.target).attr("href");if(!c)c=$(d.target).parent().attr("href");b.attr("title","Available Licenses");b.dialog({resizable:a,height:300,width:450,buttons:{Close:function(){b.dialog("destroy")}},open:function(){b.html(Shared.Common.ProgressImage);$.get(c,"",function(a){b.html(a)},"html")},close:function(){b.dialog("destroy")}})});b.find(".suggestTags").autocomplete(Shared.Common.SuggestTagsUrl,{delay:40,selectFirst:a,multiple:a,highlight:false});b.find(".dateInput").datepicker({changeYear:a,defaultDate:0});b.validate({errorClass:"ui-state-error",errorElement:"div",rules:{Title:{required:a,maxlength:100},ReleaseDate:{required:a,date:a}},messages:{Title:{maxlength:"The Title is too long (up to 100 characters allowed)"}}});b.find("input:first").focus()}}