USE [ColdStorage]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 06/03/2011 18:36:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Slug] [nvarchar](128) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Timestamp] [datetime] NOT NULL,
	[Site_Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Slug] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'About-Dota-660', N'About Dota 6.60', N'Content', CAST(0x00009C0B01411350 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Back-to-Chennai', N'Back to Chennai', N'Content', CAST(0x00009CBB0158F880 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Bing!', N'Bing!', N'Content', CAST(0x00009C1900A1C610 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Blizzard-Starcraft-2-Patch-11-Woes', N'Blizzard Starcraft 2 Patch 1.1 Woes', N'Content', CAST(0x00009DFB01650E40 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'BlizzCon-2010-!!', N'BlizzCon 2010 !!', N'Content', CAST(0x00009E1501788E70 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Browser-2-0-Part-I', N'Browser 2.0 - Part I', N'Content', CAST(0x00009AF10125E260 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Cant-Wait2c-Im-Sorry', N'Can''t Wait, I''m Sorry.', N'Content', CAST(0x00009BBE00B3E6B0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Charisma', N'Charisma', N'<div class="entry">
	<p>
		Most of the readers already know this - and I&#39;m probably not doing anything world-turning when I say this : (But I&#39;m going to go ahead &amp; say this anyway to spawn some discussion)</p>
	<p>
		Folks often present ideas, give opinions, and discuss plans - &nbsp;but it is another matter entirely if these same people want others to listen and pay attention.</p>
	<p>
		One&#39;s conversation includes a lot more than words one speaks. While the content plays an important role, I wish to give special importance to&nbsp; :</p>
	<ul>
		<li>
			Intonation</li>
		<li>
			Accompanying hand gestures / body language</li>
		<li>
			Facial expression</li>
		<li>
			Confidence</li>
	</ul>
	<p>
		To get all of these right requires a lot of work, (probably in front of a mirror :| ) and maybe some patience ...</p>
	<p>
		Words well said can potentially influence anyone, when done with skill. Sadly it preconditions existence of good social skills and a liking of human social interactions. I invite any comments that add to the above list, or other thoughts on this opinion. I have imperatively stated the above without backing data, with only an instinctive feeling, so any sort of discussion on this is welcome.</p>
	<p>
		&nbsp;</p>
</div>
', CAST(0x00009DCF00B3A060 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Clan-Feeders-is-ONLINE', N'Clan Feeders is ONLINE', N'Content', CAST(0x00009CC800F61800 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Comedy-Family-Tree', N'Comedy Family Tree', N'Content', CAST(0x00009C0B01490A60 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Default-button-in-ASPNET', N'Default button in ASP.NET', N'Content', CAST(0x00009C2A00015F90 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Defense-of-the-Pendragon---LOL', N'Defense of the Pendragon - LOL', N'Content', CAST(0x00009C0B013BDB60 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Does-PrincipalPermission-fail-always', N'Does PrincipalPermission fail always?', N'Content', CAST(0x00009A9A0044AA20 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Dota-660', N'Dota 6.60', N'Content', CAST(0x00009BF801598520 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'End-of-Holidays-in-Horizon-(', N'End of Holidays in Horizon :(', N'Content', CAST(0x00009C6E00CAF8F0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Essential-Tip-for-any-ASPNET-developer', N'Essential Tip for any ASP.NET developer', N'Content', CAST(0x00009B17013C6800 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Fact-and-Fiction', N'Fact & Fiction', N'Content', CAST(0x00009AED00D98780 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Feeder-Friends', N'Feeder Friends', N'Content', CAST(0x00009C57015B7150 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'FEEDER-STORIES', N'FEEDER STORIES', N'Content', CAST(0x00009C2900D44F90 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Five-Minute-ASPNETMVC', N'Model - View - Controller - The RoR Inspired Design Pattern!', N'Content', CAST(0x00009ADB01822B60 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'From-The-Studio-To-Release', N'From The Studio To Release', N'<p>
	chnage</p>
<p>
	&nbsp;</p>
<p>
	&nbsp;</p>
<p>
	asdasd</p>
', CAST(0x00009A97008D2CA0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Game-On', N'Game On!', N'Content', CAST(0x00009AED00CFEA90 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61', N'Getting started with Apache Struts 2 , with Netbeans 6.1', N'Content', CAST(0x00009B0C015EBD10 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Gin-GWT-Command-Pattern', N'Gin GWT Command Pattern', N'Content', CAST(0x00009CCF0114DB00 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Graduated-!!', N'Graduated !!', N'Content', CAST(0x00009C500076A700 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Greatest-Content-of-late-2008', N'Greatest Content of late 2008', N'Content', CAST(0x00009B7B010A24D0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Groovy-and-Grails-3d-GG', N'Groovy and Grails = GG', N'Content', CAST(0x00009CCF011A12F0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'GWT-Library', N'GWT Library', N'<div class="entry">
	<p>
		Today hosted my GWT library on code.google.com.</p>
	<p>
		<a href="http://code.google.com/p/xmlview-gwt/">http://code.google.com/p/xmlview-gwt/</a></p>
	<p>
		This ought to help out MVP devs tied up with GWT, an&#39; maybe give gwt 3.0 some ideas :)</p>
	<p>
		Looking for some contributers/committers now...</p>
</div>
', CAST(0x00009DB401396290 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Home-PC-v30', N'Home PC v3.0', N'<div>
	Check it out @ &nbsp;<a href="http://www.facebook.com/album.php?aid=281802&amp;id=815596121&amp;l=cb4a23b17f">Facebook Images</a>&nbsp;&nbsp;- &nbsp;There are a few neat things I can share here :</div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	Power Supply required for your custom configuration can be calculated here :&nbsp;<a href="http://www.antec.outervision.com/">http://www.antec.outervision.com/</a>&nbsp;It helps you make decision on the proper PSU/SMPS for your machine. Mine is around 345 Watts - so I got a 400W Zebronics SMPS (take into account ageing and surges)</div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	Most monitors are LCD which means they have a white backlight source burning all the time behind and any blackness and colors are rendered by shining it through liquid crystals turned by electricity. Which means black is not really black but is sort of bright gray, and power is wasted by throwing light and blocking it. My LED monitor works by radiating appropriate color light, and not burning at all in black regions on the screen. &nbsp;</div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	LED is mostly seen in TVs and they cost 30k and above for even being HD-Ready [720p max supported resolution]&nbsp;26 inches, and full HD [1080p] are available only for 32 inches and above, this acer monitor I bought is 24 inches AND LED technology AND Full HD AND only 15K - almost too suspicious to be true, but its bought Ill follow up here if it screws up.</div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	For a decent Gaming and Dev PC, &nbsp;Core i5 7XX (4 Core) is the best :</div>
<div>
	&nbsp;</div>
<div>
	No matter what Intel says - Core i7 gives only a very small improvement over i5 and only in Physics heavy games (Think shooters and a few RTS titles) and the physics rendered by those engines is usually on collisions and explosions and on Faces only which are themselves grainy to start with and last only for half a second or so.</div>
<div>
	&nbsp;</div>
<div>
	<a href="http://www.geek.com/articles/games/nvidia-proves-intels-core-i7-is-money-wasted-for-gamers-20090430/">http://www.geek.com/articles/games/nvidia-proves-intels-core-i7-is-money-wasted-for-gamers-20090430/</a></div>
<div>
	<a href="http://www.bit-tech.net/news/hardware/2009/04/23/core-i7-waste-of-money-says-nvidia/1">http://www.bit-tech.net/news/hardware/2009/04/23/core-i7-waste-of-money-says-nvidia/1</a></div>
<div>
	&nbsp;</div>
<div>
	Clock speed increase is only 210 MHz, and Cache size is same, HT tech is enabled for i7 not for 4-core i5. &nbsp;I am talking about Core i5 7XX series here which are quad core with 4 concurrent threads no HT - not the Core i5 4XX, 5XX and 6XX series which have only 2 core and still manage 4 threads by using HT. Prefer 2 extra cores over HT. Only core i7 gives both 4 cores and HT enabling 8 concurrent threads.</div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	On a side note :</div>
<div>
	&nbsp;</div>
<div>
	Home PC v0.0 was P3 550 MHz, 64 MB Ram, Integrated Graphics.</div>
<div>
	Home PC v1.0 was P4 2.8 GHz, 256 MB Ram, nVidia 5400 256 VRAM.</div>
<div>
	Home PC v2.0 was P4 3.0 GHz, 1 GB Ram, ATI HD 4650 512 MB VRAM (PC World Best buy in 2007).</div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
', CAST(0x00009E64008CE650 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Integrity', N'GWT - Testing ; GWT Renderers', N'<div class="entry">
	<p>
		[Edited on 4th June, Removed sensitive Info)]</p>
	<p>
		&nbsp;There are some points that needs to be considered while extensively using GWT, and while test driving the entire development. Service calls and callbacks abound while writing any enterprise GWT App. What your app does during the gap between the call and the callback needs to be addressed. If you have a button click making a service call, for example, you may need to disable the button untill the callback is done.. else a frustrated user may click it multiple times making several service calls. (which in my case led to StaleObjectStateExceptions)</p>
	<p>
		When you test drive your GWT code, you probably want to test your CallBacks and ClickHandlers ... to do this instead of writing code like :</p>
	<pre class="brush:java;">
button.addClickHandler(new ClickHandler(){
void onClick(){
// Handler
}
})

service.doMethod(argument, new AsyncCallback&lt;reply&gt;(){
onFailure(){
// Handler
}
onSucess(){
// Handler
}
})
</pre>
	<p>
		(these fragments are impossible to test -- 1. We need to test if proper wiring has been done 2. We need to test if wired handlers have correct logic in then) we do this :</p>
	<pre class="brush:java;">
button.addClickHandler(createClickHandler)

void createClickHandler(){
return new ClickHandler(){
void onClick() {
// Handler
}
}
}

service.doMethod(argument,  createCallBack() )

void createCallBack(){
return new AsyncCallback&lt;reply&gt;(){
onFailure(){
// Handler
} 
onSucess(){
// Handler
}
}
}

</pre>
	<p>
		Now we can make these methods package local and test them ... Testing is incredibly easy if we follow the MVP Pattern or the View/ViewHandler Pattern</p>
	<pre class="brush:java;">
public void test() {
createCallBack().onSuccess(); 
  verify(blah blah blah) ;  // for functionality testing
}

presenterTestable = new Presenter(){
@Override
void createCallback()  {
  return mockCallback;  // for wiring up testing
  verify(service).execute(&quot;argument&quot;, mockCallback)
}
}

</pre>
	<p>
		We in MOST cases need only one instance of a clickhandler or callback.. so this createClickHandler or createCallback must be wrapped into a singleton pattern -- that way for wiring up tests we dont need to override the presenter/viewhandler and make our methods return mocks. Like :</p>
	<pre class="brush:java;">
void createCallBack() {
return Singleton.return(new AsyncCallback&lt;reply&gt;(){
onFailure(){
  // Handler
}
onSucess(){
  // Handler
}
})
}

</pre>
	<p>
		What finally came out was :</p>
	<pre class="brush:java;">
import java.util.HashMap;

public class HandlerCache {

    private HashMap&lt;String, Object&gt; registry = 
       new HashMap&lt;String, Object&gt;();

    public &lt;T&gt; T wrap(T handler) {
        String name = handler.getClass().getName();
        if (registry.containsKey(name))
            return (T) registry.get(name);
        else {
            registry.put(name, handler);
            return handler;
        }
    }

    public void clear() {
        registry.clear();
    }

}


</pre>
	<p>
		with source having an instance of this utility decalred once at the top and adding of handlers looking like</p>
	<pre class="brush:java;">
HandlerCache one = new HandlerCache()

doneButton.addClickHandler(createDoneClickHandler());

void createDoneClickHandler(){
return one.wrap(new ClickHandler(){
void onClick() {
// Handler
}
})
}
</pre>
	<p>
		and test looking like :</p>
	<pre class="brush:java;">
verify(doneButton).addClickHandler(
  presenter.createDoneClickHandler());
</pre>
	<p>
		And when it comes to creating new widgets for your GWT App, the easiest thing to do will be to have a class extending Composite with initWidget() call in it. Instead of this which combines the rendered HTML and the logic of the widget itself ; a better way would be to have the widget as a POJO, and have a renderer that can render the POJO into GWT UIObjects like :</p>
	<pre class="brush:java;">
public class NumberGrid{

ArrayList&lt;NumberGridCell&gt; grid = 
 new ArrayList&lt;NumberGridCell&gt;();

int cols; 

public NumberGrid (int maxno, int cols) {
for(int i =0; i&lt;maxno; i++)
grid.add(new NumberGridCell(i))
this.cols = cols;
} 

public NumberGridCell getCell(int row, int col) {
return grid.get(row * cols + col) ;
} 

public remove Number(int number){
grid.remove(number); 
}
}

public class NumberGridTableRenderer extends FlexTable{

public void render(
  NumberGrid numberGrid,
  int rows, int columns) 
{
  NumberGridCellDivRenderer cellDivRenderer 
     = new NumberGridCellDivRenderer();
  for(int row = 0; row&lt;rows; row++)
   for(int col =0; col&lt;columns; col++)
    super.setWidget(row, col, 
    cellDivRenderer.render(numberGrid.getCell(row, col)));
}

}



</pre>
	<p>
		This renders the NumberGrid with &lt;table&gt; &lt;tr&gt; &lt;td&gt; &nbsp;tags.... with each individual cell rendered as a &lt;div&gt; . We can now potentially change the way NumberGrid is rendered using different renderers - for example make a&nbsp;NumberGridDivRenderer or&nbsp;NumberGrid_OL_LI_Renderer which renders the grid as a set of &lt;div&gt; tags or as a set of &lt;ul&gt; or &lt;ol&gt; tags... and a&nbsp;NumberGridCell_LI_Renderer&nbsp;which renders the cell as &lt;li&gt; tagged elements.</p>
	<p>
		&nbsp;&nbsp;A GWT based enterprise project will often create lots of widgets like LabelledTextBox, ValuedButton, etc .. &nbsp;Some of such commonly created widgets are actually just a collection of GWT standard widgets -&nbsp;LabelledTextBox = Label + TextBox &nbsp;; &nbsp;DateWidget = 3 ComboBoxes (year month day) &nbsp;; TimeWidget = 3 ComboBoxes (hour minute seconds) ; RadioButtonGroup and so on... &nbsp; In such cases it probably makes sense to follow the provider pattern :</p>
	<p>
		&nbsp;The functionality expected out of a DateWidget is like If you select day as 31 and month as February you might want the day combo deselected or selected 29 or 28 and so on.. To implement such functionality if we have DateWidget extending Composite or FlowPanel , and we have the widget in many places as is the case most of the time, then we are forced to using the same layout everywhere.. or have fields describing the layout in the widget. &nbsp;Assuming we have a WidgetProvider as in DateWidgetProvider and it acts like a factory that gives you the 3 ComboBoxes :</p>
	<pre class="brush:java;">
ComboBox dateWidgetProvider.getDayCombo()
</pre>
	<p>
		Then we are free to use different layouts in different places and still logically bind the 3 ComboBoxes. For starters GWT does not have a ComboBox and you probably have to code up a class ComboBox extending ListBox with height 0.</p>
</div>
', CAST(0x00009D1501518E10 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'I-want-to-see-BlizzCon-12', N'I want to see BlizzCon ''12', N'Content', CAST(0x00009C7B014AB040 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Login-control-ASPNET-works-in-Firefox-but-not-in-IE', N'Login control + ASP.NET + works in Firefox, not in IE', N'Content', CAST(0x00009A9900D3C2F0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Moving-the-MBR-to-another-DeviceHard-Disk', N'Moving the MBR to another Device/Hard Disk', N'<div>
	<font size="3">The most common scenario for wanting to move the MBR to another Hard Disk is because you bought a newer faster/bigger drive and installed better OS in it and want to format the old Hard Disk so you can store other data in it.</font></div>
<div>
	&nbsp;</div>
<div>
	<font size="3">Every hard disk has an MBR (Master Boot Record) in its Sector 0 (1 sector = 512 bytes) - On a multiple hard disk system you have multiple MBRs and the BIOS Bootscreen shows the priority in which the devices are considered for checking for MBR.&nbsp;</font></div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	<font size="3">Usually your old hard disk willl contain an MBR, and new hard disks MBR will be missing. If you say, installed Windows 7 on the new Hard drive, you will still need the old hard disk as it contains the MBR that loads the Windows Boot Loader (which is also on the older hard drive) and this in turn bootstraps the Windows in the new Harddisk. So you wont be able to format the old Hard drive as it is the gateway to your OS on the new Harddisk.</font></div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	<font size="3">Other things you will observe in this scenario are - If you see the Computer Management screen (R-Click My Computer and click manage) - &gt; Storage -&gt; Disk Management you will observe the old Harddisk is marked as System and you can&#39;t format it as its disabled because it contains the MBR from which the OS booted from.</font></div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	<strong><font size="3">Steps to resolve :</font></strong></div>
<div>
	&nbsp;</div>
<div>
	<font size="3">1) Get EasyBCD 2.0+ and go to Bootloader Setup. In the create Bootable External Media section select your new harddisks OS partition and click on Install BCD - Press OK in the confirmation dialog regarding selection of BCD store if it turns up. This step will create empty BCD file &amp; data on the new HardDisk itself, where you have the new OS (Windows 7 usually).</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">2) In the MBR Configuration Options, select Install the (Windows 7/ Windows XP) bootloader to the MBR, based on what OS is in the partition you selected in step 1. I recommend choosing Windows7 bootloader, even if you want only XP. This step will make the MBR in your new harddisk bootable and it will boot into window 7 bootloader or XP bootloader</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">3) Go to the Add New Entry tab and Add an entry for all the OSes you have, including the one in your new harddisk. This step is usually done only if you choose Windows &nbsp;bootloader in the previous step. Even otherwise do this no worries. This will show all the OS options while booting up.</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">4) Finally restart Go to BIOS boot priority and give the New harddisk 1st priority, or atleast higher priority than the old harddisk.</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">5) Optional - Format the old harddisk and do whatever you want with it - this will delete the bootable MBR on it.</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	&nbsp;</div>
<div>
	<font size="3">Cheers. Be sure not to FlusterCuck your Harddrives :P</font></div>
', CAST(0x00009E6B012BED40 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Nested-MasterPages-seems-to-have-an-egg-or-two', N'Nested MasterPages seems to have an egg or two', N'Content', CAST(0x00009B5500BD83A0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'New-Kind-of-Advertising--Spamming-around', N'New Kind of Advertising / Spamming around', N'Content', CAST(0x00009CC000BAC480 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'On-the-other-hand', N'On the other hand', N'Content', CAST(0x00009C2100D70EB0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Play-DotA', N'Play DotA', N'Content', CAST(0x00009B9B00CDFE60 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Pre-Fetching-Troubles-A-Good-Idea', N'Pre-Fetching Troubles? A Good Idea', N'<p>
	<u>A Point in Case :</u></p>
<p>
	&nbsp;</p>
<p>
	In a standard ASP.NET application you have some stylesheet links in some aspx pages. These links further hav links to images using the url(...) format. When the browser downloads these stylesheets, it assumes the url(...) constructs links within the stylesheet are relative to the path from which the stylesheet itself was downloaded. This is usually the case. Stylesheets are downloaded from a folder say &quot;GreenTheme&quot; and usually theres a folder called &quot;images&quot; within the &quot;GreenTheme&quot; folder and stylesheet has constructs like :</p>
<pre class="brush:css;">
background-color:url(&#39;images/bg.png&#39;)
</pre>
<p>
	This means that , these images , when requested by the browser are served by the IIS server itself. <strong>These requests do not go through the ASP.NET runtime at all.</strong> Requests from browser to server will be like : <em>http://www.yourdomain.tld/GreenTheme/images/bg.png</em> which points to a valid file in the server directory structure and so IIS server can and does serve it, all by itself.Problem is it <strong>does not set required http headers that must be set if Image Pre-Fetching is needed.</strong></p>
<p>
	&nbsp;</p>
<p>
	<u>Why Pre-Fetch ?</u></p>
<p>
	&nbsp;</p>
<p>
	Suppose you have a CSS segment like this:</p>
<pre class="brush:css;">
.classA {  background-image:url(a.png); }

.classA:hover{  background-image:url(b.png);  } 
</pre>
<p>
	When the mouse hovers over an element which belongs to this class, it must display a different image. Simple, ain&#39;t it? But you can observe a DELAY when you hover your pointer over the element for the first time. This is the time taken to request the new background image from the server.From the second time onwards - when you hover - there is no delay in showing the image because it has already been fetched and cached.</p>
<p>
	A lot of such elements, (or) Big background images, (or) A slow internet connection&nbsp; - any of these means that users will see the delay effect prominantly and your UI is not going to be well thought of at all by visitors. So if you Pre-Fetch these images - (not only images that&#39;re required during hover) - in a , say , loading screen or in a previous page using a script that uses idle time, you ensure bestexperience for visitors.</p>
<p>
	Also it may be necessary that users don&#39;t see a partially rendered page - something todays advanced browsers are capable of showing (they render as the code is downloaded). We can use Pre-fetching to show a loading screen [as in <strong>GMail</strong> - while inbox is loading] while images, scripts, and AJAX-lets, and xml-xsl s&nbsp; are downloaded.</p>
<p>
	&nbsp;</p>
<p>
	<u>How to Pre-fetch?</u></p>
<p>
	&nbsp;</p>
<p>
	I&#39;ve used a page that shows &quot;Loading... &quot; while in the background a script pre-fetches some images, scripts, and stylesheets. This script keeps track of the various &lt;img&gt; tags and &lt;link&gt; tags that each points to a resource that is tobe prefetched. When all the elements are loaded , we assume all the links/images they are pointing to are fetched, and so we can move on to the next page.</p>
<pre class="brush:xml;">
&lt;div style=&quot;visibility:hidden&quot;&gt;

&lt;img src=&quot;GreenTheme/images/bg.jpg&quot; alt=&quot;&quot; onload=&quot;myfun()&quot;/&gt;

&lt;img src=&quot;GreenTheme/images/a.png&quot; alt=&quot;&quot; onload=&quot;myfun()&quot;/&gt;

&lt;img src=&quot;GreenTheme/images/b.png&quot; alt=&quot;&quot; onload=&quot;myfun()&quot;/&gt;

&lt;/div&gt;
</pre>
<p>
	myfun() may simply updates a global counter variable as it is&nbsp; called each time, checking if the maximum is reached. For eg if you have 10 images and 2 stylesheets and 2 scripts to be prefetched, you use 10 &lt;img src=&quot;..&quot;&gt; tags , 2 &lt;link href=&quot;..&quot;&gt; and 2 &lt;script src=&quot;..&quot;&gt; tags in the approperiate places (like in a hidden div) and max=10+2+2=14 for mfun(). When all 14 elements are loaded, use location.href in javascript to redirect to another page. Sometimes it is necessary to set visibility = hidden through javascript or our DIV tag, cause a browser may simply ignore elements within a div tag that is hidded (this is not likely)- but if u set visibility = hidden via javascript, as part of global code, we work around the issue.</p>
<p>
	&nbsp;</p>
<p>
	<u>If-Modified-Since problem</u> :</p>
<p>
	&nbsp;</p>
<p>
	When we use a loading page for prefetching images required by another page (possibly the home page) we come across this strange problem. <strong>HttpAnalyser </strong>is a software that detects and hooks onto an Internet Explorer instance and logs &amp; shows all HTTP requests/responses that tke place between the browser and any server.</p>
<p>
	When we request for our site with a loading page, As Expected we see requests for all the Pre-fetcher Links we put in.</p>
<p>
	Then we are redirected to a content aspx page (the page we redirected in the script using location.href) As Expected.</p>
<p>
	But whats Not Expected is the HttpAnalyser shows browser sending <em>If-Modified-Since</em> requests.</p>
<p>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For which the server replies <em>Not-Modified</em>.</p>
<p>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For all the pre-fetched images that occur in this page (for eg the Home Page).</p>
<p>
	Even though we have prefetched our images that occur in the home page , and those images that may be required when Hovering , and scripts etc in the Loading Page itself, some additional HttpRequests for these resources are sent. Okay they are NOT downloaded again - becuase they were prefetched, but instead of directly using the cached copy of the prefetched images, the browser takes time to ask the server if <strong>pre-fetched copy in cache - has it been modified since it was downloaded?&nbsp;</strong> Whenever a same image that was downloaded for a page, is needed for another page, the browser asks this question to the server in the form of a <em>If-Modified-Since &lt;DateTimeObject&gt; </em>HttpRequest. The Server replies <em>Not-Modified </em>and then the Cached copy is used.</p>
<p>
	&nbsp;</p>
<p>
	<u>The WorkAround :</u></p>
<p>
	&nbsp;</p>
<p>
	&nbsp;How do we eliminate this unnecessary if-modified-since request then? It is obviously not going to be necessay for us - coz stylesheet images, hover images and scripts are not going to be changed for a long time - and defenitely not in the short timespan between the display of the Loading Page and Home page. The Answer is the <em>Expires header.</em> What the server must do is : when sending the images that are requested in the pre-fetch load page, it must add a header called <em>Expires</em> to which it must assign a suitable value [im my case One Year]. This informs the browser that the images prefetched by it are not going to be modified for one year atleat. Its cached copies of those Hover images etc expires only after one year or so. So it does NOT send<em> If-Modified-since requests </em>when prefetched images (prefetched in Loading Page) are referred to from the Home Page or Other Pages.</p>
<p>
	&nbsp;</p>
<p>
	<u>How to WorkAround ?</u></p>
<p>
	&nbsp;</p>
<p>
	See the first section of this post. StyleSheet links directlt hit a valid image file. So they are served by the IIS Server, and so we cannot(no easy way to) tell the server that such and such an image must be sent with a caching header &quot;expires&quot;&nbsp; filled in with an approperiate vale.</p>
<p>
	What we&#39;re looking for is Http Handlers. Create an ASP.NET ashx HttpHandler that serves an image that is present in the same directory as the ashx file. [This is Important] Seperate the ashx file and code using a dll or a class in App_Code, because we will be having multiple Ashx files pointing to the same class[coz thre&#39;ll be many directories that contain stylesheet images]. In this class write the code to get a name from the QueryString and search for and write the image file coresponding to the given name to the response stream. Also use the <strong>Response.Caching.* properties</strong> to set the caching location as public (-cache at proxy client and server) and set the <strong>Expires header</strong> also from C# code.</p>
<p>
	Place this handler(the ashx file) in all the folders where stylesheet images are present. Say inside &quot;GreenTheme/images&quot; and inside &quot;RedTheme/images&quot;. Placing the ashx files here is important.</p>
<p>
	Now the sylesheets <em><strong>must</strong></em> contain modified constructs like</p>
<pre class="brush:css;">
background-color:url(&#39;images/CssImage.ashx?name=bg.png&#39;)
</pre>
<p>
	instead of</p>
<pre class="brush:css;">
background-color:url(&#39;images/bg.png&#39;)</pre>
<p>
	This way all the browser requests will be like</p>
<p>
	<em>http://www.yourdomain.tld/GreenTheme/images/CssImage.ashx?name=bg.png</em></p>
<p>
	<em>http://www.yourdomain.tld/RedTheme/images/CssImage.ashx?name=bg.png</em></p>
<p>
	instead of</p>
<p>
	<em>http://www.yourdomain.tld/GreenTheme/images/bg.png</em></p>
<p>
	<em>http://www.yourdomain.tld/RedTheme/images/bg.png</em></p>
<p>
	If the stylesheets contain links as specified above, the server has no choice nut to handover the ashx requests to ASP.NET runtime, thus our C# class coresponding to the CssImage.ashx file&nbsp; will serve the images <em><strong>WITH&nbsp; </strong></em>the caching headers such as EXPIRES and LOCATION in place. Values may also be set approperiately in code for these headers. Thus modifying the stylesheets by hand to change the contents of url(..) clauses, will solve our problem , but has Side Effects such as.</p>
<p>
	Loss of Designer support :</p>
<p>
	Having urls like :</p>
<pre class="brush:css;">
background-color:url(&#39;images/CssImage.ashx?name=bg.png&#39;)  </pre>
<p>
	in style sheets in Visual Studio will result in loss of designer support. During Design time you can&#39;t use the WYSIWYG editor. I hava developed a means of working around this too.</p>
<p>
	&nbsp;</p>
<ol>
	<li>
		Create CssImage.ashx files in all the Css image directories and poin them to our CssImagHandler C3 class as instructed before but DO NOT modify the stylesheet urls.&nbsp;</li>
	<li>
		Create a HttpHandler that serves stylesheets. This new handler serves stylesheets (.css files) after modifying the contents - changing all the url(images/xx.jpg) to url(images/CssImage.ashx?name=xx.jpg) whenever serving. Also this handler can be used to set the Caching Headers and Policies for the .css files themselves providing further boost in performance.</li>
	<li>
		Put this handler(.ashx file) in all places where there are stylesheet. Again we have multiple ashx files pointing to the same class, so we have to seperate the class coding and the ashx file itself. ( For eg. Put the new Css.ashx file copies in &quot;GreenTheme&quot; and &quot;RedTheme&quot;)</li>
	<li>
		<strong>Information </strong>: So now we have a handler that modifies stylesheet url contents, so that the urls point to a handler that handles image requests. In both handlers we set cachig headers and policies.</li>
	<li>
		<strong>Don&#39;t do this</strong> : Now we have to(but we don&#39;t - so don&#39;t do this step - just understand) change the &lt;link&gt; tags in our aspx pages from <em>&lt;link href=&quot;GreenTheme/style.css&quot; rel=&quot;stylesheet&quot; ... /&gt;</em>&nbsp; to which againresults in loss of designer support. The Designeer looks for link tags and automatically applies the stylesheet.. having&nbsp; <em>GreenTheme/Css.ashx?name=style.css</em> in the link tag is not understood by the designer.</li>
	<li>
		Do This : Instead what we do is leave the link tags unchanged, but write code in <strong>Page_Load</strong> or <strong>OnLoad</strong> handler etc .. that changes the link tags <em>&lt;link href=&quot;GreenTheme/style.css&quot; rel=&quot;stylesheet&quot; ... /&gt;</em>&nbsp; to <em>&lt;link href=&quot;GreenTheme/Css.ashx?name=style.css&quot; rel=&quot;stylesheet&quot; ... /&gt;</em></li>
	<li>
		Thus we make sure DYNAMICALLY, DURING A REQUEST,
		<ul>
			<li>
				That link tags are modified to make the stylesheets pass through the stylesheet handler,</li>
			<li>
				which makes sure that urls in the stylesheets it serves are modified tomake the images be requested through the image handler,</li>
			<li>
				both the handlers setting Client &amp; Server Caching policies and headers,</li>
			<li>
				and we don&#39;t lose designer support becoz handlers do their job only during when they are requested.</li>
			<li>
				As far as the designer sees ... links tag hrefs &amp; targets are okay... and target stylesheets urls are also okay</li>
		</ul>
	</li>
</ol>
<p>
	&nbsp;</p>
<p>
	So the functionality of our stylesheet handling class will be</p>
<ul>
	<li>
		Get the name of the stylesheet of the querystring</li>
	<li>
		Look for the file in the same directory as the ashx file, becoz we put stylesheet-handling ashx files in all directories containing stylesheets.</li>
	<li>
		For the previous step we can use the Request.Path property to get path of current request (that is the request to the Css.ashx file, when browser sees the modified &lt;link&gt; tags)</li>
	<li>
		Using that as a string, substringing to uptotheLastIndexOf(&#39;\&#39;) we get the directory where the Css.ashx file and the .css file itself is to be found.</li>
	<li>
		Append&nbsp; &lt;name(from QueryString)&gt;.css to the working string got from the prevoius step and use File Reader to read in contents of the stylesheet</li>
	<li>
		Use Regular Expressions or the logic I usedto Modify the url(..) clauses and send the string to Server Cache and Response stream</li>
	<li>
		Insert code in the beginning of the class that checks if modifies stylesheet is in&nbsp; the cache.. If present no need to read again.. just send the server -side cached copy.</li>
</ul>
<p>
	&nbsp;</p>
<p>
	All of the above concepts have implemetations in this site itself :)&nbsp; .. Download all code from <a href="http://chandruon.net/Downloads/Assembly.zip">https://github.com/chandru9279/StarBase/tree/master/Websites/Thon.NET/</a></p>
<p>
	Inside them see the class CssImage.ashx and Image.ashx and Css.ashx and the classes to which they are pointing to.</p>
<p>
	<a href="http://www.ieinspector.com/httpanalyzer/">http://www.ieinspector.com/httpanalyzer/</a> Here you can get the Http Analyser and check all this out for yourself.</p>
<p>
	Happy developing!</p>
', CAST(0x00009B5500BEE330 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'ReBlog--Has-Google-Blundered-with-the-Gmail-Beta', N'ReBlog : Has Google Blundered with the Gmail Beta?', N'Content', CAST(0x00009B070101A120 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Starcraft-2-Opts-out-of-local-Multiplayer', N'Starcraft 2 Opts out of local Multiplayer', N'Content', CAST(0x00009C3900A85D90 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'This-site-is-going-to-get-an-overhaul!', N'This site is going to get an overhaul!', N'<div class="entry">
	<p>
		I just moved this site to the cloud, and just decided that this whole shebang needs an overhaul. The new site, I&#39;m afraid, will be less personal and more sleek and shiny, with a business look - think wordpress! And some parts may not work.</p>
	<p>
		Net feeling after porting to cloud is : It&#39;s almost like owning another computer, except you can&#39;t touch it. Installed usual stuff like chrome, notepad++ and even VLC media player on my server :P - Amazing the amount of control you have over your hardware. Now Server OSes which used to do some virtualization over hardware, &nbsp;might just degenerate back into simpler versions, as they find themselves suddenly running on virtualized hardware.</p>
	<p>
		And other feeling is Windows Authentication in IIS really sucks - it needs a whole bunch of configuration, and after that, it needs some more configuration, and after that - just a little more configuration and finally it does&#39;nt work (something about NETWORK SECURITY account needing permissions on a folder etc, it does work after setting it, though) . Enjoy using SQL Server authentication instead, and on a side note - there is this cloud advantage - if you install (or enable) iSCSI then you got 30 GB of hard disk on the internet - It Is Yours To Own and as fast as your internet connection.</p>
	<p>
		I hope to get rid of the the comment spam on some posts once and for all, it discourages my friends to leave a comment or two when they read the post. And ReCAPTCHA comes to the mind - no more quick and easy comments. Happy Diwali everyone ! Night sky is so lit up (atleast upto the point when it rained).&nbsp;</p>
	<p>
		Updates :</p>
	<p>
		For those people who enjoy Wodehouse : Terry Pratchett &amp; Neil Gaiman&#39;s - Good Omens &nbsp;is a must. [&nbsp;<a href="http://en.wikipedia.org/wiki/Good_Omens">http://en.wikipedia.org/wiki/Good_Omens</a>&nbsp;]</p>
	<p>
		And those Noobs a.k.a Starcrafters : Check out Husky&#39; VLOG - www.youtube.com/HuskyStarcraft&nbsp;</p>
	<p>
		And Dota-maniacs : Valve hires Icefrog for Dota 2.0 ETA 2011 [&nbsp;<a href="http://www.rockpapershotgun.com/2010/10/13/valve-announces-dota-2/">http://www.rockpapershotgun.com/2010/10/13/valve-announces-dota-2/</a>&nbsp;]</p>
	<p>
		&nbsp;</p>
	<p>
		Edit (June 3rd 2011) :</p>
	<p>
		Partially complete - The old site looks like this :</p>
	<p>
		<img alt="" src="/Uploads/Files/OldSite.png" style="width: 602px; height: 536px;" /></p>
	<p>
		and the new one - you are looking at it one part of it, the other part is at <a href="http://zasz.me/">http://zasz.me/</a></p>
	<p>
		&nbsp;</p>
</div>
', CAST(0x00009E25011B7280 AS DateTime), N'Both')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'ThoughtWorks', N'ThoughtWorks', N'Content', CAST(0x00009C9100CAB2A0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Training-At-TWU', N'Training At TWU', N'Content', CAST(0x00009C9B014C9C70 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'USB-Guard', N'USB Guard', N'Content', CAST(0x00009B10017B93E0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Welcome-to-ZaszBlog', N'Welcome to ZaszBlog', N'Content', CAST(0x00009A8600000000 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'WTF-Sadness', N'WTF Sadness', N'Content', CAST(0x00009C1E01815870 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'ZaszzasZ', N'Zasz.zasZ', N'Content', CAST(0x00009C7F01342AA0 AS DateTime), N'Rest')
/****** Object:  Table [dbo].[Passphrases]    Script Date: 06/03/2011 18:36:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passphrases](
	[PhraseDigest] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[OneTime] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PhraseDigest] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 06/03/2011 18:36:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[ID] [nvarchar](128) NOT NULL,
	[Error_ApplicationName] [nvarchar](max) NULL,
	[Error_HostName] [nvarchar](max) NULL,
	[Error_Type] [nvarchar](max) NULL,
	[Error_Source] [nvarchar](max) NULL,
	[Error_Message] [nvarchar](max) NULL,
	[Error_Detail] [nvarchar](max) NULL,
	[Error_User] [nvarchar](max) NULL,
	[Error_Time] [datetime] NOT NULL,
	[Error_StatusCode] [int] NOT NULL,
	[Error_WebHostHtmlMessage] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EdmMetadata]    Script Date: 06/03/2011 18:36:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EdmMetadata](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelHash] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EdmMetadata] ON
INSERT [dbo].[EdmMetadata] ([Id], [ModelHash]) VALUES (1, N'B32F992C63F816F6A41ADECD813CA563E55D4A440BFDC14DC4A1B6E60ED34381')
SET IDENTITY_INSERT [dbo].[EdmMetadata] OFF
/****** Object:  Table [dbo].[Tags]    Script Date: 06/03/2011 18:36:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Name] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Tags] ([Name]) VALUES (N'asp.net')
INSERT [dbo].[Tags] ([Name]) VALUES (N'blizzard')
INSERT [dbo].[Tags] ([Name]) VALUES (N'books')
INSERT [dbo].[Tags] ([Name]) VALUES (N'broke')
INSERT [dbo].[Tags] ([Name]) VALUES (N'browser')
INSERT [dbo].[Tags] ([Name]) VALUES (N'concept')
INSERT [dbo].[Tags] ([Name]) VALUES (N'crap')
INSERT [dbo].[Tags] ([Name]) VALUES (N'does not work')
INSERT [dbo].[Tags] ([Name]) VALUES (N'dota')
INSERT [dbo].[Tags] ([Name]) VALUES (N'fun')
INSERT [dbo].[Tags] ([Name]) VALUES (N'games')
INSERT [dbo].[Tags] ([Name]) VALUES (N'groovy grails patterns java concept')
INSERT [dbo].[Tags] ([Name]) VALUES (N'gwt')
INSERT [dbo].[Tags] ([Name]) VALUES (N'gwt java')
INSERT [dbo].[Tags] ([Name]) VALUES (N'java')
INSERT [dbo].[Tags] ([Name]) VALUES (N'mvc')
INSERT [dbo].[Tags] ([Name]) VALUES (N'security')
INSERT [dbo].[Tags] ([Name]) VALUES (N'starcraft 2 patch 1.1')
INSERT [dbo].[Tags] ([Name]) VALUES (N'sucks')
INSERT [dbo].[Tags] ([Name]) VALUES (N'tw')
INSERT [dbo].[Tags] ([Name]) VALUES (N'twu')
INSERT [dbo].[Tags] ([Name]) VALUES (N'wcf')
INSERT [dbo].[Tags] ([Name]) VALUES (N'web')
INSERT [dbo].[Tags] ([Name]) VALUES (N'welcome')
/****** Object:  Table [dbo].[TagPosts]    Script Date: 06/03/2011 18:36:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagPosts](
	[Tag_Name] [nvarchar](128) NOT NULL,
	[Post_Slug] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tag_Name] ASC,
	[Post_Slug] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'asp.net', N'Default-button-in-ASPNET')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'asp.net', N'Does-PrincipalPermission-fail-always')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'asp.net', N'Five-Minute-ASPNETMVC')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'asp.net', N'From-The-Studio-To-Release')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'asp.net', N'Login-control-ASPNET-works-in-Firefox-but-not-in-IE')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'asp.net', N'Nested-MasterPages-seems-to-have-an-egg-or-two')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'asp.net', N'Pre-Fetching-Troubles-A-Good-Idea')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'blizzard', N'I-want-to-see-BlizzCon-12')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'blizzard', N'Starcraft-2-Opts-out-of-local-Multiplayer')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'books', N'Fact-and-Fiction')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'books', N'Greatest-Content-of-late-2008')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'broke', N'Blizzard-Starcraft-2-Patch-11-Woes')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'browser', N'Browser-2-0-Part-I')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'browser', N'Login-control-ASPNET-works-in-Firefox-but-not-in-IE')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'concept', N'Browser-2-0-Part-I')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'concept', N'From-The-Studio-To-Release')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'concept', N'Login-control-ASPNET-works-in-Firefox-but-not-in-IE')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'concept', N'Pre-Fetching-Troubles-A-Good-Idea')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'crap', N'Blizzard-Starcraft-2-Patch-11-Woes')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'does not work', N'Blizzard-Starcraft-2-Patch-11-Woes')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'dota', N'About-Dota-660')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'dota', N'Clan-Feeders-is-ONLINE')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'dota', N'Comedy-Family-Tree')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'dota', N'Defense-of-the-Pendragon---LOL')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'dota', N'Dota-660')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'dota', N'On-the-other-hand')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'dota', N'Play-DotA')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'dota', N'ZaszzasZ')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'fun', N'This-site-is-going-to-get-an-overhaul!')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'games', N'Defense-of-the-Pendragon---LOL')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'games', N'Game-On')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'games', N'Greatest-Content-of-late-2008')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'games', N'Home-PC-v30')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'games', N'Play-DotA')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'games', N'Starcraft-2-Opts-out-of-local-Multiplayer')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'games', N'ZaszzasZ')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'groovy grails patterns java concept', N'Groovy-and-Grails-3d-GG')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'gwt', N'GWT-Library')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'gwt', N'Integrity')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'java', N'Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'java', N'Integrity')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'mvc', N'Back-to-Chennai')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'mvc', N'Five-Minute-ASPNETMVC')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'security', N'Does-PrincipalPermission-fail-always')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'security', N'New-Kind-of-Advertising--Spamming-around')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'security', N'USB-Guard')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'starcraft 2 patch 1.1', N'Blizzard-Starcraft-2-Patch-11-Woes')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'sucks', N'Blizzard-Starcraft-2-Patch-11-Woes')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'tw', N'Back-to-Chennai')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'tw', N'Training-At-TWU')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'twu', N'Back-to-Chennai')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'twu', N'ThoughtWorks')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'twu', N'Training-At-TWU')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'wcf', N'Does-PrincipalPermission-fail-always')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'web', N'Browser-2-0-Part-I')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'web', N'Default-button-in-ASPNET')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'web', N'Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'web', N'Graduated-!!')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'web', N'GWT-Library')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'web', N'Pre-Fetching-Troubles-A-Good-Idea')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'web', N'ReBlog--Has-Google-Blundered-with-the-Gmail-Beta')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'web', N'Welcome-to-ZaszBlog')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'welcome', N'Play-DotA')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'welcome', N'Welcome-to-ZaszBlog')
/****** Object:  ForeignKey [Tag_Posts_Source]    Script Date: 06/03/2011 18:36:16 ******/
ALTER TABLE [dbo].[TagPosts]  WITH CHECK ADD  CONSTRAINT [Tag_Posts_Source] FOREIGN KEY([Tag_Name])
REFERENCES [dbo].[Tags] ([Name])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagPosts] CHECK CONSTRAINT [Tag_Posts_Source]
GO
/****** Object:  ForeignKey [Tag_Posts_Target]    Script Date: 06/03/2011 18:36:16 ******/
ALTER TABLE [dbo].[TagPosts]  WITH CHECK ADD  CONSTRAINT [Tag_Posts_Target] FOREIGN KEY([Post_Slug])
REFERENCES [dbo].[Posts] ([Slug])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagPosts] CHECK CONSTRAINT [Tag_Posts_Target]
GO
