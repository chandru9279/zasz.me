USE [ColdStorage]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 06/14/2011 17:19:20 ******/
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'd4439543-afd4-42fb-978a-b72eab0c07f9', N'Moving-the-MBR-to-another-DeviceHard-Disk', N'Moving the MBR to another Device/Hard Disk', N'<div>
	What is the MBR? It is the Master Boot Record - Its a clump of configuration data that is present in a well-known location on any Hard Disk, that is the first 512 bytes of the disk. Why do you need to move it? For a variety of reasons, in this case, it was necessary <font size="3">to move the MBR to another Hard Disk is because I bought a newer faster/bigger drive and installed better OS in it and want to format the old Hard Disk so you can store other data. I wanted the system to boot up even without the older drive.</font></div>
<div>
	&nbsp;</div>
<div>
	<font size="3">Every hard disk has an MBR (Master Boot Record) in its Sector 0 (1 sector = 512 bytes) - On a multiple hard disk system you have multiple MBRs and the BIOS Bootscreen shows the priority in which the devices are considered for checking for MBR.&nbsp;</font></div>
<div>
	&nbsp;</div>
<div>
	<font size="3">Usually your old hard disk willl contain an MBR, and new hard disks MBR will be missing. If you say, installed Windows 7 on the new Hard drive, you will still need the old hard disk as it contains the MBR that loads the Windows Boot Loader (which is also on the older hard drive) and this in turn bootstraps the Windows in the new Harddisk. So you wont be able to format the old Hard drive as it is the gateway to your OS on the new Harddisk. Other things you will observe in this scenario are - If you see the Computer Management screen (R-Click My Computer and click manage) - &gt; Storage -&gt; Disk Management you will observe the old Harddisk is marked as System and you can&#39;t format it as its disabled because it contains the MBR from which the OS booted from.</font></div>
<div>
	&nbsp;</div>
<div>
	&nbsp;</div>
<div>
	<strong><font size="3">Steps to move the MBR :</font></strong></div>
<div>
	&nbsp;</div>
<div>
	<font size="3">1) Get EasyBCD 2.0+ and go to Bootloader Setup. In the create Bootable External Media section select your new harddisks OS partition and click on Install BCD - Press OK in the confirmation dialog regarding selection of BCD store if it turns up. This step will create empty BCD file &amp; data on the new HardDisk itself, where you have the new OS (Windows 7 usually).</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">2) In the MBR Configuration Options, select Install the (Windows 7/ Windows XP) bootloader to the MBR, based on what OS is in the partition you selected in step 1. I recommend choosing Windows7 bootloader, even if you want only XP. This step will make the MBR in your new harddisk bootable and it will boot into window 7 bootloader or XP bootloader</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">3) Go to the Add New Entry tab and Add an entry for all the OSes you have, including the one in your new harddisk. This step is usually done only if you choose Windows &nbsp;bootloader in the previous step. Even otherwise do this no worries. This will show all the OS options while booting up.</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">4) Finally restart Go to BIOS boot priority and give the New harddisk 1st priority, or atleast higher priority than the old harddisk.</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">5) Optional - Format the old harddisk and do whatever you want with it - this will delete the bootable MBR on it.</font></div>
<div>
	<font size="3">&nbsp;</font></div>
<div>
	<font size="3">Cheers. Be sure not to FlusterCuck your Harddrives :</font></div>
', CAST(0x00009E6B012BED40 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'06623d98-527d-4b0f-b5cf-d69264b47295', N'Home-PC-v30', N'Home PC v3.0', N'<div>
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
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'42596445-0f08-486a-aeb5-a2688ca371b5', N'This-site-is-going-to-get-an-overhaul!', N'This site is going to get an overhaul!', N'<div class="entry">
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
		<img alt="" src="/Uploads/Images/OldSite.png" style="width: 602px; height: 536px;" /></p>
	<p>
		and the new one - you are looking at it one part of it, the other part is at <a href="http://zasz.me/">http://zasz.me/</a></p>
	<p>
		&nbsp;</p>
</div>
', CAST(0x00009E25011B7280 AS DateTime), N'Shared')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'f7e0e4ec-34eb-41d4-aebb-10bdfaf6daa4', N'BlizzCon-2010-!!', N'BlizzCon 2010 !!', N'Content', CAST(0x00009E1501788E70 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'68aba9c0-73ca-4bb0-9fa1-7a01a137ff5e', N'Blizzard-Starcraft-2-Patch-11-Woes', N'Blizzard Starcraft 2 Patch 1.1 Woes', N'Content', CAST(0x00009DFB01650E40 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'26678b12-e7d6-4f7c-957e-ed74ba71ef97', N'Charisma', N'Charisma', N'<div class="entry">
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
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'08af2ae7-1690-47f1-a3d6-82717fa6ca52', N'GWT-Library', N'GWT Library', N'<div class="entry">
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
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'b5e5f7bc-d84d-45fb-8c92-15beb9c0c490', N'Integrity', N'GWT - Testing ; GWT Renderers', N'<div class="entry">
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
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'26328f4c-998e-40f3-a944-d14c6ee919c2', N'Groovy-and-Grails-3d-GG', N'Groovy and Grails = GG', N'<p>
	I&#39;m currently involved in working on Groovy &quot;An agile dynamic language for the Java Platform&quot;, and on GWT &quot;Google Web Toolkit - Productivity for developers, performance for users&quot;. Groovy is pleasing to look at (more functionality per LOC), I&#39;m throwing code blocks into variables and passing them around (Closures). Methods are created and added @ runtime to classes, and a lot of other cool techniques are possible in Java Camp now. It has grown to the point where it can hold its own with clojure, scala, jython, jruby.</p>
<p>
	Grails is very pleasant to use (at first!) and is very similar to Rails, in the ability to getting a complete web app in minutes, and running it. Google&#39;s Gin and Guice along with spring&#39;s help made Dependency Injection very simple &amp; easy, Gin in Google Web Toolkit, and Guice in Server side code. Since all Java code is valid Groovy code, the learning curve for groovy is small, but the skill one needs to acquire is to know where to use the groovy code segments, so that maximum productivity is reached.</p>
<p>
	On the other side of the coin, IDE support is nowhere close to what Visual Studio does with LINQ and C#, Groovy builders are both the strength (expresses intent very well), and the weakness (no IDE support, and it looks like a code-cloud with words hanging everywhere, and takes time to wrap one&#39;s head around how to use it.)</p>
<p>
	For a grails application, if we want to follow the command pattern when client script needs server side functionality, I found that the gwt-dispatcher library in Google Code unsuitable. It does give a central clearing house where all service calls are made, but there is simply too much infrastructure. This infrastructure, I think, can be eliminated if Google decide to help implement command pattern with an extension of the existing RemoteServiceProxy, which BTW is also a central point where all service calls reach, and with some javascript prototype based extensions. Far simpler implementations can be written with groovy code, such as the one in my previous post that has an attachment - a zip containing a application that uses Gin , Guice, gwt-presenter, GWT, event bus architecture, command pattern. An very barebones example of server side grails service that follows the command pattern is :</p>
<pre class="brush:groovy;">
class GwtCommandPatternService implements InitializingBean
{
def clientCommands = new Hashtable()
def clientController = new ClientController()
def transactional = true

static expose = [&#39;gwt&#39;]

  Reply serve(Command command)
  {
    String name = command.getClass().getCanonicalName()
    println &quot;Command : &quot; + name
    Closure c = (Closure) clientCommands[name]
    return c(command) as Reply
  }

  def addClientCommand = 
  {String command, Closure c -&gt; clientCommands.put(command, c)}

  def void afterPropertiesSet()
  {
    addClientCommand(
             GetSuggestions.class.getCanonicalName(), 
             {command -&gt; clientController.index(command)}
    )
  } 
} 



</pre>
<p>
	The server side service has a synchronous serve method. It also has an internal table of Commands and Closures each closure serves the corresponding command. The closures may contain the serving logic themselves, or may delegate to action methods of different controllers. Note that I am implementing&nbsp;InitializingBean and populating the&nbsp;internal commands table in the interface defined method&nbsp;afterPropertiesSet. Here is a proof-of-concept code which exists on client side and makes use of the command pattern :</p>
<pre class="brush:groovy;">
public class CommandPipe
{

    private final Cache commandCache;
    private final CPService compatService;

    @Inject
    public CommandPipe(Cache commandCache, 
                       CPService compatService)
    {
        this.commandCache = commandCache;
        this.compatService = compatService;
    }

    public void serve(final Command command, 
                      GotCallback gotCallback)
    {
        Reply reply = commandCache.serve(command);
        if (reply != null)
        {
            reply.setFromCache();
            gotCallback.got(reply);
            return;
        }

      CommandPatternServiceAsyncCallback serviceAsyncCallback
      = new CommandPatternServiceAsyncCallback(
      command, gotCallback);
      compatService.serve(command, serviceAsyncCallback);
    }

    private class CommandPatternServiceAsyncCallback 
            implements AsyncCallback&lt;Reply&gt;
    {
        private final Command command;
        private final GotCallback gotCallback;
        public CommandPatternServiceAsyncCallback(
        Command command, 
        GotCallback gotCallback)
        {
            this.command = command;
            this.gotCallback = gotCallback;
        }

        public void onFailure(Throwable caught)
        {
            Window.alert(caught.toString());
        }

        public void onSuccess(Reply result)
        {
            commandCache.cache(command, result);
            gotCallback.got(result);
        }
    }
} 




</pre>
<p>
	The command pipe needs the Grails GWT service RPC interfaces injected into it. Using which it can then serve the client script generated commands. All the injection is done in the following Gin Module.</p>
<p>
	&nbsp;</p>
<pre class="brush:groovy;">
public class TheBindingsModule extends AbstractGinModule
{
    protected void configure()
    {
        bind(CommandPatternPresenter.Display.class)
              .to(CommandPatternView.class)
              .in(Singleton.class);
        bind(EventBus.class).to(DefaultEventBus.class)
                            .in(Singleton.class);
        bindConstant().annotatedWith(CacheSize.class).to(10);
        bind(Cache.class).to(FIFOCache.class);
        bind(CPService.class)
            .toProvider(CPServiceProvider.class)
            .in(Singleton.class);
        bind(CommandPipe.class).in(Singleton.class);
    }
} 

</pre>
<p>
	&nbsp;</p>
', CAST(0x00009CCF011A12F0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'8d62fc05-97a9-4aaa-8379-a41cce26b252', N'Gin-GWT-Command-Pattern', N'Gin GWT Command Pattern', N'<p>
	Here is a spike I did that integrates Gin, GWT, gwt-presenter, Grails. The objective of this being, do the libraries play well together, and how intuitive it is to work with them, and assess their maturity.<br />
	<br />
	Description of :</p>
<ul>
	<li>
		All requests from client javascript, come as objects of the Command Interface. They are served, intuitively enough, by Reply objects.</li>
	<li>
		Due to the above fact, it is possible to cache at the client side -&gt; the command and reply pairs , which has been implemented here using a FIFO Cache. (demonstrated as being faster, with the help of timers)</li>
	<li>
		Gin injects dependencies in the GWT code : the EventBus , the Service , the PlaceManager , the Cache. (LRU Cache is plugged in just by implementing one, and changing a line)</li>
	<li>
		An EventBus is used to wire-up events and handlers, thus providing clean seperation of View and Presenter.</li>
	<li>
		gwt-presenter Library is used to implement the entire client side code in MVP pattern.</li>
</ul>
<p>
	A few notes on the spike :</p>
<p>
	A standard Grails service is exposed as the GWT service (one of the reasons why Peter Ledbrook decided not to use gwt-dispatcher JAR) . It contains the Hashtable of Commands and Closures . The closures serve the corresponding commands, by redirecting to various controllers and their actions. Full application was built and run using Idea, and the console. You can avoid using the console altogether by using the extrenal tools option in (Ctrl-Alt-S) Settings dialog in Idea 8 and configuring all grails command as an external tool.<br />
	<br />
	The Grails Gwt Plugin has a few issues, it does not compile the source files on compile-gwt-modules command. It just runs the code to generate javascript files. The author of the plugin did not account for using Gin - Gin needs .class files to reflect upon, which must first exist before compile-gwt-modules command. Workaround is use IDE or run-app or run-gwt-client to compile when using Gin. Also run-gwt-client will not work until run-app is executed, because the hosted mode mock browser, also needs the Grails service, which is started only after run-app.<br />
	<br />
	A few undocumented points :</p>
<ul>
	<li>
		GwtPlugin looks for its dependancy jar files in lib/gwt directory when running compile-gwt-modules. IDEA looks for it in the lib directory.</li>
	<li>
		aopalliance-alpha1.jar available at http://sourceforge.net/projects/aopalliance/ is <span class="Bold">required</span> for guice and gin to run.</li>
	<li>
		While binding using Gin it is essential that the providers are singleton, and that there are no circular dependencies - 2 classes with constructors taking in each other as parameter</li>
</ul>
<p>
	Unzip and press Shift F10 run it. The plugins facility in grails make it really easy to get started on integrating with other tools and libraries. Gin is in the early development stages, but usable for simple DI on the client-side, and gwt-presenter may soon be integrated into GWT itself or Google may come up with its own MVP framework.<br />
	<br />
	<a href="/Uploads/Files/CommandPattern.7z" target="_blank"> CommandPattern.7z (912.46 kb)</a></p>
', CAST(0x00009CCF0114DB00 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'9ccc49e6-af13-43e5-b8b0-670af27a8960', N'Clan-Feeders-is-ONLINE', N'Clan Feeders is ONLINE', N'Content', CAST(0x00009CC800F61800 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'e0c5aece-6081-4d66-b34c-7c74a1c6beb8', N'New-Kind-of-Advertising--Spamming-around', N'New Kind of Advertising / Spamming around', N'<p>
	I can see a lot of blog posts on the internet with strange comments.</p>
<p>
	People while commenting on posts, are given the option of hyperlinking their name to their site/blog/mailid. Someone thought : Wow! I&#39;ll just write some generic comment on all posts on the internet, and link my name to my business. Also Ill specify my name as something like &quot;easy personal loans&quot; &nbsp;and link it to my site &quot;fastloansus.com&quot;</p>
<p>
	Talk about driving traffic to a site, there&#39;s no limit to their innovation. My only question is: Is this commenting process manual or automated? I suspect both, as lots of examples I have seen around the Net, are having comments whose content is sort of appropriate to the posts. Not just &quot;nice post&quot;, &quot;nice theme&quot;, etc. So it could very well be that the advertisers have a couple of people sitting around to browse the net and comment on posts. Boy talk about crappy jobs, I suspect there are some guys doing this @ freelancer.com, for money. Also there are bots, as evident by some of my audit logs, one bot in particular has a mistake in its user-agent string, efficient server-side filters could easily have saved my posts.</p>
<p>
	I saw some of these kind of comments on DotNetKicks.com before, and now they are not there anymore. They seem to have found a way to block all such comments&nbsp;probably by&nbsp;using blacklist of sites, and blocking comments that have a link to one or more of them. I will do the same if this becomes a serious problem, but until then let things be.</p>
<p>
	EDIT:</p>
<p>
	It did become a serious problem, and used Aksimet to clean existing comments, and wired up Disqus as a sheild against future spam. I will provide a link to Akismet here- they have done an outstanding service to the entire internet user base. <a href="http://akismet.com/">http://akismet.com/</a></p>
<p>
	&nbsp;</p>
', CAST(0x00009CC000BAC480 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'5c471a0d-9afb-470d-a2a0-361a21b8bb0d', N'Back-to-Chennai', N'Back to Chennai', N'Content', CAST(0x00009CBB0158F880 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'e3d45333-b48c-4ddd-ad78-0258b5e0d76a', N'Training-At-TWU', N'Training At TWU', N'<p>
	ThoughtWorks University training , is a very different &amp; profitable experience. Our batch of 14 people including a few international folks, have a diverse set of trainers from Netherlands, Australia, London, and from India. We have training at Hotel Royal Orchid, (very good food), and here are some photos during sessions.</p>
<p>
	Check the same photos on Facebook : <a href="http://www.facebook.com/photo.php?pid=2631903&amp;l=69d71df328&amp;id=815596121"><span>http://www.facebook.com/photo.php?pid=2631903&amp;l=69d71df328&amp;id=815596121</span></a></p>
<p>
	<img alt="" height="60%" src="/Uploads/Images/Image328.jpg" width="60%" /></p>
<p>
	&nbsp;My China Clay Phone developed over Evolving requirements</p>
<p>
	&nbsp;</p>
<p>
	<img alt="" height="60%" src="/Uploads/Images/Image329.jpg" width="60%" /></p>
<p>
	Ice Cream meter : |</p>
<p>
	&nbsp;</p>
<p>
	<img alt="" height="60%" src="/Uploads/Images/Image330.jpg" width="60%" /></p>
<p>
	Puzzles, Parking for questions and Accomplishments Post-its</p>
<p>
	&nbsp;</p>
<p>
	<img alt="" height="60%" src="/Uploads/Images/Image331.jpg" width="60%" /></p>
<p>
	After 2 weeks!</p>
<p>
	&nbsp;</p>
<p>
	<img alt="" height="60%" src="/Uploads/Images/Image332.jpg" width="60%" /></p>
<p>
	Agile Software development session. 4 iterations (A quick12 minute exercise).<br />
	Continuous Feedback and so on.</p>
<p>
	&nbsp;</p>
<p>
	<img alt="" height="60%" src="/Uploads/Images/Image333.jpg" width="60%" /></p>
<p>
	Our pizza delivery system... There can&#39;t be a training without one of this.</p>
<p>
	&nbsp;</p>
<p>
	<img alt="" height="60%" src="/Uploads/Images/Image334.jpg" width="60%" /></p>
<p>
	Classroom</p>
', CAST(0x00009C9B014C9C70 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'50a59416-94a6-4b6c-93e3-20a732a9ef0e', N'ThoughtWorks', N'ThoughtWorks', N'<p>
	Diamond District, Bangalore, @ ThoughtWorks Training.</p>
<p>
	Training is a set of fun activities, making new contacts, shopping, buffet in star hotels. Bangalore is colder than chennai, and I also live in a conditioned serviced apartment. And 4 outa 5 people do know tamil here, which is a welcome relief. Damn I do not have my digicam. Meeting some great people, and having a good time altogether. Looking for the gaming communities here, while getting familiar with all the infrastructure and admin stuff. Looks like being Dev is a hectic job, but ideal one. Found out a person can be overwhelmed by meeting excess contacts and necessity to remember all of them ^_^ !</p>
<p>
	Update : October 5</p>
<p>
	A few photos from the Mascal trip :</p>
<div align="center">
	<img alt="" src="/Uploads/Images/IMG_0827zz.JPG" /></div>
<div align="center">
	Me Setting Up Tent<br />
	<br />
	<img alt="" src="/Uploads/Images/IMG_0902zz.JPG" /></div>
<div align="center">
	Me Jumaring Ready</div>
<div align="center">
	<br />
	<img alt="" src="/Uploads/Images/IMG_0905zz.JPG" /></div>
<div align="center">
	Me Jumaring HalfWay<br />
	<br />
	<img alt="" src="/Uploads/Images/IMG_0908zz.JPG" /></div>
<div align="center">
	Me Jumaring&nbsp; TOP</div>
<div align="center">
	&nbsp;</div>
<div align="center">
	<img alt="" src="/Uploads/Images/IMG_2574.JPG" /></div>
<div align="center">
	Me Rappelling</div>
<div align="center">
	<br />
	<img alt="" src="/Uploads/Images/IMG_2612.JPG" /></div>
<div align="center">
	Frnds Priyanka, Soumya, Jake</div>
<div align="center">
	<br />
	<img alt="" src="/Uploads/Images/IMG_2557zz.JPG" /></div>
<div align="center">
	Group Click</div>
', CAST(0x00009C9100CAB2A0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'1255d6cf-9e3a-431d-9fb6-e4cae3a44115', N'ZaszzasZ', N'Zasz.zasZ', N'Content', CAST(0x00009C7F01342AA0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'1a915911-aa1f-4208-84c0-fad3efe1f371', N'I-want-to-see-BlizzCon-12', N'I want to see BlizzCon ''12', N'Content', CAST(0x00009C7B014AB040 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'125e4c56-3df6-441c-bd95-1b9b8da32988', N'End-of-Holidays-in-Horizon-(', N'End of Holidays in Horizon :(', N'Content', CAST(0x00009C6E00CAF8F0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'2fa5e985-0fa7-4a22-864c-2a956e02e406', N'Feeder-Friends', N'Feeder Friends', N'Content', CAST(0x00009C57015B7150 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'328fd77a-8172-4e88-8557-8104f06ad053', N'Graduated-!!', N'Graduated !!', N'Content', CAST(0x00009C500076A700 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'85a55607-dcf3-4862-94aa-bbcc99cd194e', N'Starcraft-2-Opts-out-of-local-Multiplayer', N'Starcraft 2 Opts out of local Multiplayer', N'Content', CAST(0x00009C3900A85D90 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'027ff70e-e505-4c38-960b-fa375c478c3a', N'Default-button-in-ASPNET', N'Default button in ASP.NET', N'<p>
	While working on my Login Page, I encountered an issue: there&#39;s a search box on top, with a Go button. Then there&#39;s the Login button in the Login control. So when I entered username and password and pressed enter key, the site acted as if i pressed the Go button. So I needed to make the Login button as default.<br />
	<br />
	The resolution was a less well known attribute hidden in the depths of the WebForms libraries :</p>
<pre class="brush:xml;">
&lt;asp:Button UseSubmitBehavior=&quot;false&quot; 
            ID=&quot;Button1&quot; runat=&quot;server&quot; 
            CssClass=&quot;go&quot; Text=&quot;Go&quot; 
            onclick=&quot;MasterSearchTextBox_Click&quot;&gt;
&lt;/asp:Button&gt;
</pre>
<p>
	A regular drag-dropped ASP.NET button looks like this:</p>
<pre class="brush:xml;">
&lt;asp:Button ID=&quot;btnAddChoice&quot; 
            runat=&quot;server&quot; 
            Text=&quot;Add&quot; 
   OnClientClick=&quot;AddToListBox(lbxChoices, txtChoiceName);&quot; /&gt;
</pre>
<p>
	render as</p>
<pre class="brush:xml;">
&lt;input type=&quot;submit&quot; 
       name=&quot;btnAddChoice&quot; 
       value=&quot;Add&quot; 
   onclick=&quot;AddToListBox(lbxChoices, txtChoiceName);&quot; /&gt;
</pre>
<p>
	So when I click on such a button, my JavaScript fires correctly but the page then submits - not what I want it to do.</p>
<pre class="brush:xml;">
&lt;asp:Button ID=&quot;btnAddChoice&quot; 
            runat=&quot;server&quot; Text=&quot;Add&quot;
     OnClientClick=&quot;AddToListBox(lbxChoices, txtChoiceName); 
     return false;&quot; 
     UseSubmitBehavior=&quot;false&quot; /&gt;
</pre>
<p>
	Renders the input control like I want it to, as a button:</p>
<pre class="brush:xml;">
&lt;input type=&quot;button&quot; name=&quot;btnAddChoice&quot; 
       value=&quot;Add&quot;
   onclick=&quot;AddToListBox(lbxChoices, txtChoiceName); 
            return false;__doPostBack(&#39;btnAddChoice&#39;,&#39;&#39;)&quot; /&gt;

</pre>
<p>
	Notice that &quot;return false;&quot; statement is necessary if you do not want postback. But in this case the go button needed the postback so I did not add the return false clause. However it is still a button and will postback but only when clicked on. And not when pressing enter key. A try with some javascript :</p>
<pre class="brush:jscript;">
function PressLogin()
      {        
        var loginbtn = 
        document.getElementById(
        &#39;ctl00_ctl00_CMDivMid_cphmain_ThonLogin_LoginButton&#39;);

        if(loginbtn == null)
        {
            alert(&quot;Please click on the 
         Login Button , Don&#39; hit the enter key!&quot;);            
        }
        else
        {            
            try{loginbtn.click();}
            catch (ex) { alert(&quot;Err&quot;); }
        }
        return false;
     }
</pre>
<p>
	and in the password text box :</p>
<pre class="brush:xml;">
&lt;asp:TextBox ID=&quot;Password&quot; runat=&quot;server&quot; 
             Font-Size=&quot;0.8em&quot; TextMode=&quot;Password&quot; 
    onkeypress=&quot;if(event.keyCode==13){PressLogin();}&quot;&gt;
&lt;/asp:TextBox&gt;
</pre>
<p>
	This allowed the login button to be clicked when pressing enter after typing password. This is somewhat partial resolution as the user may hit enter from the username textbox too, or defocus the password textbox before hitting enter key. With some more enhancements to this script, you can implement a default button for a page with a form. I am uncomfortable with getting the element by the generated ID, as it is something out of my control.</p>
', CAST(0x00009C2A00015F90 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'b13dcb60-bae7-459c-bb2c-8227260b2401', N'FEEDER-STORIES', N'FEEDER STORIES', N'Content', CAST(0x00009C2900D44F90 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'99f701a2-6dd0-4be2-9c24-a090f829446f', N'On-the-other-hand', N'On the other hand', N'Content', CAST(0x00009C2100D70EB0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'd2d8cecf-ec00-4b39-a329-64b59a308b7f', N'WTF-Sadness', N'WTF Sadness', N'Content', CAST(0x00009C1E01815870 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'cbfbbb9e-c44c-4820-ae8d-07c1dd253866', N'Bing!', N'Bing!', N'<p>
	&quot;Ever had trouble finding information online using a search engine? When what you thought was a simple search at first quickly spiraled out of control, leaving you buried in irrelevant and hard to find information? Don&rsquo;t worry, searchers - we feel your pain.&quot;</p>
<p>
	Introductory lines of the promotional video, that Microsoft is using to showcase its newest search engine called Bing!. It will still provide search results for any term an online user types into it, like regular search engines, But, Bing seems to be designed to provide a much richer search experience for people looking for information in four categories: shopping, travel, health and local businesses.</p>
<p>
	This could be an attempt to capitalize on the <a href="http://en.wikipedia.org/wiki/Vertical_search">&#39;Vertical Search Engine&#39;</a> - One that shows results categorically &amp; leverages ontologies and domain knowledge. Microsoft terms bing as a decision engine. It needs to do more than invent a new term brand to offset Google&#39;s 65% share slice of the search engine market pie. Anyway if Microsoft Bing does become popular Google will simply mimic all the popular features, and so will Yahoo. It is done all the time, mostly to Apple products.</p>
<p>
	By the way, Asp.net home site has degenerated to simply adding lame new videos and controls, so has javalobby. Whereas railsforzombies is quite new &amp; exciting, they have captured quite some attention.</p>
', CAST(0x00009C1900A1C610 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'82f59d51-4c39-49f5-a8e6-f715d9dcbe6f', N'Comedy-Family-Tree', N'Comedy Family Tree', N'Content', CAST(0x00009C0B01490A60 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'ec22ddb9-2f0c-4999-a64d-ae5d4b891822', N'About-Dota-660', N'About Dota 6.60', N'Content', CAST(0x00009C0B01411350 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'49060da5-50b0-4c6d-af18-82db258f3e7e', N'Defense-of-the-Pendragon---LOL', N'Defense of the Pendragon - LOL', N'Content', CAST(0x00009C0B013BDB60 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'318c9ca7-12b0-405c-9ddb-07a7ca19858e', N'Dota-660', N'Dota 6.60', N'Content', CAST(0x00009BF801598520 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'0e6a4379-87a3-42d1-bc81-10222da596d2', N'Cant-Wait2c-Im-Sorry', N'Can''t Wait, I''m Sorry.', N'Content', CAST(0x00009BBE00B3E6B0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'b72e5ac2-e8e0-4daf-9d30-7ccb9a2c6250', N'Play-DotA', N'Play DotA', N'Content', CAST(0x00009B9B00CDFE60 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'f60ea829-c453-469e-893f-a057b608a4d9', N'Greatest-Content-of-late-2008', N'Greatest Content of late 2008', N'Content', CAST(0x00009B7B010A24D0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'9fc1a794-23f6-433c-b752-8be71abe4d14', N'Pre-Fetching-Troubles-A-Good-Idea', N'Pre-Fetching Troubles? A Good Idea', N'<p>
	<u>A Point in Case :</u></p>
<p>
	In a standard ASP.NET application you have some stylesheet links in some aspx pages. These links further have links to images using the url(...) format. When the browser downloads these stylesheets, it assumes the url(...) constructs links within the stylesheet are relative to the path from which the stylesheet itself was downloaded. This is usually the case. Stylesheets are downloaded from a folder say &quot;GreenTheme&quot; and usually theres a folder called &quot;images&quot; within the &quot;GreenTheme&quot; folder and stylesheet has constructs like :</p>
<pre class="brush:css;">
background-color:url(&#39;images/bg.png&#39;)
</pre>
<p>
	This means that , these images , when requested by the browser are served by the IIS server itself. <strong>These requests do not go through the ASP.NET runtime at all.</strong> Requests from browser to server will be like : <em>http://www.yourdomain.com/GreenTheme/images/bg.png</em> which points to a valid file in the server directory structure and so IIS server can and does serve it, all by itself. Problem is it <strong>does not set required http headers that must be set if Image Pre-Fetching is needed.</strong></p>
<p>
	&nbsp;</p>
<p>
	<u>Why Pre-Fetch ?</u></p>
<p>
	Suppose you have a CSS segment like this:</p>
<pre class="brush:css;">
.classA {  background-image:url(a.png); }

.classA:hover{  background-image:url(b.png);  } 
</pre>
<p>
	When the mouse hovers over an element which belongs to this class, it must display a different image. Simple, ain&#39;t it? But you can observe a DELAY when you hover your pointer over the element for the first time. This is the time taken to request the new background image from the server.From the second time onwards - when you hover - there is no delay in showing the image because it has already been fetched and cached. With image spriting and CSS background-position property, you can resolve the hover effect problem, and pre-fetching is an alternative to this, that has the added advantage of not showing ugly, partially-rendered pages.</p>
<p>
	A lot of such elements, (or) Big background images, (or) A slow internet connection&nbsp; - any of these means that users will see the delay effect prominantly and your UI is not going to be well-thought-of at all by visitors. So if you pre-fetch these images, even the regular non-hover ones in a loading screen, or in a previous page using a script that uses idle time, you give visitors a better experience. We can use pre-fetching to show a loading screen [as in <strong>GMail</strong> - while inbox is loading] while images, scripts, and AJAXlets, and XML-XSLs&nbsp; are downloaded.</p>
<p>
	&nbsp;</p>
<p>
	<u>How to Pre-fetch?</u></p>
<p>
	I&#39;ve used a page that shows &quot;Loading... &quot; while in the background a script pre-fetches some images, scripts, and stylesheets. This script keeps track of the various &lt;img&gt; tags and &lt;link&gt; tags that each points to a resource that is tobe prefetched. When all the elements are loaded , we assume all the links/images they are pointing to are fetched, and so we can move on to the next page.</p>
<pre class="brush:xml;">
&lt;div style=&quot;visibility:hidden&quot;&gt;
&lt;img src=&quot;GreenTheme/images/bg.jpg&quot; onload=&quot;CountLoad()&quot;/&gt;
&lt;img src=&quot;GreenTheme/images/a.png&quot; onload=&quot;CountLoad()&quot;/&gt;
&lt;img src=&quot;GreenTheme/images/b.png&quot; onload=&quot;CountLoad()&quot;/&gt;
&lt;/div&gt;
</pre>
<p>
	CountLoad() simply updates a global counter variable as it is&nbsp; called each time, checking if the maximum is reached. For eg if you have 10 images and 2 stylesheets and 2 scripts to be pre-fetched, you use 10 &lt;img src=&quot;..&quot;&gt; tags , 2 &lt;link href=&quot;..&quot;&gt; and 2 &lt;script src=&quot;..&quot;&gt; tags in the approperiate places (like in a hidden div) and max=10+2+2=14 for mfun(). When all 14 elements are loaded, use location.href in javascript to redirect to another page. Sometimes it is necessary to set visibility:hidden through javascript on the contatiner &lt;div&gt; tag, because some browser versions may simply ignore elements within a div tag that is hidden.</p>
<p>
	&nbsp;</p>
<p>
	<u>If-Modified-Since problem</u> :</p>
<p>
	When I used a loading page for pre-fetching images required by another page (possibly the home page) I came across this strange problem. <strong>HttpAnalyser </strong>is a software that detects and hooks onto an Internet Explorer instance and logs &amp; shows all HTTP requests/responses that tke place between the browser and any server.</p>
<p>
	When I pulled up loading page, as expected, I saw requests for all the pre-fetcher links that was defined. Then I was redirected to a content aspx page (the page we redirected in the script using location.href). But what was not expected was the HttpAnalyser shows browser sending <em>If-Modified-Since</em> requests. For which the server replies <em>Not-Modified</em>, for all the pre-fetched images that occur in this page (for eg the Home page).</p>
<p>
	Even though I pre-fetched the images that occur in the home page, and those images that may be required when hovering , and scripts etc in the Loading Page itself, some additional HttpRequests for these resources are sent. Okay they are NOT downloaded again - becuase they were prefetched, but instead of directly using the cached copy of the prefetched images, the browser takes time to ask the server if <strong>pre-fetched copy in cache - has it been modified since it was downloaded?&nbsp;</strong> Whenever a same image that was downloaded for a page, is needed for another page, the browser asks this question to the server in the form of a <em>If-Modified-Since &lt;DateTimeObject&gt; </em>HttpRequest. The Server replies <em>Not-Modified </em>and then the Cached copy is used.</p>
<p>
	&nbsp;</p>
<p>
	<u>The WorkAround :</u></p>
<p>
	&nbsp;How do we eliminate this unnecessary if-modified-since request then? It is obviously not going to be necessay for us - coz stylesheet images, hover images and scripts are not going to be changed for a long time - and defenitely not in the short timespan between the display of the Loading Page and Home page. The Answer is the <em>Expires header.</em> What the server must do is : when sending the images that are requested in the pre-fetch load page, it must add a header called <em>Expires</em> to which it must assign a suitable value [im my case One Year]. This informs the browser that the images prefetched by it are not going to be modified for one year atleat. Its cached copies of those Hover images etc expires only after one year or so. So it does NOT send<em> If-Modified-since requests </em>when prefetched images (prefetched in Loading Page) are referred to from the Home Page or Other Pages.</p>
<p>
	&nbsp;</p>
<p>
	<u>How to WorkAround ?</u></p>
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
background-color:url(&#39;images/bg.png&#39;)
</pre>
<p>
	This way all the browser requests will be like</p>
<p>
	<em>http://www.yourdomain.com/GreenTheme/images/CssImage.ashx?name=bg.png</em></p>
<p>
	<em>http://www.yourdomain.</em><em>com</em><em>/RedTheme/images/CssImage.ashx?name=bg.png</em></p>
<p>
	instead of</p>
<p>
	<em>http://www.yourdomain.</em><em>com</em><em>/GreenTheme/images/bg.png</em></p>
<p>
	<em>http://www.yourdomain.</em><em>com</em><em>/RedTheme/images/bg.png</em></p>
<p>
	If the stylesheets contain links as specified above, the server has no choice but to handover the ashx requests to ASP.NET runtime, thus our C# class coresponding to the CssImage.ashx file&nbsp; will serve the images <em><strong>WITH&nbsp; </strong></em>the caching headers such as EXPIRES and LOCATION in place. Values may also be set approperiately in code for these headers. Thus modifying the stylesheets by hand to change the contents of url(..) clauses, will solve our problem , but has side effects such as :</p>
<p>
	<span class="Underline">Loss of Designer Support</span> :</p>
<p>
	Having urls like :</p>
<pre class="brush:css;">
background-color:url(&#39;images/CssImage.ashx?name=bg.png&#39;)  
</pre>
<p>
	in style sheets in Visual Studio will result in loss of designer support. During design time you can&#39;t use the WYSIWYG editor, not many folks I know use it, but there is a means of working around this too.</p>
<ol>
	<li>
		Create CssImage.ashx files in all the css image directories and poin them to our CssImagHandler C# class as instructed before but do NOT modify the stylesheet urls.&nbsp;</li>
	<li>
		Create a HttpHandler that serves stylesheets. This new handler serves stylesheets (.css files) after modifying the contents - changing all the url(images/xx.jpg) to url(images/CssImage.ashx?name=xx.jpg) whenever serving, using regexes. Also this handler can be used to set the caching headers and policies for the .css files themselves providing further boost in performance.</li>
	<li>
		Put this handler(.ashx file) in all places where there are stylesheet. Again we have multiple ashx files pointing to the same class, so we have to seperate the class coding and the ashx file itself. ( For eg. Put the new Css.ashx file copies in &quot;GreenTheme&quot; and &quot;RedTheme&quot;) We need multiple ashx files because links within the stylesheet are relative to the path from which the stylesheet itself was downloaded.</li>
	<li>
		Now we have a handler that modifies stylesheet url contents, so that the urls point to a handler that handles image requests. In both handlers we set caching headers and policies.</li>
	<li>
		<strong>Don&#39;t do this</strong> : If we change the &lt;link&gt; tags in our aspx pages from <em>&lt;link href=&#39;GreenTheme/style.css&#39; rel=&#39;stylesheet&#39; ... /&gt;</em>&nbsp; to <em>&lt;link href=&#39;GreenTheme/Css.ashx?name=style.css&#39; rel=&#39;stylesheet&#39; ... /&gt;</em> then this results in loss of designer support. The designer looks for link tags and automatically applies the stylesheet. Having&nbsp; <em>GreenTheme/Css.ashx?name=style.css</em> in the link tag is not understood by the designer.</li>
	<li>
		Do This : Instead what we do is leave the link tags unchanged, but write code in <strong>Page_Load</strong> or <strong>OnLoad</strong> handler to change the link tags <em>&lt;link href=&#39;GreenTheme/style.css&#39; rel=&#39;stylesheet&#39; ... /&gt;</em>&nbsp; to <em>&lt;link href=&#39;GreenTheme/Css.ashx?name=style.css&#39; rel=&#39;stylesheet&#39; ... /&gt;</em></li>
	<li>
		Thus we make sure that during the request these things happen dynamically at runtime
		<ul>
			<li>
				That link tags are modified to make the stylesheets pass through the stylesheet handler,</li>
			<li>
				which makes sure that urls in the stylesheets it serves, are modified to make the images be requested through the image handler,</li>
			<li>
				both the handlers setting Client &amp; Server Caching policies and headers,</li>
			<li>
				and we don&#39;t lose designer support because handlers do their job at runtime, when they are requested.</li>
			<li>
				From the designer&#39;s perspective the link tag hrefs &amp; targets are parsable. And the stylesheets url(...) links are also pointing to valid images.</li>
		</ul>
	</li>
</ol>
<p>
	So the functionality of the stylesheet handling class will be</p>
<ul>
	<li>
		Get the name of the stylesheet of the querystring</li>
	<li>
		Look for the file in the same directory as the ashx file, because we put stylesheet-handling ashx files in all directories containing stylesheets.</li>
	<li>
		For the previous step we can use the Request.Path property to get path of current request (that is the request to the Css.ashx file, when browser sees the modified &lt;link&gt; tags)</li>
	<li>
		Using that as a string, substringing to uptotheLastIndexOf(&#39;\&#39;) we get the directory where the Css.ashx file and the .css file itself is to be found.</li>
	<li>
		Append&nbsp; &lt;name(from QueryString)&gt;.css to the working string got from the prevoius step and use File Reader to read in contents of the stylesheet</li>
	<li>
		Use Regular Expressions or the logic I usedto Modify the url(..) clauses and send the string to Server Cache and Response stream</li>
	<li>
		Insert code in the beginning of the class that checks if modifies stylesheet is in&nbsp; the cache. If present, just send the server-side cached copy.</li>
</ul>
<p>
	All of the above concepts have implemetations in&nbsp;<a href="http://chandruon.net/Downloads/Assembly.zip">https://github.com/chandru9279/StarBase/tree/master/Websites/Thon.NET/</a>. Look at CssImage.ashx and Image.ashx and Css.ashx and the classes to which they are pointing to. <a href="http://www.ieinspector.com/httpanalyzer/">http://www.ieinspector.com/httpanalyzer/</a> Here you can get the tool and check all this out for yourself. Firebug and Firefox will also do the job.</p>
', CAST(0x00009B5500BEE330 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'5c6804a8-1ffe-4204-8fc1-d2ce13f2e62f', N'Nested-MasterPages-seems-to-have-an-egg-or-two', N'Nested MasterPages seems to have an egg or two', N'<p>
	Nested Master Pages in ASP.NET has does not have some functionality that one would intuitively expect. I setup an application yesterday, as follows : Has a Master Page - SiteMaster.master, and a content page for it - Default.aspx, with a ContentPlaceHolder in the &lt;head&gt; section of the master page. The idea being, content pages can add their own stylesheet links, and each content page needs a different stylesheet.</p>
<p>
	I encountered an issue when using Page.Header.Controls property, in the code-behind of a http module which shows only the controls in the head section of the master page SiteMaster.master. We cannot access the controls of the head that are inside the content part of the content placeholder, in the Default.aspx page. In the case of nested Master Pages, with ContentPlaceholders in &lt;head&gt; section, then Page.Header.Controls exposes only the controls in the &lt;head&gt; tag that must be present in the outermost, most general master page. In either of these cases, If we try to skip head altogether and define the head tag in the asp:content of the content pages, then the Page.Header property simply becomes null.</p>
<p>
	I ended up removing the placeholder in the head, and writing the &lt;head&gt; section with all the possible link tags that can possibly come in there, with Visibility=&rdquo;False&rdquo;, so the tag won&#39;t be rendered into the html sent to the browser, and grouped them. And then used the Page.Header.Controls as follows, in the Code-Behind of the MasterPage:</p>
<pre class="brush:xml;">
&lt;head&gt;

&lt;%-- forDefault.aspx --&gt;
&lt;link  href=&quot;..&quot; rel=&quot;..&quot; runat=&quot;server&quot;
       ID=&quot;Def1&quot; Visibility=&quot;False&quot;&gt;


&lt;%-- forLinkz.aspx --&gt;
&lt;link href=&quot;..&quot; rel=&quot;..&quot; 
      runat=&quot;server&quot; ID=&quot;Lin1&quot; /&gt;

&lt;/head&gt;
</pre>
<p>
	and the code behind :</p>
<pre class="brush:csharp;">
protected void Page_Load(object sender, EventArgs e)
{
string check;
if(Request.Path.Contains(&ldquo;Default.aspx&rdquo;))
check = &ldquo;Def&rdquo;;

if(Request.Path.Contains(&ldquo;Linkz.aspx&rdquo;))
check = &ldquo;Lin&rdquo;;

/* any more links and you will need a map 
    instead of an if-else ladder */

foreach(Control c in Page.Header.Controls)
{
  if(c.ID.StartsWith(check, 
           StringComparison.InvariantCultureIgnoreCase))
  c.Visibility=true;
}
}
</pre>
<p>
	Another method is by using the scriptlets as suivantes:</p>
<pre class="brush:xml;">
&lt;head&gt;

&lt;%if(Request.Path.Contains(&ldquo;Default .aspx&rdquo;)) { %&gt;
&lt;link href=&quot;..&quot; rel=&quot;..&quot; runat=&quot;server&quot; ID=&quot;Def1&quot; 
            Visibility=&quot;False&quot; /&gt;
&lt;meta runat=&quot;server&quot; ID=&quot;Def2&quot; /&gt;
&lt;% }%&gt;

&lt;%if(Request.Path.Contains(&quot;Linkz.aspx&quot;)) { %&gt;
&lt;linkhref=&quot;..&quot; rel=&quot;..&quot; runat=&quot;server&quot; ID=&quot;Lin1&quot; /&gt;
&lt;meta runat=&quot;server&quot; ID = &quot;Lin2&quot; /&gt;
&lt;% }%&gt;

&lt;/head&gt;</pre>
<p>
	&nbsp;</p>
', CAST(0x00009B5500BD83A0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'a921264e-82dd-41b6-adf4-cd92ee8337a4', N'Essential-Tip-for-any-ASPNET-developer', N'Essential Tip for any ASP.NET developer', N'<div class="entry">
	<p>
		Just found out why my site is slow in loading. Asp.NET renders many &lt;script src=&quot;...&quot; /&gt; tags. Each time this tag is encountered by the browser, it sends a HTTP GET request to the server for fetching the resource. This causes the slowdown. We can instead combine all these requests into one request which delivers all the js files a page needs. See this video : <a href="http://www.asp.net/learn/3.5-SP1/video-296.aspx" title="ASP.NET Video">http://www.asp.net/learn/3.5-SP1/video-296.aspx</a>&nbsp; and <a href="http://msmvps.com/blogs/omar/archive/2008/05/10/fast-asp-net-web-page-loading-by-downloading-multiple-javascripts-in-batch.aspx">http://msmvps.com/blogs/omar/archive/2008/05/10/fast-asp-net-web-page-loading-by-downloading-multiple-javascripts-in-batch.aspx</a>. My homepage itself had about 42 &lt;script src=&quot;.....&quot; /&gt; tags rendered, which translated to 42 HTTP GET requests in addition to the images and stylesheets links (about 20 more )..Duh! Also check out the YSlow Firfox Plugin that allowed me find this problem out.</p>
	<p>
		Update (11/5/2011):</p>
	<p>
		While it is necessary to batch the http requests, it is important not to introduce any security flaws while doing so. A batching handler will often take input as a get request with filename in QueryString, and serve that file. Such handlers inadvertantly bring in a huge security issue, if some sort of permission check is not done on the files being served by the batching handler. I once found this flaw in a production level commercial website : They had a batching servlet that served anything you asked for, including web.xml, struts.xml, .class files and so on. The check to see if only allowed files are going out was absent in their implementation. It was a matter of figuring out what technology they used (I saw urls ending with .action - so struts!) and what project structure (looked at the file system structure of an example struts project) and making a simple get request.</p>
	<p>
		Update (16/6/2011):</p>
	<p>
		Those links above are no longer valid as ASP.NET took out all the free videos and now they are charging for seeing them. You can find many Image spriting frameworks out there that can take care of image requests, script batching AJAX Control Toolkit extension is also available, and GWT does a good job of taking care of batching with Image Bundling, CSS Bundles and so on.</p>
</div>
', CAST(0x00009B17013C6800 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'1b166078-c6b7-4b76-8d78-7cb46d794912', N'USB-Guard', N'USB Guard', N'<p>
	Every USB drive I handle seems to have been plagued with viral files that use the autorun feature to install itself on my system. These viral files are of course system files and hidden files, so not visible on simple open in explorer.</p>
<p>
	<span class="Underline">To enable the viewing of Hidden files follow these steps</span>:<br />
	<br />
	Close all programs so that you are at your desktop.<br />
	Double-click on the My Computer icon.<br />
	Select the Tools menu and click Folder Options.<br />
	After the new window appears select the View tab.<br />
	Put a checkmark in the checkbox labeled Display the contents of system folders.<br />
	Under the Hidden files and folders section select the radio button labeled Show hidden files and folders.<br />
	Remove the checkmark from the checkbox labeled Hide file extensions for known file types.<br />
	Remove the checkmark from the checkbox labeled Hide protected operating system files.<br />
	Press the Apply button and then the OK button and shutdown My Computer.<br />
	Now your computer is configured to show all hidden files.</p>
<p>
	Now that you can see the presence of the nasty EXEs, some even have an icon similar to the windows folder icon. They hide the regular folders, and impersonate the folders with the folder icons. If you double click them by mistake, trying to open the folder, you end up running them, and you can kiss goodbye to your OS and plan a day for reformatting the disk &amp; OS.</p>
<p>
	<span class="Underline">To turn off autorun, which is sometimes responsible for running those EXEs</span>:</p>
<p>
	Click on Start --&gt; Run and type in &ldquo;gpedit.msc&rdquo; and press &ldquo;Enter&rdquo;. Then you will open &ldquo;Group Policy&rdquo;. There you will select User Configuration --&gt; Administrative Templates --&gt; System --&gt; and there you will double click on&nbsp; &ldquo;Turn Off Autoplay&rdquo; and in the window there you should select &ldquo;Enabled&rdquo; and select &ldquo;All drives&rdquo;.</p>
<p>
	<span class="Underline">Deleting the executables</span>:</p>
<p>
	If a file has both the hidden and system attributes set, an attempt to remove only one of the attributes fails with one of the below error messages. For example, if the file C:\ONE.TWO is marked as both system and hidden, the command(s)\</p>
<p>
	c:\dos\attrib c:\one.two -h<br />
	c:\dos\attrib c:\one.two -s</p>
<p>
	produce the respective error messages:</p>
<p>
	Not resetting system file C:\ONE.TWO<br />
	Not resetting hidden file C:\ONE.TWO</p>
<p>
	To remove either attribute, use the following command to remove BOTH attributes at the same time:<br />
	c:\dos\attrib c:\one.two -s -h</p>
<p>
	If necessary, you can use the following command to remove the read-only, system, and hidden attributes simultaneously:<br />
	c:\dos\attrib c:\one.two -s -h -r</p>
<p>
	You can check if your pen drive has viruses by, going to the command prompt, <strong>cd </strong>ing to the pen drive, and checking whether a certain <strong>autorun.inf</strong> file is present. If present type autorun.inf in the prompt to see what <em>particular file(s)</em> is given in it. All the <em>particular file(s) are viruse(s)&nbsp; </em>unless you know for sure that they are&#39;nt. You can delete them using the <strong>attrib -s -h -r &lt;filename or folder name&gt;</strong> command, and the <strong>erase/a </strong>command, and the <strong>del/a</strong> &amp; <strong>rmdir - S </strong>commands.</p>
<p>
	&nbsp;</p>
<p>
	Update:</p>
<p>
	These are the XP times. Windows Vista and 7 resolved quite a few of these issues, autorun first among them.</p>
', CAST(0x00009B10017B93E0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'd9e19ad1-6823-4ad7-8a7b-a65599f30d46', N'Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61', N'Getting started with Apache Struts 2 , with Netbeans 6.1', N'<p>
	There are plenty of guides that tell you how to start with struts 2, but most of them are incomplete or don&rsquo;t work. This guide even makes sure you have IDE JavaDoc support for struts 2 libraries. (Press Ctrl-Space to get details about methods and classes in struts 2 libraries)</p>
<p>
	<strong>Download Struts 2 here</strong> : <a href="http://struts.apache.org/download.cgi" target="_blank">http://struts.apache.org/download.cgi</a></p>
<p>
	Download the Full Distro, so that we get all libraries and docs. (docs are important if u want to have IDE support help and tooltips and syntax)<br />
	Full Distribution: struts-2.0.11.2-all.zip (91mb) [PGP] [MD5]<br />
	<br />
	As of this writing , this is the latest version of Struts.<br />
	<br />
	<strong>Download Netbeans 6.1 here</strong> : <a href="http://www.netbeans.org/downloads/" target="_blank">http://www.netbeans.org/downloads/</a><br />
	<strong>or here</strong> : <a href="http://dlc.sun.com.edgesuite.net/netbeans/6.1/final/">http://dlc.sun.com.edgesuite.net/netbeans/6.1/final/</a><br />
	<br />
	Download the full bundle (under the All column) size about 220 MB. Choose a folder for all your JAVA material that has NO SPACES in its path. Like C:\Java. &ldquo;C:\Program Files&rdquo; has a space, so it has some issues with the Sun Application Platform, which you might need after development.<br />
	<br />
	<span class="FontLarger"> </span><font size="2"><span class="FontLarger"><strong>Other downloads </strong></span>:</font><br />
	<br />
	[These are not necessary now, but just download them while working on this guide]<br />
	<br />
	<em>1. Eclipse for JavaEE Dev</em> : <a href="http://www.eclipse.org/downloads/">http://www.eclipse.org/downloads/</a><br />
	<br />
	Eclipse IDE for Java EE Developers (163 MB)<br />
	<br />
	<em>2. Java Application Platform</em> : <a href="http://java.sun.com/javaee/downloads/index.jsp" target="_blank">http://java.sun.com/javaee/downloads/index.jsp</a><br />
	<br />
	App Platform + JDK<br />
	<br />
	<em>3. Java Standard Edition [SE]</em> : <a href="http://java.sun.com/javase/downloads/index.jsp" target="_blank">http://java.sun.com/javase/downloads/index.jsp</a><br />
	<br />
	JDK 6 Update 7<br />
	<br />
	<font size="2"><span class="FontLarger"><strong>Install as follows </strong></span>:</font><br />
	<br />
	This is a Java EE setup that has worked very well for me. You can install anywhere, but the Guide will use these assume, that this is how you&#39;ve installed things.</p>
<ol>
	<li>
		Install Java SE (JDK 6 Update 7) to C:\Java\jdk1.6.0_07 and the packaged Java Runtime Environment (Public JRE) to C:\Java\jre1.6.0_07 Note : No Spaces in the path</li>
	<li>
		Extract struts-2.1.2-all.zip to C:\Java . This will create a folder C:\Java \struts-2.1.2</li>
	<li>
		Install Netbeans 6.1 to C:\Java\NetBeans6.1 .[ Note: There is no space in the path]</li>
	<li>
		Along with the Apache Server packed with netbeans, you need to press the customize or advanced button to install the packaged apache server, and to set your own path.</li>
	<li>
		After Netbeans , the packaged apache server will ask for path give C:\Java ApacheTomcat6.0.16 Note: No Space here also.</li>
</ol>
<p>
	My comp is set up like this :<br />
	<br />
	C:\Java\ ApacheTomcat6.0.16&nbsp; - from netbeans-6.1-ml-windows setup<br />
	<br />
	C:\Java\ NetBeans6.1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; - from netbeans-6.1-ml-windows setup<br />
	<br />
	C:\Java\ jdk1.6.0_04&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - from jdk-6u4-windows-i586-p setup<br />
	<br />
	C:\Java\ jre1.6.0_04&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - from jdk-6u4-windows-i586-p setup<br />
	<br />
	C:\Java\ struts-2.1.2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - from struts-2.1.2-all.zip extract<br />
	<br />
	C:\Java\ Eclipse&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - from eclipse-jee-ganymede-win32 setup<br />
	<br />
	C:\Java\ AP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - from java_app_platform_sdk-5_05-windows setup<br />
	<br />
	C:\Java\glassfish-v2ur2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - from java_app_platform_sdk-5_05-windows setup<br />
	<br />
	C:\Java\Nwork&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Netbeans WorkSpace<br />
	<br />
	C:\Java\Ework&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -Eclipse WorkSpace<br />
	<br />
	C:\Java\ StrutsBlank&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -Contents of struts2-blank-2.1.2.war file<br />
	<br />
	I Created my POJOs i.e Plain Old Java Objects &ndash; Business model classes and helper classes in Eclipse, just to know whats there in the IDE, and compiled them to JAR files. Then I used these JARs in the WebApplication fully done in NetBeans. But leave that, we&rsquo;ll see how to set up struts 2 and netbeans, fully dev-ready.<br />
	<br />
	Create a new Web Application in NetBeans<br />
	<br />
	File-&gt; New Project..-&gt; Category:Web -&gt; Projects:Web Application<br />
	<br />
	Choose Java EE5 as the Java EE Version, and Apache Tomcat 6.0.16 as the Server (which we installed from the netbeans setup itself) If the server is not there Add it, choosing the path C:\Java\ApacheTomcat6.0.16 as the home directory of the server. DO NOT ADD ANY Frameworks like struts of JSF now, you can add &lsquo;em later. Click Finish.<br />
	<br />
	Go to <strong>C:\Java\ struts-2.1.2\apps</strong> folder. Open WinZip. Drag - Drop the struts2-blank-2.1.2.war onto the WinZip window. Press the Extract button on the top of the WinZip window and extract to <strong>C:\Java\StrutsBlank</strong> . You must type this in cause &ldquo;StrutsBlank&rdquo; is a folder WinZip will have to create to place the contents of the WAR file. Come back to NetBeans, Go to Tools-&gt; Libraries, Click on <strong>New Library..</strong> button<br />
	<br />
	Type in &ldquo;Struts2Library&rdquo; as name and Press OK. Then Press <strong>Add JAR/Folder.. </strong>button and in the open file dialog , navigate to <strong>C:\Java\StrutsBlank\WEBINF\lib </strong>Select all the JAR files in there pressing the SHIFT key, and add &lsquo;em. Go to Javadoc Tab, Press <strong>Add Zip/Folder button</strong> and in the Open Folder Dialog navigate to <strong>C:\Java\struts-2.1.2\docs\struts2-core</strong> and select apidocs folder and click <strong>Add Zip/Folder</strong> button in the dialog.<br />
	<br />
	Press <strong>Ok</strong> that closes the Library Manager dialog box. Now Right Click the Libraries folder in the Projects window in the netbeans IDE, select <strong>Add Library.. </strong>and add the Struts2Library. Navigate to <strong>C:\Java\StrutsBlank </strong>in windows explorer and Drag-Drop the <strong>C:\Java\StrutsBlank\example</strong> folder into the NetBeans Web Pages treenode. Delete the <strong>Web Pages\WEB-INF\web.xml</strong> in netbeans. Drag-Drop the <strong>C:\Java\StrutsBlank\WEB-INF\web.xml</strong> file into the <strong>NetBeans Web Pages\WEB-INF</strong> treenode. Delete the <strong>Web Pages\ index.html</strong> in netbeans. Drag-Drop the <strong>C:\Java\StrutsBlank\index.html</strong> file into the NetBeans Web Pages treenode.<br />
	<br />
	Right-Click the Source Packages treenode in NetBeans, and New-&gt;Java Package, and type in &ldquo;example&rdquo; as the package name. This name is necessary to allow the blank app to get working. Drag-Drop all the 6 files in <strong>C:\Java\StrutsBlank\WEB-INF\src\java\example</strong> onto the <strong>Netbeans Source Packages\example</strong> treenode. Drag-Drop the 2 XML files in <strong>C:\Java\StrutsBlank\WEB-INF\src\java example.xml and struts.xml</strong> to the <strong>Source Packages</strong> treenode[ such that they come under the default package]. Thus we have moved all XML and .jsp and .java files from blank app to netbeans. After all that your<br />
	Project Explorer will belike : [see image in the PDF; download the PDF using the link provided at the top of this post]<br />
	<br />
	Build using F11 key.<br />
	<br />
	NetBeans will have created two folders for you <strong>build</strong> and <strong>dist</strong>. <strong>build\web\WEB-INF\lib</strong> and <strong>build\web\WEB-INF\classes</strong> are automatically created and populated with the JAR files and .class files. <strong>dist</strong> will have the WAR file that you can use to distribute your web app.</p>
<p>
	Run using F6 key to see the output.</p>
<p>
	If any error while building or running, Save everything, close netbeans AFTER closing the server by pressing the green square stop button in the serve tab of the netbeans IDE. Then go to task manager close all java.exe process and any and all server process also and reopen netbeans and press f6. I localized to Tamil. You should see Spanish instead of Tamil in the output.</p>
<p>
	Same post with Images in PDF Format :<a href="/Uploads/Docs/Getting+started+with+Apache+Struts+2.pdf" rel="enclosure">Getting started with Apache Struts 2 and Netbeans 6.1 in Windows.pdf (1.05 mb)</a></p>
', CAST(0x00009B0C015EBD10 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'ffbbd08d-073d-48ed-8fb6-7ac6ab31d365', N'ReBlog--Has-Google-Blundered-with-the-Gmail-Beta', N'ReBlog : Has Google Blundered with the Gmail Beta?', N'<p class="content">
	The traditional business model of webmail providers worked by squeezing the storage quotas of the free users of the webmail service, and forcing users to upgrade to a premium service. Someone at Google realized that earning money from webmail by selling premium services was always going to be a tough ask, and an alternative business model was needed. The idea he/she came up was to focus on pushing targeted ads to the users of the webmail service. The idea is brilliant in its simplicity. All an email provider needs to do is to scan the message the user has asked to be displayed for keywords, and display some relevant ads along with it; the ad clicks come automatically.</p>
<p class="content">
	While developing this idea the Google people also realized that the new business model did not depend on squeezing the storage quotas of the users. The people at Google calculated that storage quotas of 1GB and more can be offered without an inordinate amount of expense. A whole Gigabyte of storage space for webmail was almost unthinkable at the time Google conceived of the idea. It would have been a massive marketing coup for Google&#39;s new webmail service had the company offered such a storage quota to the mainstream user. Google did combine the two big insights it had, and several other innovations into its Gmail service. Gmail seems to be everything the users want. It offers users a large storage quota, has excellent email search capabilities, and incorporates a number of usability enhancements such as threaded discussions, and labels for grouping emails. Unfortunately, Gmail is still in beta and the average person can&#39;t sign up for the service.</p>
<p class="content">
	While Gmail is in beta its competitors are busy copying its features. The massive storage quota of Gmail must have really scared Yahoo and Hotmail, so this was the first thing they copied. As of now Yahoo is offering 100 MB quotas on its free email accounts, and Hotmail is offering 250 MB. This is quite a big change from the paltry 4 MB and 2 MB quotas Yahoo and Hotmail were offering previously. Gmail&#39;s competition is not trying to beat Gmail, but is only interested in avoiding a mass exodus of users. The well-established webmail players understand that switching a primary email address is a non-trivial task for any user. A user has to inform all of his/her contacts of the new email address, and even after doing that email just keeps on coming at the old email address. By offering larger quotas Gmail&#39;s competition is trying to reduce the incentive of users to switch to Gmail. Gmail&#39;s competitors certainly won&#39;t stop at storage quotas; it is safe to assume that most of Gmail&#39;s innovations will be incorporated into competing webmail services even before Gmail comes out of beta.</p>
<p class="content">
	Gmail&#39;s beta was most likely a poorly planned exercise in market research. Google was interested in monitoring the behavior of Gmail users, and collecting data about ad click rates, searching habits, storage use, etc. Unfortunately, all of Google&#39;s data collection will be useless, as the typical Gmail beta-tester is likely to be much more loyal to Gmail than the typical user which signs up after the beta. When Gmail finally comes out of the beta, users will certainly sign up in droves, but many of these users will only use Gmail as just another email account. With all the catching up Gmail&#39;s competition is doing, users simply won&#39;t have sufficient incentive to make Gmail their primary email address. This will translate into less ad clicks, lower revenue, and less profitability for Gmail. Had Google introduced Gmail without giving Gmail&#39;s competitors time to clone Gmail&#39;s functionality, a big fraction of web-mail users would have switched wholesale to Gmail. Gmail&#39;s competitors would have been caught unprepared. Many of them would have panicked and done stupid things to stem the exodus of users to Gmail. Fortunately for them, Gmail&#39;s beta gave everyone ample breathing room.</p>
<p class="content">
	Companies do betas because they expect a beta-tested product to yield more profits: better products typically lead to more sales and revenue. Unfortunately, Gmail&#39;s beta has done more harm than good to Gmail&#39;s prospects, and thus has been contradictory to the goals of a beta. Public betas are always a compromise between increasing the robustness of a product/service, and divulging product functionality and business plans. In some situations public betas are unavoidable. Microsoft has to release betas of Windows to developers, and a wide userbase in order to produce a usable version of Windows. By doing alphas and betas Microsoft is inviting its competitors to copy upcoming Windows functionality. In case of Longhorn, Linux developers are certainly picking and choosing functionality. A lengthy beta makes sense for Longhorn as Linux developers will not be able to clone all of Longhorn&#39;s core functionality before Microsoft releases a final version. However, Gmail just doesn&#39;t have the kind of sophisticated functionality which requires years of development effort to duplicate. If Hotmail&#39;s creators had done what Google has done, there would be no Hotmail today. Other companies would have seen Hotmail&#39;s potential and introduced competing web-mail services to snag users before Hotmail could.</p>
<p class="content">
	The most sensible course of action for Google was to do no beta or a very short beta. A couple of weeks of beta-testing would have sufficed for the level of functionality Gmail is offering. For market research, the company should have relied on some alternative means or preferably skipped the market research altogether. After all there aren&#39;t many startups who would delay their product 6 months to collect some questionable statistics. Another option for Google was to do a limited beta, but do it in a way to mislead its competition. Google could have started the beta with a 10 MB storage quota for Gmail with the final release version of the service offering 1 GB. Of course, no one outside of Google was to be told of Google&#39;s intent to offer 1 GB in the final version of the service.</p>
<p class="content">
	Unfortunately, the damage has been done, and these options are irrelevant to Google. Google can try to surprise its competitors by introducing significant new functionality in the final release of Gmail. But, the company seems to have played its best cards, and a radical revision of Gmail is unlikely. Gmail has certainly transformed the web-mail scene, and it will be a definite success. However, Gmail could have done much much better, and there are some important lessons to be learned. Companies must keep in mind that there are drawbacks to betas and ignoring the drawbacks can have disastrous consequences.</p>
', CAST(0x00009B070101A120 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'f5f7cdfe-13f2-44b5-b42b-6cc1511f78ed', N'Browser-2-0-Part-I', N'Browser 2.0 - Part I', N'Content', CAST(0x00009AF10125E260 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'3da89d74-6e62-46d0-9d05-ee1f0e48a974', N'Fact-and-Fiction', N'Fact & Fiction', N'Content', CAST(0x00009AED00D98780 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'b09b7298-a7c9-4baf-a746-3e0c43d74fe7', N'Game-On', N'Game On!', N'Content', CAST(0x00009AED00CFEA90 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'95df8388-20cd-48e3-b7dc-4289232dbd42', N'Five-Minute-ASPNETMVC', N'Model - View - Controller - The RoR Inspired Design Pattern!', N'Content', CAST(0x00009ADB01822B60 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'65428004-1ac1-40f7-a85b-2d2a1b30370f', N'Does-PrincipalPermission-fail-always', N'Does PrincipalPermission fail always?', N'Content', CAST(0x00009A9A0044AA20 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'adeb9a93-fab7-4a1b-a6ad-5d18d33b12f0', N'Login-control-ASPNET-works-in-Firefox-but-not-in-IE', N'Login control + ASP.NET + works in Firefox, not in IE', N'Content', CAST(0x00009A9900D3C2F0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'c2c52c6d-14bf-42a3-bb3c-7453e64e7f63', N'From-The-Studio-To-Release', N'From The Studio To Release', N'<p>
	chnage</p>
<p>
	&nbsp;</p>
<p>
	&nbsp;</p>
<p>
	asdasd</p>
', CAST(0x00009A97008D2CA0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Id], [Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'1dcea702-6dd8-40d9-9962-0d3b59bdd4ac', N'Welcome-to-ZaszBlog', N'Welcome to ZaszBlog', N'Content', CAST(0x00009A8600000000 AS DateTime), N'Rest')













/****** Object:  Table [dbo].[Tags]    Script Date: 06/14/2011 17:19:20 ******/
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'e996521e-2c3a-4691-a1c9-d10a57da35a0', N'asp.net')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'f328cd8c-7157-4527-a253-b48567817742', N'blizzard')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'e12da3d3-8427-4b9d-a500-daa768911666', N'books')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'0bd78e9e-5ce3-4339-966e-9dd17d438829', N'broke')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'9743cde4-ebca-4434-a6b9-0e4871dbf474', N'browser')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'c50a382c-7c62-4f77-962e-fcb2e32f6360', N'concept')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'794f9061-feee-44f7-816f-52c243a846d7', N'crap')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'bbbc77c5-2efc-40ad-9681-7486c010f075', N'does not work')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'6c52ac86-f1f1-41cc-8dc4-155711424ebb', N'dota')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'8d081731-e2b3-4f2f-b682-026dd223ac86', N'fun')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'e579ea73-d338-4e13-8e36-d69ae747a314', N'games')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'37857274-abec-41f9-b0d8-e037487d4662', N'grails')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'158d5b9e-e2ee-48e1-a870-20fe41fb94ac', N'groovy')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'8da1e4e7-4de3-4263-a5d3-ec8f6141f663', N'gwt')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'997eb610-7e4e-451a-9a41-9b62d79397ad', N'java')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'f443788c-be23-4a0a-819a-2791bd6b731c', N'mvc')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'c3e06962-2a37-4841-abf7-f0fa4c1faee5', N'patterns')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'5986c5bd-6fe2-4c9e-92b4-aff0fe8e1313', N'security')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'ecb93276-d47b-4fda-a642-36796ce32c21', N'starcraft')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'ebaf0685-b810-405a-ade0-e52118442bc1', N'sucks')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'7aaa173b-e839-4182-b308-012561d882f0', N'tw')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'97fecaf4-1a83-4baf-beb3-29dbc7a72456', N'twu')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'ce4fa265-11b6-423e-9215-0a7992ace519', N'wcf')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'94667b5e-108e-4477-9616-867b01946152', N'web')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'782ffa61-c1ec-4bf7-9978-b73c22bbbd1d', N'welcome')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (N'35408261-d38e-427f-834d-8a9f6e7ad044', N'lifehacker')













/****** Object:  Table [dbo].[TagPosts]    Script Date: 06/14/2011 17:19:20 ******/
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'027ff70e-e505-4c38-960b-fa375c478c3a', N'e996521e-2c3a-4691-a1c9-d10a57da35a0')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'65428004-1ac1-40f7-a85b-2d2a1b30370f', N'e996521e-2c3a-4691-a1c9-d10a57da35a0')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'95df8388-20cd-48e3-b7dc-4289232dbd42', N'e996521e-2c3a-4691-a1c9-d10a57da35a0')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'c2c52c6d-14bf-42a3-bb3c-7453e64e7f63', N'e996521e-2c3a-4691-a1c9-d10a57da35a0')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'adeb9a93-fab7-4a1b-a6ad-5d18d33b12f0', N'e996521e-2c3a-4691-a1c9-d10a57da35a0')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'5c6804a8-1ffe-4204-8fc1-d2ce13f2e62f', N'e996521e-2c3a-4691-a1c9-d10a57da35a0')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'9fc1a794-23f6-433c-b752-8be71abe4d14', N'e996521e-2c3a-4691-a1c9-d10a57da35a0')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'1a915911-aa1f-4208-84c0-fad3efe1f371', N'f328cd8c-7157-4527-a253-b48567817742')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'85a55607-dcf3-4862-94aa-bbcc99cd194e', N'f328cd8c-7157-4527-a253-b48567817742')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'3da89d74-6e62-46d0-9d05-ee1f0e48a974', N'e12da3d3-8427-4b9d-a500-daa768911666')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'f60ea829-c453-469e-893f-a057b608a4d9', N'e12da3d3-8427-4b9d-a500-daa768911666')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'68aba9c0-73ca-4bb0-9fa1-7a01a137ff5e', N'0bd78e9e-5ce3-4339-966e-9dd17d438829')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'f5f7cdfe-13f2-44b5-b42b-6cc1511f78ed', N'9743cde4-ebca-4434-a6b9-0e4871dbf474')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'adeb9a93-fab7-4a1b-a6ad-5d18d33b12f0', N'9743cde4-ebca-4434-a6b9-0e4871dbf474')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'f5f7cdfe-13f2-44b5-b42b-6cc1511f78ed', N'c50a382c-7c62-4f77-962e-fcb2e32f6360')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'c2c52c6d-14bf-42a3-bb3c-7453e64e7f63', N'c50a382c-7c62-4f77-962e-fcb2e32f6360')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'26328f4c-998e-40f3-a944-d14c6ee919c2', N'c50a382c-7c62-4f77-962e-fcb2e32f6360')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'adeb9a93-fab7-4a1b-a6ad-5d18d33b12f0', N'c50a382c-7c62-4f77-962e-fcb2e32f6360')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'9fc1a794-23f6-433c-b752-8be71abe4d14', N'c50a382c-7c62-4f77-962e-fcb2e32f6360')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'68aba9c0-73ca-4bb0-9fa1-7a01a137ff5e', N'794f9061-feee-44f7-816f-52c243a846d7')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'68aba9c0-73ca-4bb0-9fa1-7a01a137ff5e', N'bbbc77c5-2efc-40ad-9681-7486c010f075')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'ec22ddb9-2f0c-4999-a64d-ae5d4b891822', N'6c52ac86-f1f1-41cc-8dc4-155711424ebb')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'9ccc49e6-af13-43e5-b8b0-670af27a8960', N'6c52ac86-f1f1-41cc-8dc4-155711424ebb')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'82f59d51-4c39-49f5-a8e6-f715d9dcbe6f', N'6c52ac86-f1f1-41cc-8dc4-155711424ebb')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'49060da5-50b0-4c6d-af18-82db258f3e7e', N'6c52ac86-f1f1-41cc-8dc4-155711424ebb')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'318c9ca7-12b0-405c-9ddb-07a7ca19858e', N'6c52ac86-f1f1-41cc-8dc4-155711424ebb')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'99f701a2-6dd0-4be2-9c24-a090f829446f', N'6c52ac86-f1f1-41cc-8dc4-155711424ebb')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'b72e5ac2-e8e0-4daf-9d30-7ccb9a2c6250', N'6c52ac86-f1f1-41cc-8dc4-155711424ebb')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'1255d6cf-9e3a-431d-9fb6-e4cae3a44115', N'6c52ac86-f1f1-41cc-8dc4-155711424ebb')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'49060da5-50b0-4c6d-af18-82db258f3e7e', N'e579ea73-d338-4e13-8e36-d69ae747a314')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'b09b7298-a7c9-4baf-a746-3e0c43d74fe7', N'e579ea73-d338-4e13-8e36-d69ae747a314')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'f60ea829-c453-469e-893f-a057b608a4d9', N'e579ea73-d338-4e13-8e36-d69ae747a314')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'06623d98-527d-4b0f-b5cf-d69264b47295', N'e579ea73-d338-4e13-8e36-d69ae747a314')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'b72e5ac2-e8e0-4daf-9d30-7ccb9a2c6250', N'e579ea73-d338-4e13-8e36-d69ae747a314')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'85a55607-dcf3-4862-94aa-bbcc99cd194e', N'e579ea73-d338-4e13-8e36-d69ae747a314')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'1255d6cf-9e3a-431d-9fb6-e4cae3a44115', N'e579ea73-d338-4e13-8e36-d69ae747a314')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'26328f4c-998e-40f3-a944-d14c6ee919c2', N'37857274-abec-41f9-b0d8-e037487d4662')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'26328f4c-998e-40f3-a944-d14c6ee919c2', N'158d5b9e-e2ee-48e1-a870-20fe41fb94ac')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'08af2ae7-1690-47f1-a3d6-82717fa6ca52', N'8da1e4e7-4de3-4263-a5d3-ec8f6141f663')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'b5e5f7bc-d84d-45fb-8c92-15beb9c0c490', N'8da1e4e7-4de3-4263-a5d3-ec8f6141f663')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'd9e19ad1-6823-4ad7-8a7b-a65599f30d46', N'997eb610-7e4e-451a-9a41-9b62d79397ad')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'26328f4c-998e-40f3-a944-d14c6ee919c2', N'997eb610-7e4e-451a-9a41-9b62d79397ad')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'b5e5f7bc-d84d-45fb-8c92-15beb9c0c490', N'997eb610-7e4e-451a-9a41-9b62d79397ad')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'5c471a0d-9afb-470d-a2a0-361a21b8bb0d', N'f443788c-be23-4a0a-819a-2791bd6b731c')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'95df8388-20cd-48e3-b7dc-4289232dbd42', N'f443788c-be23-4a0a-819a-2791bd6b731c')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'26328f4c-998e-40f3-a944-d14c6ee919c2', N'c3e06962-2a37-4841-abf7-f0fa4c1faee5')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'65428004-1ac1-40f7-a85b-2d2a1b30370f', N'5986c5bd-6fe2-4c9e-92b4-aff0fe8e1313')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'e0c5aece-6081-4d66-b34c-7c74a1c6beb8', N'5986c5bd-6fe2-4c9e-92b4-aff0fe8e1313')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'1b166078-c6b7-4b76-8d78-7cb46d794912', N'5986c5bd-6fe2-4c9e-92b4-aff0fe8e1313')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'68aba9c0-73ca-4bb0-9fa1-7a01a137ff5e', N'ebaf0685-b810-405a-ade0-e52118442bc1')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'5c471a0d-9afb-470d-a2a0-361a21b8bb0d', N'7aaa173b-e839-4182-b308-012561d882f0')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'e3d45333-b48c-4ddd-ad78-0258b5e0d76a', N'7aaa173b-e839-4182-b308-012561d882f0')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'5c471a0d-9afb-470d-a2a0-361a21b8bb0d', N'97fecaf4-1a83-4baf-beb3-29dbc7a72456')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'50a59416-94a6-4b6c-93e3-20a732a9ef0e', N'97fecaf4-1a83-4baf-beb3-29dbc7a72456')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'e3d45333-b48c-4ddd-ad78-0258b5e0d76a', N'97fecaf4-1a83-4baf-beb3-29dbc7a72456')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'65428004-1ac1-40f7-a85b-2d2a1b30370f', N'ce4fa265-11b6-423e-9215-0a7992ace519')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'f5f7cdfe-13f2-44b5-b42b-6cc1511f78ed', N'94667b5e-108e-4477-9616-867b01946152')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'027ff70e-e505-4c38-960b-fa375c478c3a', N'94667b5e-108e-4477-9616-867b01946152')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'd9e19ad1-6823-4ad7-8a7b-a65599f30d46', N'94667b5e-108e-4477-9616-867b01946152')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'328fd77a-8172-4e88-8557-8104f06ad053', N'94667b5e-108e-4477-9616-867b01946152')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'08af2ae7-1690-47f1-a3d6-82717fa6ca52', N'94667b5e-108e-4477-9616-867b01946152')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'9fc1a794-23f6-433c-b752-8be71abe4d14', N'94667b5e-108e-4477-9616-867b01946152')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'ffbbd08d-073d-48ed-8fb6-7ac6ab31d365', N'94667b5e-108e-4477-9616-867b01946152')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'1dcea702-6dd8-40d9-9962-0d3b59bdd4ac', N'94667b5e-108e-4477-9616-867b01946152')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'b72e5ac2-e8e0-4daf-9d30-7ccb9a2c6250', N'782ffa61-c1ec-4bf7-9978-b73c22bbbd1d')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'1dcea702-6dd8-40d9-9962-0d3b59bdd4ac', N'782ffa61-c1ec-4bf7-9978-b73c22bbbd1d')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'42596445-0f08-486a-aeb5-a2688ca371b5', N'8d081731-e2b3-4f2f-b682-026dd223ac86')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'68aba9c0-73ca-4bb0-9fa1-7a01a137ff5e', N'ecb93276-d47b-4fda-a642-36796ce32c21')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'cbfbbb9e-c44c-4820-ae8d-07c1dd253866', N'94667b5e-108e-4477-9616-867b01946152')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'8d62fc05-97a9-4aaa-8379-a41cce26b252', N'37857274-abec-41f9-b0d8-e037487d4662')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'8d62fc05-97a9-4aaa-8379-a41cce26b252', N'8da1e4e7-4de3-4263-a5d3-ec8f6141f663')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'8d62fc05-97a9-4aaa-8379-a41cce26b252', N'c3e06962-2a37-4841-abf7-f0fa4c1faee5')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'd4439543-afd4-42fb-978a-b72eab0c07f9', N'35408261-d38e-427f-834d-8a9f6e7ad044')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'26678b12-e7d6-4f7c-957e-ed74ba71ef97', N'35408261-d38e-427f-834d-8a9f6e7ad044')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'a921264e-82dd-41b6-adf4-cd92ee8337a4', N'c50a382c-7c62-4f77-962e-fcb2e32f6360')
INSERT [dbo].[TagPosts] ([Post_Id], [Tag_Id]) VALUES (N'1b166078-c6b7-4b76-8d78-7cb46d794912', N'35408261-d38e-427f-834d-8a9f6e7ad044')