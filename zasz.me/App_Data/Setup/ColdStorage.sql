USE [ColdStorage]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 05/02/2011 17:38:52 ******/
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
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'About-Dota-660', N'About Dota 6.60', N'<ul>			<li>	<p>	Tavern layout is changed: 9 taverns in the circular top-left area.	</p>	</li>		<li>	<p>	The 9 taverns are { Sentinel, Neutral, Scourge } x {Strength, Intelligence, Agility } 3x3 = 9	</p>	</li>		<li>	<p>	Heros in Neutral taverns can be picked by both sides (Sad, Sacred Warrior is neutral... he oughtta be sentinel - see his story )	</p>	</li>		<li>	<p>	Lightning Revenant (Razor) fully remade.	</p>	</li>		<li>	<p>	Viper (Netherdrake) Sven (Rogue Knight) and Lina Inverse (Slayer) have 1 or 2 skill remade.	</p>	</li>		<li>	<p>	Bat Rider , new hero for Scourge.	</p>	</li>		<li>	<p>	Tauren Cheiftain. new hero for Sentinel.	</p>	</li>		<li>	<p>	Force Staff (Casts Force Push) - new Item.	</p>	</li>		<li>	<p>	Ghost Staff (Casts Ghost Walk) - new Item.	</p>		</li>		<li>	<p>	Aghanim''s sceptre remade (Sad +10 to all attribs, but needs 2x BoAlacrity 2xSoWizardry 2xAoOgreStrength) improves all ultimates	</p>	</li>		<li>	<p>	Rune pickup sounds for allies I think	</p>	</li>		<li>	<p>	Magic Wand = magic stick + 3x Ironwoodbranch + recipe	</p>	</li>		<li>	<p>	Talisman of Evasion 1800 gold +25% evasion	</p>	</li>		<li>	<p>	Hood of Defiance + Nathreziems Buckler = new castable item (casts spell resistance shield) name likw Wisemans Pipe	</p>	</li>		<li>	<p>	Stout shield remade, new item uses stoutshield called Poorman''s shield	</p>	</li>		<li>	<p>	Rumour riki nerfed	</p>	</li></ul>', CAST(0x00009C0B01411350 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Back-to-Chennai', N'Back to Chennai', N'<p>      Did not even dream that TWU training will be this useful. 6 Weeks of Deep Thoughts and Brain Time went into :</p><p> </p><p>Negotiation, Consulting, Influencing, Effective Meetings, Retrospectives.</p><p> </p><p>Software laws, Copyrights, Licensing TradeMarks & Usage of 3rd Party software.</p><p> </p><p> Presentation Zen, Business Communication, Effective Teams, Information Radiators.</p><p> </p><p>Analysis, Object Oriented Design Patterns, Mocking (mockito & hamcrest matchers), MVC, Spring/Hibernate, Object Relationships, GUI - Functional - Integration Testing.</p><p> </p><p>Agile Methodology, Lifecycle, Processes, Manifesto.</p><p> </p><p>       Sessions on the consulting and the presentation and the development tracks goes a long way towards making the trainees a better individual. Will be back blogging more about these topics in detail, in future. Need to look into my notes, ponder and write about each of these sessions here, before anything else. BRB.</p><p> </p>', CAST(0x00009CBB0158F880 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Bing!', N'Bing!', N'<p> </p><p> </p><p>"Ever had trouble finding information online using a search engine? When what you thought was a simple search at first quickly spiraled out of control, leaving you buried in irrelevant and hard to find information? Don’t worry, searchers - we feel your pain."</p><p> </p><p>Introductory lines of the promotional video, that Microsoft is using to showcase its newest search engine called bing. It will still provide search results for any term an online user types into it. But Bing is initially designed to provide a much richer search experience for people looking for information in four categories: shopping, travel, health and local businesses.</p><p> </p><p>This could be an attempt to capitalize on the ''Vertical Search Engine'' - One that shows results categorically concept. Microsoft terms bing as a decision engine. It needs to do more than invent a new term brand to offset Google''s 65% share slice of the search engine market pie. Anyway if Microsoft Bing does become popular Google will simply mimic all the popular features, and so will Yahoo. Its done all the time. Let ''em compete. We''ll use all 3 making each one default in each browser. I use 3 - Gg Chrome, MS IE, Mozilla FF.</p><p> </p><p>Updates :</p><p> </p><p>Eminem - Relapse is out and it Rocks!!</p><p>Linkin Park with co-frontman Mike Shinoda has started the 4th studio album. To be released by early 2010.</p><p>Asp.net home site has degenerated to simply adding new dumb videos and controls. Sad. Javalobby is also becoming a boring site.</p><p> </p><p> </p><p> </p>', CAST(0x00009C1900A1C610 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Blizzard-Starcraft-2-Patch-11-Woes', N'Blizzard Starcraft 2 Patch 1.1 Woes', N'<p>After installing patch 1.1, which completed successfully, everything else broke. Can''t play multiplayer, nothing happens after pressing <strong>Find match</strong> (except that button getting disabled and text changing to <strong>waiting</strong>).</p><p> </p><p>Takes a long while to switch between single and multiplayer etc, and I''ve disabled all firewall antivirus etc. It all worked fine before. Blizzard is on a pedestal AFAIK but it really sucks if patches come out this way  :( I mailed it o ''em and raised an issue. What else? </p><p> </p><p>ZZZZZZZZZZZZZZZZZZZ </p><p> </p><p>Do something Blizzard! </p>', CAST(0x00009DFB01650E40 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'BlizzCon-2010-!!', N'BlizzCon 2010 !!', N'<p>Wish I could be there! Am going to watch it for free on the Net anyway, but still ...</p><p>There''s matches scheduled with players like LiquidTLO (The Little One), Dimaga, White-Ra, MakaPrime, HuK, <span class="Apple-style-span" style="font-family: Arial, Helvetica, sans-serif; font-size: 13px; border-collapse: collapse; color: #555555">SeleCT etc. And Jack Black, and ozzy.</span></p><p>Also present there will be HDStarcraft and HukyStarcraft, together with DustinBowder, Day9 and Other shoutcasters. Must be a cool party !</p><p>Blizzard better hurry up with HotS and D3, else there maybe a riot in their hands.</p>', CAST(0x00009E1501788E70 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Browser-2-0-Part-I', N'Browser 2.0 - Part I', N'<p>
<!--
/* Font Definitions */
@font-face
{font-family:SimSun;
panose-1:2 1 6 0 3 1 1 1 1 1;
mso-font-alt:宋体;
mso-font-charset:134;
mso-generic-font-family:auto;
mso-font-pitch:variable;
mso-font-signature:3 135135232 16 0 262145 0;}
@font-face
{font-family:"\@SimSun";
panose-1:2 1 6 0 3 1 1 1 1 1;
mso-font-charset:134;
mso-generic-font-family:auto;
mso-font-pitch:variable;
mso-font-signature:3 135135232 16 0 262145 0;}
/* Style Definitions */
p.MsoNormal, li.MsoNormal, div.MsoNormal
{mso-style-parent:"";
margin:0in;
margin-bottom:.0001pt;
mso-pagination:widow-orphan;
font-size:12.0pt;
font-family:"Times New Roman";
mso-fareast-font-family:SimSun;}
@page Section1
{size:8.5in 11.0in;
margin:1.0in 1.25in 1.0in 1.25in;
mso-header-margin:.5in;
mso-footer-margin:.5in;
mso-paper-source:0;}
div.Section1
{page:Section1;}
/* List Definitions */
@list l0
{mso-list-id:813832042;
mso-list-type:hybrid;
mso-list-template-ids:-1770370396 67698703 67698713 67698715 67698703 67698713 67698715 67698703 67698713 67698715;}
@list l0:level1
{mso-level-tab-stop:.5in;
mso-level-number-position:left;
text-indent:-.25in;}
@list l1
{mso-list-id:1241715920;
mso-list-type:hybrid;
mso-list-template-ids:3807600 67698703 67698713 67698715 67698703 67698713 67698715 67698703 67698713 67698715;}
@list l1:level1
{mso-level-tab-stop:.5in;
mso-level-number-position:left;
text-indent:-.25in;}
@list l2
{mso-list-id:2125418187;
mso-list-type:hybrid;
mso-list-template-ids:277931596 67698703 67698713 67698715 67698703 67698713 67698715 67698703 67698713 67698715;}
@list l2:level1
{mso-level-tab-stop:.5in;
mso-level-number-position:left;
text-indent:-.25in;}
ol
{margin-bottom:0in;}
ul
{margin-bottom:0in;}
-->
</p>
<p class="MsoNormal">
<span style="font-size: 10pt; font-family: Arial"></span>
</p>
<p class="MsoNormal">
<span style="font-size: 10pt; font-family: Arial">The browser of the future, a browser 2.0, must be in sync with the current usage of the Internet. The Web 2.0 or the semantic Web is now a place where interactivity and collaboration are the catch words. Web solutions no longer provide static content and dull detailed info to be browsed. Now Web solutions have become the epitome of</span> 
</p>
<p class="MsoNormal">
<span style="font-size: 10pt; font-family: Arial">interactivity - Flickr : upload download / view share publish photos ; YouTube : videos publish share view ; BlogSpot : publish ideas Forums to discuss technology and etc ... So if at all we have a new browser it must have the following features (that’s how I imagine it)</span> 
</p>
<p class="MsoNormal">
 
</p>
<ol style="margin-top: 0in">
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">An area must be rendered by the browser given a clump of xml tags and attributes</span></li>
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">If and when the user drags a file onto the area, it must be uploaded to the server and the progress also must be shown.</span></li>
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">This will allow us to , say , go to Flickr and select some photos in the explorer, and drag-drop them into the area, which will send them to Flickr or You Tube.</span></li>
</ol>
<p class="MsoNormal">
<span style="font-size: 10pt; font-family: Arial"></span>
</p>
<p class="MsoNormal">
<span style="font-size: 10pt; font-family: Arial"></span>
</p>
<ol style="margin-top: 0in">
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">Now a rich text editor is created by downloading a lot of JavaScript and Html/CSS</span></li>
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">These form an area where we can type info. when we click on the bold button, JavaScript code finds out what portion of the text is selected and dynamically enclose them with <b> and </b> tags so that they become bold</span></li>
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">What i propose is: why not incorporate a client side word processor into the browser? Say, WordPad for windows, emacs for Linux etc... Why download a lot of JavaScript to force the browser to do word-processing (something the browser is not made/designed to do ) JavaScript isn''t a language suitable for word processing, its difficult to do lexical analysis or NFA or DFA. Best thing JavaScript can do is execute Regular Expressions which is at best difficult to code and debug coz of the weak typing characteristic of JavaScript. Spell check is available only in precious few editors. And editors have a lot of issues in the various browsers in the market today</span></li>
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">This can also be realized by a custom browser with a clump of XML.</span></li>
</ol>
<p class="MsoNormal">
<span style="font-size: 10pt; font-family: Arial"></span>
</p>
<p class="MsoNormal">
<span style="font-size: 10pt; font-family: Arial"></span>
</p>
<p class="MsoNormal">
<span style="font-size: 10pt; font-family: Arial"></span>
</p>
<ol style="margin-top: 0in">
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">Each installation of the browser must be able to contact the organization that made the browser.</span></li>
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">The organization must provide a web service, that connects to all clients and collects info that enhances customer experience.</span></li>
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">Also combined central burner for RSS/Atom feeds and server of storage space would attract more people to span the internet more thoroughly.</span></li>
	<li class="MsoNormal"><span style="font-size: 10pt; font-family: Arial">The browser must also have modules that integrate with the default client side WordProcessing software.(No Windows version comes without WordPad, No Linux Distro comes sans EMACS All Macs have TextEdit builtin) If in the ultimate worst case of no client editor being present, we can fall back to web based editors. </span></li>
</ol>
<p>
 
</p>
<p>
 P. S. Look out for the next set of features in the future browser in Part II 
</p>
<em>"And I can''t help but wonder where I''m bound, where I''m bound."</em> (Tom Paxton) 
', CAST(0x00009AF10125E260 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Cant-Wait2c-Im-Sorry', N'Can''t Wait, I''m Sorry.', N'<p><span class="Apple-style-span" style="font-weight: bold"><span class="Apple-style-span" style="font-size: small">Can''t Wait, I''m Sorry.</span></span></p><p> </p><p>The bloody buggers. When the hell are they(Blizzard) going to release Starcraft 2 and Diablo 3. Will there be A DOTA - like mod for Starcraft 2? Will Garena support Diablo or Starcraft? Speaking of Garena : Note : While playing dere, U get trained to swallow insults. Every Half-Wit shouts noob (when i took mirana) at the slightest notice. But thats okay coz in other games they called me pro, when I took centaur and warlord. Mirana is more fun than any other hero though. I play under the alias Zasz.zasZ because simply Zasz got taken. For ne1 wondering why this alias : Zasz is the evil zerg mastermind villain in olden goldie Starcraft:Brood Wars</p><p> </p><p>So I am now downloading and trying out the Map Editor, and trying to use some programming language or the other in it. Far as I can see, its a no - go with .net</p>', CAST(0x00009BBE00B3E6B0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Charisma', N'Charisma', N'<p>I know that most of us have known this for a long long time - and I probably am not doing anything world-turning when I say this : (but i''m gonna go ahead and say this anyway)</p><p> </p><p>Folks often present ideas, give opinions, and discuss plans -  but it is another matter entirely if the same folks want people to listen to what they say.</p><p>One''s conversation includes a lot more than words one speaks :</p><p> </p><ul>			<li>Intonation</li>		<li>Accompanying hand gestures / body language</li>		<li>Facial expression</li>		<li>Confidence</li></ul><p> </p><p>To get all of these right requires a lot of work, (probably in front of a mirror :| ) and maybe some patience ...</p><p>Words well said can potentially influence anyone - if done with skill. Sadly it preconditions existence of good social skills and a liking of human social interactions. </p><p> </p>', CAST(0x00009DCF00B3A060 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Clan-Feeders-is-ONLINE', N'Clan Feeders is ONLINE', N'<div> </div><div>Clan URL :</div><div> </div><div><a href="http://www1.garena.com/clan/index.php?module=clanview&clid=54827">http://www1.garena.com/clan/index.php?module=clanview&clid=54827</a></div><div> </div><div>Clan Logo :</div><div> <img src="/Images/Logo/Feeders/logo_300.jpg" alt="Feeder Logo" /></div><div>Clan Fame :</div><div> </div><div><ul>	<li><a href="/ZaszBlog/post/2009/06/WTF-Sadness.aspx"> WTF Sadness</a></li>		<li><a href="/ZaszBlog/post/2009/07/Feeder-Friends.aspx"> Feeder Friends</a> </li>		<li><a href="/ZaszBlog/post/2009/09/ZaszzasZ.aspx"> Zasz.zasZ</a> </li>		<li><a href="/ZaszBlog/post/2009/06/On-the-other-hand.aspx"> On the other hand</a> </li>	</ul></div><div> </div><div> </div><div> </div>', CAST(0x00009CC800F61800 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Comedy-Family-Tree', N'Comedy Family Tree', N'<p><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\dotafamilyrelationshipnn.jpg" alt="" /></p><p>Or use this link : </p><p><a href="http://img7.imageshack.us/img7/2627/dotafamilyrelationshipnn.jpg">http://img7.imageshack.us/img7/2627/dotafamilyrelationshipnn.jpg</a> </p>', CAST(0x00009C0B01490A60 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Default-button-in-ASPNET', N'Default button in ASP.NET', N'<p><span class="Apple-style-span" style="color: #555555; font-size: 12px">While working on my Login Page I got a problem: There''s a Search box on top see, with a <span class="Apple-style-span" style="font-weight: bold">Go</span> button. Then there''s the Login Button in the Login control. So when i entered username and password and pressed enter key, browser acted as if i pressed the <span class="Apple-style-span" style="font-weight: bold">Go </span>button. So i needed to make the Login button as default.</span></p><p> </p><p>Solution was :</p><p><asp:Button <span class="Apple-style-span" style="font-weight: bold"><span class="Apple-style-span" style="font-style: italic"><span class="Apple-style-span" style="text-decoration: underline">UseSubmitBehavior="false"</span></span></span> ID="Button1" runat="server" BorderStyle="None" BorderWidth="0" </p><p>                            CssClass="go" Text="Go" onclick="MasterSearchTextBox_Click"></asp:Button> </p><p> </p><p>Usually ASP.NET buutons like this: </p><span class="Apple-style-span" style="color: #555555; font-size: 12px"><div style="font-family: monospace; font-size: 10pt; background-color: white"><span style="color: blue"><</span><span style="color: maroon">asp</span><span style="color: blue">:</span><span style="color: maroon">Button</span><span style="color: black"> </span><span style="color: red">ID</span><span style="color: blue">="btnAddChoice"</span><span style="color: black"> </span><span style="color: red">runat</span><span style="color: blue">="server"</span><span style="color: black"> </span><span style="color: red">Text</span><span style="color: blue">="Add" </span><span style="color: black"></span><span style="color: red">OnClientClick</span><span style="color: blue">="AddToListBox(lbxChoices, txtChoiceName);"</span><span style="color: black"></span><span style="color: red"></span><span style="color: blue"></span><span style="color: black"> </span><span style="color: blue">/></span></div><br />render as <br /><br /><div style="font-family: monospace; font-size: 10pt; background-color: white"><span style="color: blue"><</span><span style="color: maroon">input</span><span style="color: black"> </span><span style="color: red">type</span><span style="color: blue">="submit"</span><span style="color: black"> </span><span style="color: red">name</span><span style="color: blue">="btnAddChoice"</span><span style="color: black"> </span><span style="color: red">value</span><span style="color: blue">="Add"</span><span style="color: black"></span><span style="color: red">onclick</span><span style="color: blue">="AddToListBox(lbxChoices, txtChoiceName);"</span><span style="color: black"> </span><span style="color: red"></span><span style="color: blue"></span><span style="color: black"></span><span style="color: blue">/></span></div><p><br />So when I click on such a button, my JavaScript fires correctly but the page then submits - not what I want it to do.</p><p> <span class="Apple-style-span" style="font-family: ''-webkit-monospace''; font-size: 13px"><span style="color: blue"><</span><span style="color: maroon">asp</span><span style="color: blue">:</span><span style="color: maroon">Button</span><span style="color: black"> </span><span style="color: red">ID</span><span style="color: blue">="btnAddChoice"</span><span style="color: black"> </span><span style="color: red">runat</span><span style="color: blue">="server"</span><span style="color: black"> </span><span style="color: red">Text</span><span style="color: blue">="Add"</span><span style="color: black"></span><span style="color: red">OnClientClick</span><span style="color: blue">="AddToListBox(lbxChoices, txtChoiceName); return false;"</span><span style="color: black"> </span><span style="color: red">UseSubmitBehavior</span><span style="color: blue">="false"</span><span style="color: black"> </span><span style="color: blue">/></span></span></p>Renders the input control like I want it to, as a button:<br /><br /></span><div style="font-family: monospace; font-size: 10pt; background-color: white"><span style="color: blue"><</span><span style="color: maroon">input</span><span style="color: black"> </span><span style="color: red">type</span><span style="color: blue">="button"</span><span style="color: black"> </span><span style="color: red">name</span><span style="color: blue">="btnAddChoice"</span><span style="color: black"> </span><span style="color: red">value</span><span style="color: blue">="Add"</span><span style="color: black"></span><span style="color: red">onclick</span><span style="color: blue">="AddToListBox(lbxChoices, txtChoiceName); <span class="Apple-style-span" style="text-decoration: underline">return false</span>;__doPostBack(''btnAddChoice'','''')"</span><span style="color: black"> </span><span style="color: red"></span><span style="color: blue"></span><span style="color: black"></span><span style="color: blue">/></span></div><div> </div><div>You then need to notice that "return false;" statement is necessary if u don''t want postback. But in my case the go button needed the postback so i did not add the return false clase. However it is still a button and will postback but only when clicked on. And not when pressing enter key.</div><div> </div><div> </div><div>Another solution (that doesn''t work in Google Chrome)  :</div><div> </div><div>First I tried this script after browsing the web :</div><div> </div><div>function PressLogin()</div><div>      {        </div><div>        var loginbtn = document.getElementById(''ctl00_ctl00_CMDivMid_cphmain_ThonLogin_LoginButton'');</div><div>        if(loginbtn == null) </div><div>        {</div><div>            alert("For Security Purposes : Please click on the Login Button , Don'' hit the enter key!");            </div><div>        }</div><div>        else</div><div>        {            </div><div>            try{loginbtn.click();}</div><div>            catch (ex) { alert("Err"); }</div><div>        }</div><div>        return false;</div><div>     } </div><div> </div><div>and in the password text box :</div><div> </div><div><asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password" onkeypress="if(event.keyCode==13) { PressLogin(); }"></asp:TextBox> </div><div> </div><div>This allowed the Login button to be clicked when pressing enter after typing password. This is somewhat partial solution cause the user may hit enter from the username textbox too, or defocus the password textbox b4 hitting enter key, then the solution''ll fail. This code totally fails when using chrome cause when u hit enter in chrome, the event is not given to the textbox at all, instead it is sent to the 1st submit button directly.</div><div> </div>', CAST(0x00009C2A00015F90 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Defense-of-the-Pendragon---LOL', N'Defense of the Pendragon - LOL', N'<p>Contrary to what you may first think, lol means league of legends! Now we know IceFrog is the developer of Dota and in his latest update on his blog he boycotted the famous dota-allstars.com. I quote from the IceFrog.com website :</p><p> </p><p> </p><p><span class="Apple-style-span" style="font-style: italic">As a result of some differences, I am no longer affiliated with the dota-allstars.com website. I want to take this opportunity to wish everyone over there the best of luck in the future.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">I still plan on continuing DotA development for a long time, a couple years at the very least. The next update, 6.60, is nearing the end of its design and testing phase. The translation phase will also be starting shortly. There is still a little bit more work to do on fixing some specific content, but it''s finally approaching completion. I will post another update here in the near future.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">As of today, I am starting a new community site for DotA. I think it is more valuable to the players though if I focus most of my time on developing and improving the game, so I''m here to reach out and ask for help on this. I believe that with some organization, the community has some very talented people that can help build a site to serve their interests and needs. Help can come in many different forms: programming, design, technical support, content contributions, etc. My goal is to have a format where everyone that wants to help can contribute in a productive way. If you are interested in being involved, please send me an email at IceFrog@gmail.com</span></p><p> </p><p> </p><p>Now the dota-allstars.com website Admin PenDragon has issued an official statement to ''quell misinformation''. Sad. </p><p> </p><p>Here is the official statement from Pendragon.</p><p> </p><p>DotA Community,</p><p> </p><p>Some people may seem to be confused about the events that have taken place over the last 24 hours or so. Lots of misinformation is being spread around, and I just wanted to make an official statement.</p><p> </p><p>First, I’d like to discuss my decision to mention League of Legends on the DotA forums, and to the DotA community. I have a strong passion for DotA, and the DotA community having worked with you all for 5 years now (even before IceFrog days!), and feel like there’s always been things that I’d like to do for either the community or the game that have been out of reach for whatever reason. My decision to join Riot and League of Legends is based on the desire to augment the entire game industry with an unprecedented level of community support and involvement, far more than the existing DotA, and far more than any existing game.</p><p> </p><p>Some perceive this decision as one that could create a conflict of interest; I do not believe that to be the case. I feel like I can do good things for DotA, and good things for LoL, and the support and resources that I now have available to me due to my affiliation with Riot Games will help me make the biggest and best DotA Allstars Fansite ever.</p><p> </p><p>While I’m not going to speculate regarding Icefrog’s decision to leave DotA-Allstars.com, I want to assure everyone that there’s no bad blood between me and Icefrog and we’ll likely work together on at least one project in the future. I have great respect for him, as I’m confident he does for me. The little details that lead to the decision aren’t nearly as important as where we go from here.</p><p> </p><p>This to me is the end of one era and the dawn of another. Since competition drives innovation, Icefrog’s decision means that I’ll have to strive to improve the website to be successful without his endorsement. It puts pressure on me to deliver a new DotA-Allstars.com that surpasses expectations and keeps this site strong for years to come.</p><p> </p><p>It’s an opportunity for me to retain my credibility by being the guy who does great things for DotA, and for the DotA community, instead of just being the “owner of the official website”. This is a win-win situation for DotA players, as it means both websites will need to constantly improve to compete for your attention. You guys mean everything to me and I hope to serve you loyally for years to come.</p><p> </p><p>But it still does not answer the question why Icefrog left DotA AllStars.</p><p> </p><p> </p><p><span class="Apple-style-span" style="color: #29303b; font-family: Georgia; font-size: 13px; font-weight: bold"><a style="color: #956839; text-decoration: underline" href="http://ninjaspartans.blogspot.com/2009/05/league-of-legends-and-dota-controversy.html">http://ninjaspartans.blogspot.com/2009/05/league-of-legends-and-dota-controversy.html</a></span></p><p><span class="Apple-style-span" style="font-weight: bold">The DotA All-Stars.com conspiracy</span></p><p><span class="Apple-style-span" style="font-weight: bold">-Atchucan May 15 2009</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">I''ve been around the DotA All-Stars community since the old Dota forums although I didn''t sign up right away to the new one (DotA-AllStars.com)</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">Back then, all was good. There were still some other DotA versions like the Mercenaries franchise that was still on life-support. There was no Garena yet at that time. DotA was being played on Battle net and in numerous other small LAN emulators and independent PvPGNs.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">The year was 2005.</span></p><p><span class="Apple-style-span" style="font-style: italic">A few months before that, Icefrog took the reins from the abandoned Guinsoo project. This was a welcome change. From the old AOS custom that was being bashed by other members of the map making community for being overrated, it was slowly turning into something more polished.</span></p><p><span class="Apple-style-span" style="font-style: italic">DotA All-Stars was growing at an unbelievable rate.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">With new players being added to the fold everyday and more and more newbies looking for DotA resources, the old timers felt that it was time for DotA to have it''s own home since admit it or not, the old forums was what we call... "in disarray" actually.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">Then Pendragon stepped in to provide the domain and all the prerequisites for the founding of a new home. Thus, DotA-AllStars.com was born.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">It was a young site. There were problems with it. But when all these were fixed thanks to the dedication of Pendragon and the various community members that are long gone from these forums.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">A new DotA map was released... This time, endorsing www.DotA-AllStars.com on the loading screen and then BOOM! Community registrations shot off the roof. It was now easier to share strategies, guides, report bugs, etc. The DotA AllStars forum went through a metamorphosis. The forum was undergoing rapid changes.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">And here comes the 1st symptom that manifested: Not allowing the discussion of other Warcraft custom maps. Other wc3 communities tolerated this since they understood that Warcraft maps were meant to be enjoyed. Pendragon''s DotA community wanted monopoly. There were various theories but it nothing was ever confirmed till the next event happened.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">On October 2008, League of Legends was announced.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">Despite all the contributions Icefrog, Guinsoo and Pendragon gave to the development of DotA, they were not allowed one thing. It is stated in Blizzard''s terms and conditions that everything you create using the Warcraft World Editor remains as Blizzard property. Thus, you are not allowed to PROFIT from DotA. Even if DotA AllStars is one of the biggest gaming communities in the world, the creators and their affiliates are not allowed to take even a single cent.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">Enter League of Legends - the commercial venture of some of the people involved in the DotA project who wanted to turn a profit. This was a legal way of earning money. By creating a game not running on the Warcraft engine, the game developers could not be prosecuted legally by Blizzard Entertainment.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">A few weeks ago, Pendragon''s grand plan was revealed starting with the pimped up new servers to solve the slow forum problems. Next was the redesign and overhaul of the DotA-AllStars website. Then just over 24 hours ago, the first newsfeed was released to all your e-mail accounts together with the public announcement of a new unneeded program - the controversial DotA Patcher.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">This is where the interests of both parties conflict. Read on for the best part:</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">Pendragon and his crew want to continually move DotA All-Stars to something more commercial. They are going through phases to make the target market of League of Legends soften up to a commercial version of DotA All-Stars. By harnessing the power of the existing DotA-AllStars.com communiity with it''s millions of registered users, Riot Games would have a ready market for it''s baby.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">Icefrog wants DotA All-Stars to be what it currently is: a free to download Warcraft map that is meant to be enjoyed even if the game developers do not get a single cent from dedicating their time on it.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">You won''t get any official statements explaining the whole story from any of the parties involved since it benefits no one.</span></p><p><span class="Apple-style-span" style="font-style: italic">Please take note that the developers of LOL have made a substantial investment. If Icefrog releases his side of the story, majority of the DotA players would boycott the League of Legends product. Nobody wants that. Icefrog made the right decision.</span></p><p><span class="Apple-style-span" style="font-style: italic"><br /></span></p><p><span class="Apple-style-span" style="font-style: italic">He left DotA-AllStars.com to be free to develop the game without sacrificing his principles while having the integrity of League of Legends left intact at the same time. </span></p><p> </p><p>Check these links out :</p><p> </p><p>http://www.leagueoflegends.com/ </p><p>http://www.riotgames.com/ </p>', CAST(0x00009C0B013BDB60 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Does-PrincipalPermission-fail-always', N'Does PrincipalPermission fail always?', N'<p>
<font size="3">I was trying to connect a .NET 2.0 C# application with a .NET3.5 WCF service. (Becoz .net 2.0 is less load on client systems and occupies lesser space) ALL PROXY CLASSES HAVE BEEN GENERATED BY WSDL.EXE. </font>
</p>
<p>
<font size="3">I exposed 4 services AuthenticationService RoleService & ProfileService & MyService. </font>
</p>
<ol>
	<li><font size="3">AuthenticationService </font></li>
	<li><font size="3">RoleService  </font></li>
	<li><font size="3">ProfileService</font></li>
</ol>
<font size="3">             These three are part of System.Web dll and i''ve written no code for these just exposed them using Web.config file. They have no code-behind, they point to classes in System.Web dll. </font>
<ol>
	<li><font size="3">MyService         <br />
	</font></li>
</ol>
<font size="3">            This service is my own and i exposed this also , with the correct syntax and it has 3 methods:doWork(),moreWork(),evenMoreWork(). </font>
<p>
<font size="3">The problem is a SecurityException is thrown whenever we access moreWork(),evenMoreWork() both of which are protected by declarative PrincipalPermission attribute, even though I send the authentication cookie - as follows : </font>
</p>
<p class="MsoNormal">
<font size="3">MyService client = new MyService()<br />
client.CookieContainer = cookiecontainer; <br />
cookiecontainer contains the authentication cookie (forms-auth-ticket) initially filled by the login method in AuthenticatioService proxy. </font>
</p>
<p class="MsoNormal">
<font size="3">Methods in the ProfileService and RoleService need the authentication cookie got from AuthenticationService''s login method, and they work fine, after adding the cookiecontainer to those services first , of course. It seems the authentication cookie i get from .netfx-inbuilt AuthenticationService is not enough for satisfying the PrincipalPermission attribute but enough for the other .netfx-inbuilt ProfileService and RoleService. </font>
</p>
<p>
<font size="3">The problem is: </font>
</p>
<p>
<font size="3">PrincipalPermission kept failing becoz the thread executing the method decorated with the attribute did not have its current principal set to anything.You therefore need to actually create a principal from the authentication cookie from the request, and set it as current principal to the thread executing the method so what I immediately did was (this did not work) : </font>
</p>
<ol>
	<li><font size="3">In the global.asax file i inserted a new function Authenticate_Request which took the authentication cookie and created a principal from it. Details of how this is done - serach the net (or) MSDN.</font></li>
	<li><font size="3">And set the Thread.CurrentPrincipal as the one i just created .</font></li>
</ol>
<p>
<font size="3">And still it did not work.Reason : The thread executing the global.asax files Authenticate_Request() is different from the one that''s executing the decorated method.So how to set that thread execing the decorated method before the method is actually executed ???? One person has posted and suggested a soap extension or a http module but both of the options did''nt work for me.  </font>
</p>
<p>
<font size="3">This worked (This is how you make PrincipalPermission work): </font>
</p>
<ol>
	<li><font size="3">Store the created principal(created from authentication cookie) somewhere, preferably in HttpContext.Current.User</font></li>
	<li><font size="3">In the CONSTRUCTOR of the code-behind class of the service, (the thread executing the constructor and the web service decorated method is the same!), add the following code.</font></li>
	<li><font size="3">In the constructor insert : Thread.CurrentPrincipal = HttpContext.Current.User</font></li>
	<li><font size="3">Makes sense - Asp.net runtime need to instantiate the class before any method is called, and the worker thread that instantiated the thread now is associated with the principal we created, which same thread will also call the methods in the object it just instantiated.</font></li>
	<li><font size="3">Then when the method is called, PrincipalPermission passes, and everything works fine.</font></li>
</ol>
<p>
<font size="3">However PrincipalPermission based on roles failed don''t know how to include role info while creating and setting the principal.Finally, My writing in Authenticate_Request in Global.asax was''nt necessaire, seems Runtime does what i did by default, that is create a Principal from cookie and set it in Context.user. <strong>SimpleSolution that works</strong> : Set Thread.CurrentPrincipal = HttpContext.Current.User in constructor of any WCF web service code-behind class .cs file and then use declarative PrincipalPemission attributes to work. </font>
</p>
<p>
<font size="3">  </font>
</p>
', CAST(0x00009A9A0044AA20 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Dota-660', N'Dota 6.60', N'<p>IceFrog is sure taking his own sweet time, getting 6.60 ready. Right now there''s rumours dat there is a new item also, along wid the new hero tauren and there are new sound effects for runes and some remakes.</p><p> </p><p>Blizzard has come up with a new character class Archivist - what''ll he do? Read books to Damage HellSpawn Demons ??</p><p> </p><p>If Blizzard offered me a job as a Balance Designer in the Starcraft 2 Team, Ill work for free !!  Play games all day and they are getting paid for it. The buggers at game review magazines too! I can write articles like they do to, so people ought to go for it. </p><p> </p><p> </p>', CAST(0x00009BF801598520 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'End-of-Holidays-in-Horizon-(', N'End of Holidays in Horizon :(', N'<p>Joining ThoughtWorks on 23rd Sept.  Called to Bangalore for 2 months training, then back to chennai.  Got two textbooks sent from company which are raising my guilt level whenever i look at ''em :D Keeping in touch with all frnds thro'' facbook Garena and group mail.</p><p> </p><p> Need to do GRE... that costs around INR9000 and 2 months in advance scheduling just to appear. And besides I need to *learn* for it.</p>', CAST(0x00009C6E00CAF8F0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Essential-Tip-for-any-ASPNET-developer', N'Essential Tip for any ASP.NET developer', N'<p>
 Just found out why my site is slow in loading.
</p>
<p>
 
</p>
<p>
Asp.NET renders many <script src="....." /> tags. Each time this tag is encountered by the browser, it sends a HTTP GET request to the server for da resource. This causes the slowdown. We can instead combine all these requests into one request which delivers all the js files a page needs....
</p>
<p>
 
</p>
<p>
See this video : <a href="http://www.asp.net/learn/3.5-SP1/video-296.aspx" title="ASP.NET Video">http://www.asp.net/learn/3.5-SP1/video-296.aspx</a>  and <a href="http://msmvps.com/blogs/omar/archive/2008/05/10/fast-asp-net-web-page-loading-by-downloading-multiple-javascripts-in-batch.aspx">http://msmvps.com/blogs/omar/archive/2008/05/10/fast-asp-net-web-page-loading-by-downloading-multiple-javascripts-in-batch.aspx</a>
</p>
<p>
 
</p>
<p>
My homepage itself had about 42  <script src="....." /> tags rendered, which translated to 42 HTTP GET requests in addition to the images and stylesheets linkz (about 20 more )..Whew!
</p>
<p>
 
</p>
<p>
Also check out the YSlow Firfox Plugin that allowed me find this problem out! 
</p>
', CAST(0x00009B17013C6800 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Fact-and-Fiction', N'Fact & Fiction', N'<blockquote>
	Brisingr, the third book in the Inheritance trilogy is comin'' out on September 20, 2008. And here''s the spoiler video :
</blockquote>
<blockquote>
	 
</blockquote>
<div id="paolini_spoil3">
<div style="float: right; text-align: center">
<object classid="clsid:02BF25D5-8C17-4B23-BC80-D3488ABDDC6B" codebase="http://www.apple.com/qtactivex/qtplugin.cab#version=6,0,2,0" name="paolini_spoil3" width="320" height="256">
	<param name="name" value="paolini_spoil3" />
	<param name="width" value="320" />
	<param name="height" value="256" />
	<param name="target" value="myself" />
	<param name="src" value="http://www.alagaesia.com/still_va.mov" />
	<embed type="video/quicktime" name="paolini_spoil3" width="320" height="256" target="myself" src="http://www.alagaesia.com/still_va.mov"></embed>
</object>
</div>
</div>
<div id="paolini_spoil3">
You need the Quicktime plugin to view this video, leeched from <a href="http://www.alagaesia.com" title="Brisingr">Alagaesia.com</a> Brisingr is the AncientLanguage word that means fire, and people have been discussing like there are two parts to this book. Good the more the better, far as fantasy is on me. 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
    Other books absolutely must read are : 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
<font size="3"><strong>
Fantasy</strong></font> : Harry Potter series - Rowling , The Bartimaeus trilogy - Stroud , Thud! - Pratchett , Lordof the Rings - Tolkien. 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
<strong><font size="3">Affect </font></strong>: The Matarese Circle, Countdown - Ludlum, Icon - Forsyth, Where eagles dare, T.G.O.N. - Maclean, 
</div>
<div id="paolini_spoil3">
Warlock - Wilbursmith , Hunt for the Red October-Patriot Games-Executive Orders-Cardinal of the Kremlin-Red storm rising - TomClancy 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
<strong><font size="3">Sci-Fi </font></strong>: Foundation series - Issac Asimov Clarkes odds and ends . All of the mentioned works : I guarantee you they are the best and greatest. Must read if anyone reads at all. Congo, Sphere, J. P. L. W. - M.Crichton
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
<strong><font size="3">Westerns </font></strong>: Sudden series J.T. Edson , Sackett - L''Amour , Max books too. 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
 
</div>
<div id="paolini_spoil3">
James  Rollins and Mathew Reilly are the REALLY FAST paced (and far fetched ) story tellers. Temple, Ice Station , Subterenean , HovercarRacer are all capable of delivering the WOW effect.<br />
</div>
', CAST(0x00009AED00D98780 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Feeder-Friends', N'Feeder Friends', N'<p><font face="times new roman,times" size="3"> </font></p><p><font face="times new roman,times" size="3">OMG! Its difficult to believe, but the feeder clan has progressed to notoreity... we keep winning 9 matches out of 10. Many people are regular mates and we mostly end up playing together. The significant few guys who are part of the feeder clan in all but name are :</font></p><p><font face="times new roman,times" size="3"> </font></p><ul>			<li><font face="times new roman,times" size="3">Jokerstuff</font></li>		<li><font face="times new roman,times" size="3">ice321</font></li>		<li><font face="times new roman,times" size="3">__XLR8__</font></li>		<li><font face="times new roman,times" size="3">InF3rNix </font></li>		<li><font face="times new roman,times" size="3">nefar!ous</font></li>		<li><font face="times new roman,times" size="3">CrypticAngel </font></li>		<li><font face="''times new roman''" size="4"><span class="Apple-style-span" style="font-size: 16px">__To)(ic__</span></font></li>	<li><font face="''times new roman''" size="4"><span class="Apple-style-span" style="font-size: 16px">Razerwire</span></font></li></ul><p><font face="times new roman,times" size="3"><br />Mostly above said players and the feeders seem to favour certain picks... and with these piks our sides start to own the game by level 10 most of the time. This needs to change : any hero ought to be well played by any one of us! </font></p><p><font face="times new roman,times" size="3"> </font></p><p><font face="times new roman,times" size="3">Clan match happened : Feeder vs. Hacker, seems like we won, after a good and difficult game. Unfortunately I was away during the match.  Seems like after all the namings we dint feed and they dint hack lolz!</font></p><p><font face="times new roman,times" size="3"> </font></p><p><font face="times new roman,times" size="3">Odd thing happening is all friends mentioned above are playing well only among our team. If they forced to switch or if shuffle players mode is put, they invariably end up losing. (ask ice about this :D)  And someday im gonna get caught : I sometimes switch because opposing team keeps whining & crying - before switch along with frnds my score''ll be like 4-0 (K-D) , after switch and some time it will be like 4-5 (K-D). This is necessary more often these days because opp. players leave after seeing our play sometimes lol....</font></p><p><font face="times new roman,times" size="3">We play for fun! No abusing mostly, No hard feelings.  </font></p>', CAST(0x00009C57015B7150 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'FEEDER-STORIES', N'FEEDER STORIES', N'<div align="center">
 <font size="5"><strong>FEEDER STORIES</strong></font><br />
</div>
<p>
<font size="3">First of all i want to thanks every one in feeder group of our TCE [24 hour project mates "We wont care about eating ,sleeping,studying,''bathing'',itching,door knocking,Even powercut".etc.,during project hours"].........</font><br />
<br />
<font size="3"><em><strong>Feeder~Zasz:-</strong></em></font><br />
<strong>
  Intro             : </strong>  T.Chandrasekar,CSE,B.E,TCE<br />
<strong>
  Role in DOTA :</strong>   He is dedicated to his life in every game to get victory,by giving excellent guidance to his parters....<br />
 <strong> Conclusion    :  </strong> For giving excellent idea''s most of the time he wants to be a observer and counting re-spawn time....<br />
<strong>
  Statements   :</strong>   He states that "<strong>Kill himself or level up the Roshan or Better be a Observer</strong>"<br />
<br />
<font size="3"><em><strong>
F</strong></em><em><strong>eeder~Tony:-</strong></em></font><br />
  <strong>Intro              : </strong>  M.Desinghrajan,ECE,B.E,TCE<br />
 <strong> Role in DOTA  :</strong>   To improve and expanding the DOTA clan ..He is encouraging  beginners by putting team against experienced gamers...<br />
  <strong>Conclusion     : </strong>  Most of the beginners now improved and some beginners are used as a couriers by him...<br />
  <strong>Statements    : </strong>  He states that "<strong>Die with "0" gold or Splits your gold to Scourge or Sentinel not to Heroes</strong> "<br />
<br />
<font size="3">
<em><strong>F</strong></em><em><strong>eeder~Samjef :-</strong></em></font><br />
  <strong>Intro               :</strong>   Mano samson,Civil,B.E,Tce<br />
  <strong>Role in DOTA   : </strong> To making unknown heroes into favorite heroes in DOTA..No one knows his talent and next step of samson in dota inculing himself...<br />
 <strong> Conclusion      :  </strong>After 15 loses of continuous combat he had the confident that will get victory in next match..[He knows verywell 16 match also going to loose...Still continuous upto next day also ]...Jesus only helps him....<br />
  <strong>Statements     :</strong>  He states that "<strong>Improve your Aura And stand before tower wait for some time and Feed to enemy not to creeps</strong> "<br />
<br />
<font size="3"><em><strong>Feeder~Pradeep:-</strong></em> </font><br />
 <strong> Intro                : </strong> M.Pradeep,Mech,B.E,TCE<br />
 <strong> Role in dota     : </strong> He wants learn dota like zasz and tony ...still learning...He  want to defeat enemy teammates by considering own mechanical department...Even courier itself wont fear about Feeder~Pradeep...<br />
  <strong>Conclusion       : </strong> Most of the time he selects enemy heroes and using their spells...After finding own hero he sent his hero into enemy''s moon well by confusing....And fighting with tower until he die "After the lose of victory he remove or delete the game from his PC  ..<br />
  <strong>Statements      : </strong> He states that "<strong>Do or Die infront of Tower ..Vanthey Matharam</strong>"<br />
<br />
<font size="3"><em><strong>Feeder~Nitin  :-</strong></em></font><br />
 <strong> Intro              : </strong>Nitin Guntour,ECE,B.E,TCE<br />
  <strong>Role in dota   :</strong> He wont care about victory or loose of own team....But only aim is to kill the very dangerous neutral creeps..If he dead by neutral creeps [Always 90% dies]he take revenge..He knows the best farming technology .At the end of the game he comes with costly items in his inventory...[because (S)he is the only item in our hostel]...<br />
  <strong>Conclusion     :</strong> He will surely get the best Kill Stealer And Neutral killer Award in future..He doesnt wear shoe until the match quit.. <br />
  <strong>Statements    : </strong> He states that "<strong>Please Beware of Neutral creeps they are dangerous to DOTA</strong>"<br />
<br />
<font size="3"><em><strong>Feeder~Muthu  :-</strong></em></font><br />
  <strong>Intro               :</strong> MuthuKrishnan,EEE,B.E,TCE<br />
  <strong>Role in DOTA  :</strong> He Gang with team players to kill one hero ...after left of his team mates  he still ganging alone with enemy heroes not considering Tower and enemy creeps.. like Vijyakanth... Enemy heroes consider his innocence and leave him into neutral creeps to finish him ...<br />
 <strong> Conclusion     :</strong> For the frequent use of lightining revenent ICEFROG decides to change  completely and remaked that hero...<br />
  <strong>Statements    :</strong> He states that "<strong>If i gang i will be die If i die i will be a Courier</strong>" <br />
<br />
<font size="3"><em><strong>Feeder~Maddy   :-</strong></em></font><br />
<strong>
  Intro             : </strong>S.Madavan,ECE,B.E,TCE<br />
<strong>
  Role in dota  :</strong>"Atleast getting one victory per day" is ambition of maddy..He accepts any combination of teams with him even beginners..but not with Nitin....he is the excellent player in dota...But not a farmer,kilstealer,ganger,pusher,defender,..Then How?...He foolished by own team mates ..<br />
<strong>
  Conclusion    :</strong> Due to his intelligence and talent his team mates steal his inventory items from circle of power ..nobody even creeps itself allows him to get final kill of heroes,towers..etc..  <br />
 <strong> Statements   :</strong> he states that "<strong>Some one make me victory ..I need one Victory</strong>" 
</p>
<p>
 
</p>
<p>
<strong><font size="3"><em> Feeder~Qqqqqq:-</em></font></strong>
<br />
<strong>  </strong>
</p>
<p>
<strong>  Intro                  :</strong> Sivakumar,Mech,B.E,TCE
<br />
<strong>  Role in dota       :</strong> He never choose a hero from tauren .Only by random mode he gets random heroes....But he manages with any unknown heroes(If nitin is there he manages Nitin also as a heroine).....Because of random hero his victory status also random......
<br />
<strong>  Conclusion         :</strong> For more detail contact "Feeder~Nitin"and"Feeder ~Ravi"....Both are calling him as "Matchan","Mama","Dear",etc.
<br />
  <strong>Statements        :</strong> He states that "<strong>Nitin is only my property, QQQQq is directly proposal into Nitin,and QQQQQ is Inversly proportional into kamalanathan</strong>" 
<br />
 
<br />
<font size="3"><em><strong>Feeder~Imini       :</strong></em>-</font>
<br />
<br />
  <strong>Intro                      :  </strong> Sudhahar,Mech,B.E,TCE
<br />
  <strong>Role in dota           :  </strong>What to do ?He is Beginner  to dota...But somebody begging him to leave from dota ...He never goes alone to combat....HaHaHa...if he goes He wont return to base.....   Some  enemies instead of killing him use as a neutral creap for their time pass..finally he will be used for ganging of their teams..simply like"<strong>KIDNAPPING</strong> and <strong>RAPPING</strong>" ..
<br />
  <strong>Conclusion             :  </strong>So noone helps for Imini....I''m very proud of him and i wish him to be
a best team leader of our feeder clan..So that We will reach the world
of gareana immediately...
<br />
  <strong>Statements            :</strong>  He states that "<strong>I am the best player in RPS warcraft3 ..But Noone knows my powers in DoTa...If it continues I will say TaTa to DoTa</strong>" 
<br />
 
<br />
<font size="3"><em><strong>Feeder~6x-xxxxxx       :</strong></em>-</font> 
<br />
 
<br />
  <strong>Intro                      :  </strong> Balaji Vedarethinam
<br />
  <strong>Role in dota           :  </strong>Mostly<strong> </strong>after the 1st 3 minutes he shares control of his hero to others so that we may increase his hero level, while he goes afk. When the message shows up that all have been given control of 6x units someone invariably sells his items, thinking he left the game.. thereby getting 0 extra gold and permanantly making him weak.
<br />
  <strong>Conclusion             :  </strong>He has been level 11 for so long that garena administrators put up a special meeting. They decided to upgrade him to level 12 on the basis of sheer boredom. 
<br />
  <strong>Statements            :</strong>  He states that "<strong>Ayyo endha hero eduthaalum nalla velayaaduranae indha 1_Hp .</strong> <strong>Goyyala saavu da.</strong>" 
<br />
 
<br />
</p>
<p align="center">
<font size="3"><font face="georgia,palatino">For more updates, Suggestions  and details reply me and coment me.....</font></font><strong><font size="3"><font face="georgia,palatino">    "Born to Feed"</font></font></strong>
</p>
<p>
 
</p>
<p>
 
</p>
', CAST(0x00009C2900D44F90 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Five-Minute-ASPNETMVC', N'Model - View - Controller - The RoR Inspired Design Pattern!', N'<!--
/* Font Definitions */
@font-face
{font-family:Wingdings;
panose-1:5 0 0 0 0 0 0 0 0 0;
mso-font-charset:2;
mso-generic-font-family:auto;
mso-font-pitch:variable;
mso-font-signature:0 268435456 0 0 -2147483648 0;}
@font-face
{font-family:"Cambria Math";
panose-1:2 4 5 3 5 4 6 3 2 4;
mso-font-charset:1;
mso-generic-font-family:roman;
mso-font-format:other;
mso-font-pitch:variable;
mso-font-signature:0 0 0 0 0 0;}
@font-face
{font-family:Calibri;
panose-1:2 15 5 2 2 2 4 3 2 4;
mso-font-charset:0;
mso-generic-font-family:swiss;
mso-font-pitch:variable;
mso-font-signature:-1610611985 1073750139 0 0 159 0;}
/* Style Definitions */
p.MsoNormal, li.MsoNormal, div.MsoNormal
{mso-style-unhide:no;
mso-style-qformat:yes;
mso-style-parent:"";
margin-top:0in;
margin-right:0in;
margin-bottom:10.0pt;
margin-left:0in;
line-height:115%;
mso-pagination:widow-orphan;
font-size:11.0pt;
font-family:"Calibri","sans-serif";
mso-ascii-font-family:Calibri;
mso-ascii-theme-font:minor-latin;
mso-fareast-font-family:Calibri;
mso-fareast-theme-font:minor-latin;
mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:"Times New Roman";
mso-bidi-theme-font:minor-bidi;}
a:link, span.MsoHyperlink
{mso-style-priority:99;
color:blue;
mso-themecolor:hyperlink;
text-decoration:underline;
text-underline:single;}
a:visited, span.MsoHyperlinkFollowed
{mso-style-noshow:yes;
mso-style-priority:99;
color:purple;
mso-themecolor:followedhyperlink;
text-decoration:underline;
text-underline:single;}
p.MsoListParagraph, li.MsoListParagraph, div.MsoListParagraph
{mso-style-priority:34;
mso-style-unhide:no;
mso-style-qformat:yes;
margin-top:0in;
margin-right:0in;
margin-bottom:10.0pt;
margin-left:.5in;
mso-add-space:auto;
line-height:115%;
mso-pagination:widow-orphan;
font-size:11.0pt;
font-family:"Calibri","sans-serif";
mso-ascii-font-family:Calibri;
mso-ascii-theme-font:minor-latin;
mso-fareast-font-family:Calibri;
mso-fareast-theme-font:minor-latin;
mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:"Times New Roman";
mso-bidi-theme-font:minor-bidi;}
p.MsoListParagraphCxSpFirst, li.MsoListParagraphCxSpFirst, div.MsoListParagraphCxSpFirst
{mso-style-priority:34;
mso-style-unhide:no;
mso-style-qformat:yes;
mso-style-type:export-only;
margin-top:0in;
margin-right:0in;
margin-bottom:0in;
margin-left:.5in;
margin-bottom:.0001pt;
mso-add-space:auto;
line-height:115%;
mso-pagination:widow-orphan;
font-size:11.0pt;
font-family:"Calibri","sans-serif";
mso-ascii-font-family:Calibri;
mso-ascii-theme-font:minor-latin;
mso-fareast-font-family:Calibri;
mso-fareast-theme-font:minor-latin;
mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:"Times New Roman";
mso-bidi-theme-font:minor-bidi;}
p.MsoListParagraphCxSpMiddle, li.MsoListParagraphCxSpMiddle, div.MsoListParagraphCxSpMiddle
{mso-style-priority:34;
mso-style-unhide:no;
mso-style-qformat:yes;
mso-style-type:export-only;
margin-top:0in;
margin-right:0in;
margin-bottom:0in;
margin-left:.5in;
margin-bottom:.0001pt;
mso-add-space:auto;
line-height:115%;
mso-pagination:widow-orphan;
font-size:11.0pt;
font-family:"Calibri","sans-serif";
mso-ascii-font-family:Calibri;
mso-ascii-theme-font:minor-latin;
mso-fareast-font-family:Calibri;
mso-fareast-theme-font:minor-latin;
mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:"Times New Roman";
mso-bidi-theme-font:minor-bidi;}
p.MsoListParagraphCxSpLast, li.MsoListParagraphCxSpLast, div.MsoListParagraphCxSpLast
{mso-style-priority:34;
mso-style-unhide:no;
mso-style-qformat:yes;
mso-style-type:export-only;
margin-top:0in;
margin-right:0in;
margin-bottom:10.0pt;
margin-left:.5in;
mso-add-space:auto;
line-height:115%;
mso-pagination:widow-orphan;
font-size:11.0pt;
font-family:"Calibri","sans-serif";
mso-ascii-font-family:Calibri;
mso-ascii-theme-font:minor-latin;
mso-fareast-font-family:Calibri;
mso-fareast-theme-font:minor-latin;
mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:"Times New Roman";
mso-bidi-theme-font:minor-bidi;}
.MsoChpDefault
{mso-style-type:export-only;
mso-default-props:yes;
mso-ascii-font-family:Calibri;
mso-ascii-theme-font:minor-latin;
mso-fareast-font-family:Calibri;
mso-fareast-theme-font:minor-latin;
mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:"Times New Roman";
mso-bidi-theme-font:minor-bidi;}
.MsoPapDefault
{mso-style-type:export-only;
margin-bottom:10.0pt;
line-height:115%;}
@page Section1
{size:8.5in 11.0in;
margin:1.0in 1.0in 1.0in 1.0in;
mso-header-margin:.5in;
mso-footer-margin:.5in;
mso-paper-source:0;}
div.Section1
{page:Section1;}
/* List Definitions */
@list l0
{mso-list-id:826550638;
mso-list-type:hybrid;
mso-list-template-ids:1171011880 67698699 67698713 67698715 67698703 67698713 67698715 67698703 67698713 67698715;}
@list l0:level1
{mso-level-number-format:bullet;
mso-level-text:;
mso-level-tab-stop:none;
mso-level-number-position:left;
text-indent:-.25in;
font-family:Wingdings;
mso-ansi-font-weight:normal;}
@list l1
{mso-list-id:1408576703;
mso-list-template-ids:-1683183432;}
@list l1:level1
{mso-level-number-format:bullet;
mso-level-text:;
mso-level-tab-stop:.5in;
mso-level-number-position:left;
text-indent:-.25in;
mso-ansi-font-size:10.0pt;
font-family:Symbol;}
@list l2
{mso-list-id:1719813542;
mso-list-type:hybrid;
mso-list-template-ids:1959924884 67698699 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l2:level1
{mso-level-number-format:bullet;
mso-level-text:;
mso-level-tab-stop:none;
mso-level-number-position:left;
text-indent:-.25in;
font-family:Wingdings;}
@list l3
{mso-list-id:1994021929;
mso-list-type:hybrid;
mso-list-template-ids:-1803518670 67698699 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l3:level1
{mso-level-number-format:bullet;
mso-level-text:;
mso-level-tab-stop:none;
mso-level-number-position:left;
text-indent:-.25in;
font-family:Wingdings;}
ol
{margin-bottom:0in;}
ul
{margin-bottom:0in;}
-->
<blockquote>
	<p style="line-height: normal" class="MsoNormal">
	<strong><span style="font-size: 24pt; font-family: ''Times New Roman'',''serif''">ASP.NET MVC In Five Minutes</span></strong> 
	</p>
	<p class="MsoNormal">
	A <strong>Model</strong> is a coded representation of some conceptual entity in real-life and is generally persisted in database. eg. Post class in a Blog or Account class in a Banking application. Objects of these models are often persisted. 
	</p>
	<p class="MsoNormal">
	A <strong>View</strong> is a .aspx page together with associated .master and .ascx files. Each Controller has one or more views under its control. A <strong>View</strong> must be capable of displaying data given to it by the Controller. 
	</p>
	<p class="MsoNormal">
	A <strong>Controller</strong> handles user interaction, work with the model, and ultimately select a view to render that displays UI. 
	</p>
	<p class="MsoNormal">
	The best living example and most popular implementation of the MVC design pattern is the Ruby-on-Rails framework. You can get InstantRails[MySQL;Ruby;Rails;Apache] can be got in rubyonrails.org. 
	</p>
	<p class="MsoNormal">
	An MVC ASP.NET app has the following folders: 
	</p>
	<ul style="margin-top: 0in">
		<li class="MsoNormal"><strong>App_Data</strong> folder. Physical store for data. </li>
		<li class="MsoNormal"><strong>Content</strong> folder. For images .js, and .css files.</li>
		<li class="MsoNormal"><strong>Controllers</strong> folder. Contains the Controllers. All classes here are usually inherited from “System.Web.Mvc.Controller” and NamingConvention (compulsory) : Suffix with Controller. Eg. HomeController.</li>
		<li class="MsoNormal"><strong>Models</strong> folder. Coded Representation Classes that have ability to persist/retrieve their objects.</li>
		<li class="MsoNormal"><strong>Views</strong> folder. Contains a subfolder for each controller, and a subfolder called <strong>Shared</strong>. Inside every subfolder are a collection of .aspx es whose names are the “View Names”. When a Controller selects a view, It gives a ‘View Name’. The ASP.NET runtime goes to <strong>“</strong>Views-> <folderWithTheSameNameAsController> -> About.aspx and renders the page, sends it to client.</li>
		<li class="MsoNormal"><strong>Views/Shared </strong>contains all the shared views common to all Controllers. Eg. .master & .ascx files.</li>
	</ul>
	<p class="MsoNormal">
	<em>Understand and Create an MVC application:</em> 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraphCxSpFirst">
	<!--[if !supportLists]--><span style="font-family: Wingdings"><span>Ø<span style="font: 7pt ''Times New Roman''; font-size-adjust: none; font-stretch: normal">  </span></span></span><!--[endif]-->Put a Default.aspx with no markup and code-behind that simply Response.Redirects() to ~/Home. <strong>In MVC there are no Urls that point to actual files. Only Routes that point to Controllers. </strong>Add reference to the System.Web. [Abstractions, Mvc, Routing] assemblies. 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraphCxSpMiddle">
	<!--[if !supportLists]--><span style="font-family: Wingdings"><span>Ø<span style="font: 7pt ''Times New Roman''; font-size-adjust: none; font-stretch: normal">  </span></span></span><!--[endif]--><em>[A request </em><a href="http://www.contoso.com/"><em>http://www.contoso.com/</em></a><em> comes; redirected to </em><a href="http://www.contoso.com/Home%20"><em>http://www.contoso.com/Home</em></a><em>]</em> 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraphCxSpMiddle">
	<!--[if !supportLists]--><span style="font-family: Wingdings"><span>Ø<span style="font: 7pt ''Times New Roman''; font-size-adjust: none; font-stretch: normal">  </span></span></span><!--[endif]-->Create a class in the Controllers folder. Derive it from System.Web.Mvc.Controller, Name it <em>HomeController</em> (thus following the NamingRequirement). What do controllers do? They respond to user input through “Actions”:such as rendering a view or redirecting or get data from the model. All public methods in the controller class are called “Action Methods”. ( unless marked by the “NonAction” Attribute) Create a public method public ActionResult Index() (leave empty now). 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraphCxSpLast">
	<!--[if !supportLists]--><span style="font-family: Wingdings"><span>Ø<span style="font: 7pt ''Times New Roman''; font-size-adjust: none; font-stretch: normal">  </span></span></span><!--[endif]-->Now we need to create a Route that causes <strong><span style="color: black">/Home </span></strong><span style="color: black">to point to <em>HomeController</em> controller. Create by going to the Global.asax.cs and writing this in the static function called by the AppStart EventHandler. This file has all the routes for the entire application.</span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; color: blue; font-family: ''Courier New''"><span>      </span>namespace</span><span style="font-size: 10pt; font-family: ''Courier New''"> Portfolio</span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>      </span>{</span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>    </span><span>  </span><span style="color: blue">public</span> <span style="color: blue">class</span> <span style="color: #2b91af">GlobalApplication</span> : System.Web.<span style="color: #2b91af">HttpApplication</span></span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>    </span><span>  </span>{</span> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; color: blue; font-family: ''Courier New''"><span>      </span>public</span><span style="font-size: 10pt; font-family: ''Courier New''"> <span style="color: blue">static</span> <span style="color: blue">void</span> RegisterRoutes(<span style="color: #2b91af">RouteCollection</span> routes)</span> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>      </span>{</span> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>            </span>routes.IgnoreRoute(<span style="color: #a31515">"{resource}.axd/{*pathInfo}"</span>);</span> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"></span>
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>            </span>routes.MapRoute</span> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>            </span>(</span> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>            </span><span style="color: #a31515">"Default"</span>,<span>      </span><span>              </span><span style="color: green">// Just a name for the route</span></span> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; color: green; font-family: ''Courier New''"></span>
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; color: green; font-family: ''Courier New''"><span>      </span></span><span style="font-size: 10pt; font-family: ''Courier New''"><span> </span><span>     </span><span style="color: #a31515">"{controller}/{action}/{id}"</span>, <span style="color: green">// One of the preset patterns</span></span> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>            </span><span style="color: blue">new</span> { controller = <span style="color: #a31515">"Home"</span>, action = <span style="color: #a31515">"Index"</span>, id = <span style="color: #a31515">""</span> </span>
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; color: green; font-family: ''Courier New''"><span>                  </span>// Anonymous object with public variables having same name</span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; color: green; font-family: ''Courier New''">                  // as the words used in the pattern. These form the default</span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; color: green; font-family: ''Courier New''">                  // values in case the request url only partially matches.</span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; color: green; font-family: ''Courier New''"><span>                  </span>// All the variables are required.</span><strong><span style="font-size: 10pt; font-family: ''Courier New''"></span></strong> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>  </span><span>          </span>);</span> 
	</p>
	<p style="margin: 0in 0in 0pt 0.5in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>      </span>}</span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"></span>
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>      </span><span style="color: blue">protected</span> <span style="color: blue">void</span> Application_Start()</span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>      </span>{</span> 
	</p>
	<p style="margin-bottom: 0pt; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>            </span>RegisterRoutes(<span style="color: #2b91af">RouteTable</span>.Routes);</span> 
	</p>
	<p class="MsoNormal">
	<span style="font-size: 10pt; line-height: 115%; font-family: ''Courier New''"><span>      </span>}</span> 
	</p>
	<p class="MsoNormal">
	<span style="font-size: 10pt; line-height: 115%; font-family: ''Courier New''"><span>      </span>}}</span> 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraphCxSpFirst">
	<!--[if !supportLists]--><span style="font-family: Wingdings"><span>Ø<span style="font: 7pt ''Times New Roman''; font-size-adjust: none; font-stretch: normal">  </span></span></span><!--[endif]--><em>[The request to </em><a href="http://www.contoso.com/Home%20"><em>http://www.contoso.com/Home</em></a> matches the above route partially.<em>]</em> 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraphCxSpMiddle">
	<!--[if !supportLists]--><span style="font-family: Wingdings"><span>Ø<span style="font: 7pt ''Times New Roman''; font-size-adjust: none; font-stretch: normal">  </span></span></span><!--[endif]--><em>[ASP.NET runtime applies the default values to action and ID</em>.<em>]</em> 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraphCxSpMiddle">
	<!--[if !supportLists]--><span style="font-family: Wingdings"><span>Ø<span style="font: 7pt ''Times New Roman''; font-size-adjust: none; font-stretch: normal">  </span></span></span><!--[endif]--><em>[ASP.NET runtime creates instace of Home controller and calls the Index action method on it.]</em> 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraphCxSpLast">
	<!--[if !supportLists]--><span style="font-family: Wingdings"><span>Ø<span style="font: 7pt ''Times New Roman''; font-size-adjust: none; font-stretch: normal">  </span></span></span><!--[endif]-->Now we need to code up the Index method() as follows 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; color: blue; font-family: ''Courier New''">namespace</span><span style="font-size: 10pt; font-family: ''Courier New''"> Portfolio.Controllers</span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''">{</span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>    </span><span style="color: blue">public</span> <span style="color: blue">class</span> <span style="color: #2b91af">HomeController</span> : <span style="color: #2b91af">Controller</span></span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>    </span>{</span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>        </span><span style="color: blue">public</span> <span style="color: #2b91af">ActionResult</span> Index()</span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>        </span>{</span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>            </span>ViewData[<span style="color: #a31515">"Title"</span>] = <span style="color: #a31515">"Home Page"</span>;</span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>            </span>ViewData[<span style="color: #a31515">"Message"</span>] = <span style="color: #a31515">"Welcome to ASP.NET MVC!"</span>;</span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"></span>
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>            </span><span style="color: blue">return</span> View();</span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>        </span>}</span> 
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"></span>
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>        </span><span style="color: green">// Other action methods ...</span><span>    </span></span>
	</p>
	<p style="margin: 0in 0in 0pt 1in; line-height: normal" class="MsoNormal">
	<span style="font-size: 10pt; font-family: ''Courier New''"><span>      </span>}</span> 
	</p>
	<p style="margin-left: 1in" class="MsoNormal">
	<span style="font-size: 10pt; line-height: 115%; font-family: ''Courier New''">}</span> 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraph">
	<!--[if !supportLists]--><span style="font-family: Wingdings"><span>Ø<span style="font: 7pt ''Times New Roman''; font-size-adjust: none; font-stretch: normal">  </span></span></span><!--[endif]--><span>The View()method without the arguments calls the Page Rendering upon the ASPX page with the same name as the Action Method , in this case Index.aspx. This page it searches for in the Folder <strong>Views/Home </strong>which may possess master pages and usercontrols in the shared folder.</span> 
	</p>
	<p style="text-indent: -0.25in" class="MsoListParagraph">
	 
	</p>
	<p>
	That''s  it folks ASPNETMVC is in your pocket .. This file has a more thorough information you might want to see  <a rel="enclosure" href="/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\ASPmvc.docx">ASPmvc.docx (188.11 kb)</a> 
	</p>
</blockquote>
', CAST(0x00009ADB01822B60 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'From-The-Studio-To-Release', N'From The Studio To Release', N'<p>
<font face="comic sans ms,sand"><font size="6">When you got a working site in Visual Studio<br />
</font></font>
</p>
<ol>
	<li><font size="3">First thing you''ll be having "debug=true" attribute as part of all the page directives. Take all this out to secure your site and increase performance. Now debug symbols and code are not inserted into the end result</font></li>
	<li><font size="3">Modify Web.Config to include <customErrors> Section to default redirect errors that might just creep in, to user friendly Aspx or Html. There is no end to web.config based modification. For full schema of elements in web.config and their meaning <a href="http://msdn.microsoft.com/en-us/library/b5ysx397(VS.71).aspx" target="_blank" title="Web.config schema">go to MSDN</a> </font></li>
	<li><font size="3">ASP.NET applies configuration settings to resources in a hierarchical manner. Web.config files supply configuration information to the directories in which they are located and to all child directories. The configuration settings for a Web resource are supplied by the configuration file located in the same directory as the resource and by all configuration files in all parent directories</font></li>
	<li><font size="3">Optimizations such as white-space-stripping-csshandler and RegEx-preprocessing-JScripthandlers go a long way improving network load reduction and caching.</font></li>
	<li><font size="3">DiscountASP.net is the best host i''ve seen but they are not cheap. <a href="http://www.discountasp.net">See</a> for yourself, there are other hosts: Choose one that offers:</font> 
	<ol>
		<li><font size="3">ASP.NET 3.5 hosting</font></li>
		<li><font size="3">MS SQL 2005 (or) MS SQL 2008 hosting</font></li>
		<li><font size="3">Unlimited(or suitably large) Access hosting</font></li>
		<li><font size="3">IIS 6 is fine but IIS 7 in ASP.NET Integration mode is way better as available in DiscounASP</font></li>
		<li><font size="3">Atleast 500 mb webspace & 50 mb SQL(Database) space</font></li>
		<li><font size="3">MySQL hosting(not necessary , but for future-proofing), with optional availability of PHP scripting(current host offers a website that can feature all three(ColdFusion&Pyhton) in the same site)</font></li>
		<li><font size="3">Atleast 80GB per month bandwidth</font></li>
		<li><font size="3">And domain name registration facility, along with atleast 20 subdomains</font></li>
		<li><font size="3">Moste Importante : 2 or more FTP accounts and an SMTP,POP3 & forwarding accounts for use from within code</font></li>
	</ol>
	<font size="3"><br />
	</font></li>
	<li><font size="3">Get your host in order and get a ControlPanel offerred by most Hosts(usually it is the HELM control panel for windows hosting)<br />
	</font></li>
	<li><font size="3">From this controlpanel you create your database file and create a user and password for it.<br />
	</font></li>
	<li><font size="3">To transfer schema and data from your current Visual Studio created Database to your host database you need:</font> 
	<ol>
		<li><font size="3">DTSWizard available as part of MSSQL Express Toolkit [ </font><font size="2">C:\Program Files\Microsoft SQL Server\90\DTS\Binn\DTSWizard.exe</font> <font size="3">]</font><font size="3"> </font><font size="2"><a href="http://www.microsoft.com/downloads/details.aspx?FamilyId=C243A5AE-4BD1-4E3D-94B8-5A0F62BF7796&DisplayLang=en">http://www.microsoft.com/downloads/details.aspx?FamilyId= C243A5AE-4BD1-4E3D-94B8-5A0F62BF7796&DisplayLang=en</a></font><br />
		</li>
		<li><font size="3">SSMSE(SQL Server Management Studio Express) if you''re using the free express editions everywhere like I am</font><font face="Verdana, Arial, Helvetica" size="2"><a href="http://www.microsoft.com/downloads/details.aspx?FamilyId=C243A5AE-4BD1-4E3D-94B8-5A0F62BF7796&DisplayLang=en" target="_blank" title="http://www.microsoft.com/downloads/details.aspx?FamilyId=C243A5AE-4BD1-4E3D-94B8-5A0F62BF7796&DisplayLang=en"> http://www.microsoft.com/downloads/details.aspx?FamilyId= C243A5AE-4BD1-4E3D-94B8-5A0F62BF7796&DisplayLang=en</a></font></li>
		<li><font size="3">Both of these expect MSXML 6.0, MS SQL 2005 Express Edition, Visual Studio, .NET FX >2.0 to be present on your computer already.</font></li>
		<li><font size="3">Using the name of the sql server your host has provided(eg: discountsql.discountasp.net) you can connect your management studio and DTSWizard to their server.</font></li>
		<li><font size="3">Use DTSWizard to transfer all your tables, views, and the data.</font></li>
		<li><font size="3">Use SSMSE to create a .sql file for your StoredProcs (from Generate script option you get from selecting all the storedprocs)</font></li>
		<li><font size="3">Delete all comments in this .sql file and execute it in the remote database using the SSMS</font></li>
	</ol>
	<br />
	</li>
	<li><font size="3">Once your data schema and functionality(tables,views,relationships,storedprocs) are uploaded into the host database, download an FTP software for your web site file(<a href="/ZaszBlog/Admin/Pages/www.cuteftp.com" target="_blank">CuteFTP</a>, <a href="http://filezilla-project.org/download.php" target="_blank">FileZilla</a>)</font></li>
	<li><font size="3">Change the connection strings in the web.config files and in the code files to point to your new database in the host(They would probably have given you an example)</font></li>
	<li><font size="3">Then upload all files to the wwwroot folder in your virtual directory , which is seen in the ftp client after providing the ftp connection details your Host has given</font></li>
	<li><font size="3">Then try out your domain name in the browser to check for any nonconformities, errors</font><img src="/ZaszBlog/Admin/TinyMCE/plugins/emotions/images/smiley-innocent.gif" border="0" alt="Innocent" title="Innocent" width="18" height="18" /><font size="3"> and smoothen ''em out. The domain name will take atleast 2-3 days to spread through the internet</font></li>
	<li><font size="3">Css works in different browsers differently. Different resolutions will give odd renderings.. check all these out and hook up Google Analytics and AdSense if necessary<br />
	</font></li>
</ol>
', CAST(0x00009A97008D2CA0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Game-On', N'Game On!', N'<p align="left">
 
</p>
<p align="left">
    Stop reading if you don''t know that Starcraft 2 and Diablo 3 have been announced by Blizzard. Put up a fansite for starcraft 2 in this site .<a href="http://chandruon.net/Starcraft" title="Starcraft subdomain"> http://chandruon.net/Starcraft .</a> Excellent gameplay videos at <a href="http://www.starcraft2.com" title="Starcraft 2">www.starcraft2.com</a> and <a href="http://www.diablo3.com" title="Diablo 3">www.diablo3.com</a> . There''s also the spanking new idea out there : Spore - Seems you can play all the way from a micro organism to a interplanetery conquests.... 
</p>
<p align="left">
 
</p>
<p>
<img style="width: 333px; height: 245px" src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\ss1%5b1%5d.jpg" border="2" alt="Terran Marine" title="Terran Marine" hspace="10" vspace="10" width="333" height="245" />
</p>
<p>
 
</p>
<p>
    XBOX : Finished Blacksite and now about to finish Assasin''s Creed - this game does get monotonous after a while. Incredibly realistic and detailed world, it would''ve been greatest if more cut scenes and cinematics adorned the missions. The idea and story is also great. A must play for prince of persia fanatics. Overlord for XBOX is also a nice game though I''ve already finished the PC version of it. 
</p>
<p>
 
</p>
<p>
    But don''t forget the olden golden games : Warcraft III, Tachyon, Tzar, BattleRealms, Age of Empires III & Mythology, Starcraft:Brood War, Red Alert & Yuri''s Revenge, Renegade, Commandos BEL & BTCOD. Anyone who also loves and enjoys the above games - leave a comment. I would like to link back to your blog. Meanwhilehaving seen da diablo III movies - am just returning back to my diablo 2 : LOD and playin again with the ever-powerful Necromancer. 
</p>
<p>
 
</p>
<p>
    Hope there comes more freeform space FPS or TPS  games like Tachyon and DarkstarOne : Freelancer Jake Logan, Spaceman Ist class and Dr.Gordon Freeman, Phd Anomalous Materials are real enough for me. 
</p>
<p>
 
 
</p>
<p>
 
</p>
<div style="overflow: scroll; width: 640px">
<img style="width: 800px; height: 600px" src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\ss87%5b1%5d.jpg" border="2" alt="Protoss & Zerg" title="Protoss & Zerg" hspace="5" vspace="5" width="640" height="480" align="middle" />
</div>
  
<div style="overflow: scroll; width: 640px">
<img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\ss89%5b1%5d.jpg" border="2" alt="Zeratul" title="Zeratul" hspace="5" vspace="5" width="800" height="490" align="middle" />
</div>
', CAST(0x00009AED00CFEA90 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61', N'Getting started with Apache Struts 2 , with Netbeans 6.1', N'<p>
 
</p>
<p>
Same post with Images in PDF Format :<a rel="enclosure" href="/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\Getting+started+with+Apache+Struts+2.pdf">Getting started with Apache Struts 2 and Netbeans 6.1 in Windows.pdf (1.05 mb)</a>
</p>
<p>
 
</p>
<p>
 There are plenty of guides that tell you how to start with struts 2, but most of them are incomplete or don’t work. This guide even makes sure you have IDE JavaDoc support for struts 2 libraries. (Press Ctrl-Space to get details about methods and classes in struts 2 libraries)
</p>
<p>
<strong>Download Struts 2 here</strong> : <a href="http://struts.apache.org/download.cgi" target="_blank">http://struts.apache.org/download.cgi</a><br />
<br />
    Download the Full Distro, so that we get all libraries and docs. (docs are important if u want to have IDE support help and tooltips and syntax)<br />
<br />
• Full Distribution:<br />
o struts-2.0.11.2-all.zip (91mb) [PGP] [MD5]<br />
<br />
As of this writing , this is the latest version of Struts.<br />
<br />
<strong>Download Netbeans 6.1 here</strong> : <a href="http://www.netbeans.org/downloads/" target="_blank">http://www.netbeans.org/downloads/</a><br />
<strong>or here</strong> : <a href="http://dlc.sun.com.edgesuite.net/netbeans/6.1/final/">http://dlc.sun.com.edgesuite.net/netbeans/6.1/final/</a><br />
<br />
Download the full bundle (under the All column) size about 220 MB. Choose a folder for all your JAVA material that has NO SPACES in its path. Like C:\Java. “C:\Program Files” has a space, so it has some issues with the Sun Application Platform, which you might need after development.<br />
<br />
<font size="2"><strong>Other downloads </strong>:</font><br />
<br />
[These are not necessary now, but just download them while working on this guide]<br />
<br />
<em>1. Eclipse for JavaEE Dev</em> : <a href="http://www.eclipse.org/downloads/">http://www.eclipse.org/downloads/</a><br />
<br />
Eclipse IDE for Java EE Developers (163 MB)<br />
<br />
<em>2. Java Application Platform</em> : <a href="http://java.sun.com/javaee/downloads/index.jsp" target="_blank">http://java.sun.com/javaee/downloads/index.jsp</a><br />
<br />
App Platform + JDK†<br />
<br />
<em>3. Java Standard Edition [SE]</em> : <a href="http://java.sun.com/javase/downloads/index.jsp" target="_blank">http://java.sun.com/javase/downloads/index.jsp</a><br />
<br />
JDK 6 Update 7<br />
<br />
<font size="2"><strong>Install as follows :</strong></font><br />
<br />
This is how a pro I knew advised to set a comp up for Java EE Dev. You can install anywhere, but the Guide will use these assume, this is how you’ve installed things.<br />
<br />
0. Install Java SE (JDK 6 Update 7) to C:\Java\jdk1.6.0_07 and the packaged Java Runtime Environment (Public JRE) to C:\Java\jre1.6.0_07 Note : No Spaces in the path<br />
<br />
1. Extract struts-2.1.2-all.zip to C:\Java . This will create a folder C:\Java \struts-2.1.2<br />
<br />
2. Install Netbeans 6.1 to C:\Java\NetBeans6.1 .[ Note: There is no space in the path]<br />
Along with the Apache Server packed with netbeans, you need to press the customize or advanced button to install the packaged apache server, and to set your own path.<br />
<br />
3. After Netbeans , the packaged apache server will ask for path give C:\Java ApacheTomcat6.0.16 Note: No Space here also.<br />
<br />
My comp is set up like this :<br />
<br />
C:\Java\ ApacheTomcat6.0.16 - from netbeans-6.1-ml-windows setup<br />
<br />
C:\Java\ NetBeans6.1             - from netbeans-6.1-ml-windows setup<br />
<br />
C:\Java\ jdk1.6.0_04              - from jdk-6u4-windows-i586-p setup<br />
<br />
C:\Java\ jre1.6.0_04               - from jdk-6u4-windows-i586-p setup<br />
<br />
C:\Java\ struts-2.1.2               - from struts-2.1.2-all.zip extract<br />
<br />
C:\Java\ Eclipse                      - from eclipse-jee-ganymede-win32 setup<br />
<br />
C:\Java\ AP                            - from java_app_platform_sdk-5_05-windows setup<br />
<br />
C:\Java\glassfish-v2ur2           - from java_app_platform_sdk-5_05-windows setup<br />
<br />
C:\Java\Nwork                        - Netbeans WorkSpace<br />
<br />
C:\Java\Ework                        -Eclipse WorkSpace<br />
<br />
C:\Java\ StrutsBlank                -Contents of struts2-blank-2.1.2.war file<br />
<br />
I Created my POJOs i.e Plain Old Java Objects – Business model classes and helper classes in Eclipse, just to know whats there in the IDE, and compiled them to JAR files. Then I used these JARs in the WebApplication fully done in NetBeans. But leave that, we’ll see how to set up struts 2 and netbeans, fully dev-ready. 
</p>
<p>
 
</p>
<p>
<font size="2"><strong>Important Stuff (so don’t deviate!) :</strong></font><br />
<br />
Create a new Web Application in NetBeans<br />
<br />
File-> New Project..-> Category:Web -> Projects:Web Application<br />
<br />
Choose Java EE5 as the Java EE Version, and Apache Tomcat 6.0.16 as the Server (which we installed from the netbeans setup itself) If the server is not there Add it, choosing the path C:\Java\ApacheTomcat6.0.16 as the home directory of the server. DO NOT ADD ANY Frameworks like struts of JSF now, you can add ‘em later. Click Finish.<br />
<br />
Go to <strong>C:\Java\ struts-2.1.2\apps</strong> folder. Open WinZip. Drag - Drop the struts2-blank-2.1.2.war onto the WinZip window.
Press the Extract button on the top of the WinZip window and extract to <strong>C:\Java\StrutsBlank</strong> . You must type this in cause “StrutsBlank” is a folder WinZip will have to create to place the contents of the WAR file. Come back to NetBeans, Go to Tools-> Libraries, Click on <strong>New Library..</strong> button<br />
<br />
Type in “Struts2Library” as name and Press OK. Then Press <strong>Add JAR/Folder.. </strong>button and in the open file dialog , navigate to <strong>C:\Java\StrutsBlank\WEBINF\lib </strong>Select all the JAR files in there pressing the SHIFT key, and add ‘em. Go to Javadoc Tab, Press <strong>Add Zip/Folder button</strong> and in the Open Folder Dialog navigate to <strong>C:\Java\struts-2.1.2\docs\struts2-core</strong> and select apidocs folder and click <strong>Add Zip/Folder</strong> button in the dialog.<br />
<br />
Press <strong>Ok</strong> that closes the Library Manager dialog box. Now Right Click the Libraries folder in the Projects window in the netbeans IDE, select <strong>Add Library.. </strong>and add the Struts2Library. Navigate to <strong>C:\Java\StrutsBlank </strong>in windows explorer and Drag-Drop the <strong>C:\Java\StrutsBlank\example</strong> folder into the NetBeans Web Pages treenode. Delete the <strong>Web Pages\WEB-INF\web.xml</strong> in netbeans. Drag-Drop the <strong>C:\Java\StrutsBlank\WEB-INF\web.xml</strong> file into the <strong>NetBeans Web Pages\WEB-INF</strong> treenode. Delete the <strong>Web Pages\ index.html</strong> in netbeans. Drag-Drop the <strong>C:\Java\StrutsBlank\index.html</strong> file into the NetBeans Web Pages treenode.<br />
<br />
Right-Click the Source Packages treenode in NetBeans, and New->Java Package, and type in “example” as the package name. This name is necessary to allow the blank app to get working. Drag-Drop all the 6 files in <strong>C:\Java\StrutsBlank\WEB-INF\src\java\example</strong> onto the <strong>Netbeans Source Packages\example</strong> treenode. Drag-Drop the 2 XML files in <strong>C:\Java\StrutsBlank\WEB-INF\src\java example.xml and struts.xml</strong> to the <strong>Source Packages</strong> treenode[ such that they come under the default package]. Thus we have moved all XML and .jsp and .java files from blank app to netbeans. After all that your<br />
Project Explorer will belike : [see image in the PDF; download the PDF using the link provided at the top of this post]<br />
<br />
Build using F11 key.<br />
<br />
NetBeans will have created two folders for you <strong>build</strong> and <strong>dist</strong>. <strong>build\web\WEB-INF\lib</strong> and <strong>build\web\WEB-INF\classes</strong> are automatically created and populated with the JAR files and .class files. <strong>dist</strong> will have the WAR file that you can use to distribute your web app.
</p>
<p>
 
</p>
<p>
Run using F6 key to see the output.
</p>
<p>
 
</p>
<p>
If any error while building or running, Save everything, close netbeans AFTER closing the server by pressing the green square stop button in the serve tab of the netbeans IDE. Then go to task manager close all java.exe process and any and all server process also and reopen netbeans and press f6. I localized to Tamil. You should see Spanish instead of Tamil in the output.
</p>
<p>
<br />
Same post with Images in PDF Format :<a rel="enclosure" href="/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\Getting+started+with+Apache+Struts+2.pdf">Getting started with Apache Struts 2 and Netbeans 6.1 in Windows.pdf (1.05 mb)</a>
 
</p>
', CAST(0x00009B0C015EBD10 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Gin-GWT-Command-Pattern', N'Gin GWT Command Pattern', N'<p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">Here is an application that integrates all the frameworks I''ve been tinkering around till now, and a few new ones. </span></font></p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium"><br /></span></font></p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">Description :</span></font></p><p> </p><p> </p><ul>	<li><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">All requests from client javascript, come as objects of the Command Interface. They are served, intuitively enough by Reply objects.</span></font></li>	<li><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">Due to the above fact, it is possible to cache at the client side -> the command and reply pairs , which has been implemented here using a FIFO Cache. (demonstrated as being faster, with the help of timers) </span></font></li>	<li><span class="Apple-style-span" style="font-family: ''comic sans ms'', sand; font-size: medium">Gin injects dependencies in the GWT code : the EventBus , the Service , the PlaceManager , the Cache. (LRU Cache is plugged in just by implementing one, and changing a line)</span></li>	<li><span class="Apple-style-span" style="font-family: ''comic sans ms'', sand; font-size: medium">An EventBus is used to wire-up events and handlers, thus providing clean seperation of View and Presenter.</span></li>	<li><span class="Apple-style-span" style="font-family: ''comic sans ms'', sand; font-size: medium">gwt-presenter Library is used to implement the entire client side code in MVP pattern.</span></li>	<li><span class="Apple-style-span" style="font-family: ''comic sans ms'', sand; font-size: medium">A standard Grails service is exposed as the GWT service (one of the reasons why Peter Ledbrook decided not to use gwt-dispatcher JAR) . It contains the Hashtable of Commands and Closures . The closures serve the corresponding commands, by redirecting to various controllers and their actions.</span></li></ul><p> </p><p> </p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">Full application was built and run using Idea, (did not open console even once  ) You can avoid console altogether by using the extrenal tools option in Ctrl-Alt-S dialog in Idea 8 and configuring all grails command as an external tool.</span></font></p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium"><br /></span></font></p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">The Grails Gwt Plugin has a few issues, it does not compile the source files on compile-gwt-modules command. It just runs the code to generate javascript files. The author of the plugin did not account for using Gin - Gin needs .class files to reflect upon, which must first exist before compile-gwt-modules command. Workaround is use IDE or run-app or run-gwt-client to compile when using Gin.</span></font></p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium"><br /></span></font></p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">Also run-gwt-client will not work until run-app is executed, because the hosted mode mock browser, also needs the Grails service, which is started only after run-app.</span></font></p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium"><br /></span></font></p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">Facts</span></font></p><p> </p><p> </p><ol>	<li><span class="Apple-style-span" style="font-family: ''comic sans ms'', sand; font-size: medium">GwtPlugin looks for its dependancy jar files in lib/gwt directory when running compile-gwt-modules. IDEA looks for it in the lib directory.</span></li>	<li><span class="Apple-style-span" style="font-family: ''comic sans ms'', sand; font-size: medium">aopalliance-alpha1.jar available at http://sourceforge.net/projects/aopalliance/ is required for guice and gin to run.</span></li>	<li><span class="Apple-style-span" style="font-family: ''comic sans ms'', sand; font-size: medium">While binding using Gin it is essential that the providers are singleton, and that there are no circular dependencies - 2 classes with constructors taking in each other as parameter</span></li></ol><p> </p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium"><br /></span></font></p><p><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">Unzip and press Shift F10 run it. Then use the Main Controller link.</span></font></p><p><a rel="enclosure" href="/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\CommandPattern.7z"><font face="''comic sans ms'', sand"><span class="Apple-style-span" style="font-size: medium">CommandPattern.7z (912.46 kb)</span></font></a></p>', CAST(0x00009CCF0114DB00 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Graduated-!!', N'Graduated !!', N'<p> </p><div style="text-align: center"><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image325.jpg" alt="" width="500" height="375" /></div><p> </p><p> </p><p> </p><p>Thats me on the right! And friends Banrap(left) and Gowtham(mid).  Saw teachers, filled forms, and scheduled gettogethers. Many friends are comin'' to chennai to work.. Me is joins thoughtworks on 23 september if all goes well and me too is going to work in chennai... for the 1st year atleast.</p><p> </p><p>Becoming Alumni isnt going to save me from being given work.. xD Some staff know my number to call me and help ''em with whatever :-)</p><p> </p><p>Garena is there to keep friends in contact !</p><p> </p><div style="text-align: center"><img src="http://chandruon.net/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\smaller.JPG" alt="" /></div><div> </div><div> </div><div>Foremost Row : Ramesh , Gowtham , Banrap , Me , Mohan , Ramasubbu , Velusamy , Deepak , Iniyan. (All kneeling)</div><div> </div><div>I like this pik!</div><div> </div><div> </div><div style="text-align: center"><img style="width: 452px; height: 300px" src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\smaller+grad.JPG" alt="" width="452" height="300" /></div><div> </div><span class="Apple-style-span" style="font-family: ''lucida grande''; color: #333333"><h3 style="font-size: 13px; color: #333333; font-weight: normal; overflow-x: hidden; overflow-y: hidden; padding: 0px; margin: 0px" class="UIIntentionalStory_Message"> </h3><p><span class="UIStory_Message">Me, Abhai kumar(Principal, TCE), GopalaKrishnan(Infosys'' CEO & MD), Kannan(Correspondent, TCE)</span></p><p style="text-align: center"> </p><p> </p></span><div> </div>', CAST(0x00009C500076A700 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Greatest-Content-of-late-2008', N'Greatest Content of late 2008', N'<p><span class="Apple-style-span" style="font-weight: bold">Great Book content : </span></p><p> </p><p>After finishing "Brisingr", I was left a bit let down, lot of description and ordinary day to day stuff that Eragon is doing. No great Magic done , No big War fought.. no adventure ... all i can say is we might expect better from the Second Part of Brisingr, which will come out whenever Paolini decides it comes out.</p><p> </p><p>Clive Cussler new Dirk Pitt novels are out. Asterix - also a few Omnibus series are out - great reading.</p><p> </p><p>JK Rowlings book is also a choice though I haven laid my hands on it yet - the one about that stories of a bard and the wand Deathstick</p><p> </p><p><span class="Apple-style-span" style="font-weight: bold">Great Game content :</span> </p><p> </p><p>Meanwhile Diablo 3 with its Gameplay trailers, Impressive site (featuring Archangel Tyrel), is occupying the attention... damn blizzard takes its time. Thinking of using the fansite kit for diablo also :-)</p><p> </p><p>Prince of Persia is absolutely great... though there''s not much of the story we all like in the previous versions.. </p><p> </p><p><span class="Apple-style-span" style="font-weight: bold">Great Music content :</span></p><p> </p><p>Kayne West  -  808''s and HeartBreak  (album)   [See you in my nightmares ft Lil Wayne]</p><p>Justin Timberlake ft Timbaland  -  Good Foot  (song in album "Mr. Timberlake")</p><p>Gym Class Heros  -  The Quilt  (album) </p><p>T.I. - Paper Trail  (album) </p><p><span class="Apple-tab-span" style="white-space: pre">	</span>-> T.I.-On Top Of The World (Ft. Ludacris & B.O.B.)</p><p><span class="Apple-tab-span" style="white-space: pre">	</span>-> T.I.-Sying Ya Rag (Ft. Swizz Beatz)</p><p><span class="Apple-tab-span" style="white-space: pre">	</span>-> T.I.-Swagga Like Us (Ft. Kanye West, Jay Z & Lil Wayne)</p><p>Nelly  -  Brass Knuckles (album) </p><p>Akon  -  Freedom</p>', CAST(0x00009B7B010A24D0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Groovy-and-Grails-3d-GG', N'Groovy and Grails = GG', N'<p>
 
</p>
<p>
Groovy compiles to Java,  Java compiles to Javascript, in our new App. Groovy is pleasing to look at (more functionality per LOC), we are throwing code blocks into variables and passing them around (Closures). Methods are created and added @ runtime to classes, and a lot of other cool techniques are possible in Java World now.  We used GWT (Google Web Toolkit) to write client centered web applications, and the grails framework for the server side.
</p>
<p>
 
</p>
<p>
Grails is very pleasant to use and is very similar to Rails, generating a complete web app in minutes, and running it. Gin and Guice can also used for dependency Injection, Gin in Google Web Toolkit, and Guice in Server side code. Since all Java code is valid Groovy code, the learning curve for groovy is small, but the skill one needs to acquire is to know where to use the groovy code segments, so that maximum productivity is reached.
</p>
<p>
 
</p>
<p>
For a grails application, if we want to follow the command pattern when client script needs server side functionality, I found that the gwt-dispatcher library in Google Code unsuitable. Far better implementations can be written with groovy code, such as the one in my previous post that has an attachment - a zip containing a application that uses Gin , Guice, gwt-presenter, GWT, event bus architecture, command pattern. An example of server side grails service that follows the command pattern is :
</p>
<p>
 
</p>
<p>
class GwtCommandPatternService implements InitializingBean
</p>
<p>
{
</p>
<p>
 
</p>
<p>
Hashtable clientCommands = new Hashtable()
</p>
<p>
ClientController clientController = new ClientController();
</p>
<p>
boolean transactional = true
</p>
<p>
static expose = [''gwt'']
</p>
<p>
 
</p>
<p>
  Reply serve(Command command)
</p>
<p>
  {
</p>
<p>
    String name = command.getClass().getCanonicalName()
</p>
<p>
    println "Command : " + name
</p>
<p>
    Closure c = (Closure) clientCommands[name]
</p>
<p>
    return c(command) as Reply
</p>
<p>
  }
</p>
<p>
 
</p>
<p>
  def addClientCommand = {String command, Closure c -> clientCommands.put(command, c) }
</p>
<p>
 
</p>
<p>
  def void afterPropertiesSet()
</p>
<p>
  {
</p>
<p>
    addClientCommand GetSuggestions.class.getCanonicalName(), {command -> clientController.index(command) }
</p>
<p>
  } 
</p>
<p>
 
</p>
<p>
} 
</p>
<p>
As seen the server side service has a synchronous serve method. It also has an internal table of Commands and Closures each closure serves the corresponding command. The closures may contain the serving logic themselves, or may delegate to action methods of different controllers. Note that I am implementing InitializingBean and populating the internal commands table in the interface defined method afterPropertiesSet. This is so because the grails framework can create our service as usual -> it needs an empty constructor I am guessing. And somehow the constructor code gets executed 3 times. Check this out by using a println statement in the constructor.
</p>
<p>
 
</p>
<p>
Here is a sample Command pipe which exists on client side and makes use of the command pattern :
</p>
<p>
 
</p>
<p>
public class CommandPipe
</p>
<p>
{
</p>
<p>
    private final Cache commandCache;
</p>
<p>
    private final CPService compatService;
</p>
<p>
 
</p>
<p>
    @Inject
</p>
<p>
    public CommandPipe(Cache commandCache, CPService compatService)
</p>
<p>
    {
</p>
<p>
        this.commandCache = commandCache;
</p>
<p>
 
</p>
<p>
        this.compatService = compatService;
</p>
<p>
    }
</p>
<p>
 
</p>
<p>
    public void serve(final Command command, GotCallback gotCallback)
</p>
<p>
    {
</p>
<p>
        Reply reply = commandCache.serve(command);
</p>
<p>
        if (reply != null)
</p>
<p>
        {
</p>
<p>
            reply.setFromCache();
</p>
<p>
            gotCallback.got(reply);
</p>
<p>
            return;
</p>
<p>
        }
</p>
<p>
 
</p>
<p>
        CommandPatternServiceAsyncCallback serviceAsyncCallback = new CommandPatternServiceAsyncCallback(command, gotCallback);
</p>
<p>
 
</p>
<p>
        compatService.serve(command, serviceAsyncCallback);
</p>
<p>
    }
</p>
<p>
 
</p>
<p>
    private class CommandPatternServiceAsyncCallback implements AsyncCallback<Reply>
</p>
<p>
    {
</p>
<p>
        private final Command command;
</p>
<p>
        private final GotCallback gotCallback;
</p>
<p>
 
</p>
<p>
        public CommandPatternServiceAsyncCallback(Command command, GotCallback gotCallback)
</p>
<p>
        {
</p>
<p>
            this.command = command;
</p>
<p>
            this.gotCallback = gotCallback;
</p>
<p>
        }
</p>
<p>
 
</p>
<p>
        public void onFailure(Throwable caught)
</p>
<p>
        {
</p>
<p>
            Window.alert(caught.toString());
</p>
<p>
        }
</p>
<p>
 
</p>
<p>
        public void onSuccess(Reply result)
</p>
<p>
        {
</p>
<p>
            commandCache.cache(command, result);
</p>
<p>
            gotCallback.got(result);
</p>
<p>
        }
</p>
<p>
    }
</p>
<p>
} 
</p>
<p>
 
</p>
<p>
As seen the command pipe needs the Grails GWT service RPC interfaces injected into it. Using which it can then serve the client script generated commands. All the injection is done in my Gin Module.
</p>
<p>
 
</p>
<p>
public class TheBindingsModule extends AbstractGinModule
</p>
<p>
{
</p>
<p>
    protected void configure()
</p>
<p>
    {
</p>
<p>
        bind(CommandPatternPresenter.Display.class).to(CommandPatternView.class).in(Singleton.class);
</p>
<p>
        bind(EventBus.class).to(DefaultEventBus.class).in(Singleton.class);
</p>
<p>
        <strong>bindConstant().annotatedWith(CacheSize.class).to(10);</strong>
</p>
<p>
        <strong>bind(Cache.class).to(FIFOCache.class);</strong>
</p>
<p>
        <strong>bind(CPService.class).toProvider(CPServiceProvider.class).in(Singleton.class);</strong>
</p>
<p>
        <strong>bind(CommandPipe.class).in(Singleton.class);</strong>
</p>
<p>
    }
</p>
<p>
} 
</p>
<p>
 
</p>
<p>
<a href="/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\CommandPattern.7z"> MVP ; Command Pattern ; Dependancy Injection with Groovy On Grails Using GWT Gin gwt-presenter part of gwt-dispatcher ALL DONE IN IDEA mostly without using console but works from console too); All in One example </a>
</p>
', CAST(0x00009CCF011A12F0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'GWT-code-splitting-best-practice-is-not-really-best-practice', N'GWT code splitting best practice is not really best practice', N'<p>I believe if you put in code like</p><p> </p><p>GWT.runAsync(new RunAsyncCallback(){</p><p>@Override</p><p>public void onFailure(){</p><p>} </p><p>@Override</p><p>public void onSuccess(){</p><p>}  </p><p>}); </p><p> then what happens is that the onSuccess code is actually going to be in the file that gets downloaded. And the onFailure code , together with the code downloading code is in the initial/current javascript file.</p><p> As the GWT compiler tries to compile the SourceUnit (souce file) that contains this code, it will put </p><p> </p><p> </p><p>Sorry -----------------------=Am gonna complete this later!=--------------------------- GTG </p>', CAST(0x00009DFB01666DD0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'GWT-Library', N'GWT Library', N'<p>Today hosted my GWT library on code.google.com.</p><p> </p><p><a href="http://code.google.com/p/xmlview-gwt/">http://code.google.com/p/xmlview-gwt/</a></p><p> </p><p>This ought to help out MVP devs tied up with GWT, an'' maybe give gwt 3.0 some ideas :)</p><p> </p><p>Looking for some contributers/committers now... </p>', CAST(0x00009DB401396290 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Home-PC-v30', N'Home PC v3.0', N'<div><br /></div><div> </div><div> </div><div>Check it out @  <span class="Apple-style-span" style="font-family: ''lucida grande'', tahoma, verdana, arial, sans-serif; color: #333333"><a href="http://www.facebook.com/album.php?aid=281802&id=815596121&l=cb4a23b17f">Facebook Images</a></span>  -  There are a few neat things I can share here :</div><div> </div><div> </div><div>Power Supply required for your custom configuration can be calculated here : <a href="http://www.antec.outervision.com/">http://www.antec.outervision.com/</a> It helps you make decision on the proper PSU/SMPS for your machine. Mine is around 345 Watts - so I got a 400W Zebronics SMPS (take into account ageing and surges)</div><div> </div><div> </div><div>Most monitors are LCD which means they have a white backlight source burning all the time behind and any blackness and colors are rendered by shining it through liquid crystals turned by electricity. Which means black is not really black but is sort of bright gray, and power is wasted by throwing light and blocking it. My LED monitor works by radiating appropriate color light, and not burning at all in black regions on the screen.  </div><div> </div><div> </div><div>LED is mostly seen in TVs and they cost 30k and above for even being HD-Ready [720p max supported resolution] 26 inches, and full HD [1080p] are available only for 32 inches and above, this acer monitor I bought is 24 inches AND LED technology AND Full HD AND only 15K - almost too suspicious to be true, but its bought Ill follow up here if it screws up.</div><div> </div><div> </div><div> </div><div>For a decent Gaming and Dev PC,  Core i5 7XX (4 Core) is the best :</div><div> </div><div>No matter what Intel says - Core i7 gives only a very small improvement over i5 and only in Physics heavy games (Think shooters and a few RTS titles) and the physics rendered by those engines is usually on collisions and explosions and on Faces only which are themselves grainy to start with and last only for half a second or so.</div><div> </div><div><a href="http://www.geek.com/articles/games/nvidia-proves-intels-core-i7-is-money-wasted-for-gamers-20090430/">http://www.geek.com/articles/games/nvidia-proves-intels-core-i7-is-money-wasted-for-gamers-20090430/</a></div><div><a href="http://www.geek.com/articles/games/nvidia-proves-intels-core-i7-is-money-wasted-for-gamers-20090430/"></a><a href="http://www.bit-tech.net/news/hardware/2009/04/23/core-i7-waste-of-money-says-nvidia/1">http://www.bit-tech.net/news/hardware/2009/04/23/core-i7-waste-of-money-says-nvidia/1</a></div><div> </div><div>Clock speed increase is only 210 MHz, and Cache size is same, HT tech is enabled for i7 not for 4-core i5.  I am talking about Core i5 7XX series here which are quad core with 4 concurrent threads no HT - not the Core i5 4XX, 5XX and 6XX series which have only 2 core and still manage 4 threads by using HT. Prefer 2 extra cores over HT. Only core i7 gives both 4 cores and HT enabling 8 concurrent threads.</div><div> </div><div> </div><div>On a side note :</div><div> </div><div>Home PC v0.0 was P3 550 MHz, 64 MB Ram, Integrated Graphics.</div><div>Home PC v1.0 was P4 2.8 GHz, 256 MB Ram, nVidia 5400 256 VRAM.</div><div>Home PC v2.0 was P4 3.0 GHz, 1 GB Ram, ATI HD 4650 512 MB VRAM (PC World Best buy in 2007).</div><div><a href="http://www.bit-tech.net/news/hardware/2009/04/23/core-i7-waste-of-money-says-nvidia/1"></a> </div><div> </div><div> </div>', CAST(0x00009E64008CE650 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Integrity', N'GWT - Testing ; GWT Renderers', N'<p>/* Edited on 4th June (removed sensitive info)*/ </p><p> There are some points that needs to be considered while extensively using GWT, and while test driving the entire development. Service calls and callbacks abound while writing any enterprise GWT App. What your app does during the gap between the call and the callback needs to be addressed. If you have a button click making a service call, for example, you may need to disable the button untill the callback is done.. else a frustrated user may click it multiple times making several service calls. (which in my case led to StaleObjectStateExceptions)</p><p> </p><p>When you test drive your GWT code, you probably want to test your CallBacks and ClickHandlers ... to do this instead of writing code like :</p><p> </p><p><font face="courier new,courier">button.addClickHandler(  new ClickHandler() {   ...void onClick() {..blah..blah..blah.}   } ) </font></p><p><font face="courier new,courier">service.doMethod(argument,  new AsyncCallback<reply>{ ... onFailure() {} ....onSucess(){}   } ) </font></p><p> </p><p>(these fragments are impossible to test -- 1. We need to test if proper wiring has been done 2. We need to test if wired handlers have correct logic in then) </p><p>we do this :</p><p> </p><p><font face="courier new,courier">button.addClickHandler(  createClickHandler ) </font></p><p><font face="courier new,courier"> </font></p><p><font face="courier new,courier">void createClickHandler() {</font></p><p><font face="courier new,courier"><span class="Apple-tab-span" style="white-space: pre">	</span>return new ClickHandler() {   ...void onClick() {..blah..blah..blah.}   } </font></p><p><font face="courier new,courier">} </font></p><p><font face="courier new,courier"> </font></p><p><font face="courier new,courier">service.doMethod(argument,  createCallBack() ) </font></p><p><font face="courier new,courier"> </font></p><p><font face="courier new,courier"> </font></p><p><font face="courier new,courier">void createCallBack() {<br /></font></p><p><font face="courier new,courier"><span class="Apple-tab-span" style="white-space: pre">	</span>return new AsyncCallback<reply>{ ... onFailure() {} ....onSucess(){}   } </font></p><p><font face="courier new,courier">}</font></p><p><font face="courier new,courier"> </font></p><p>Now we can make these methods package local and test them ... Testing is incredibly easy if we follow the MVP Pattern or the View/ViewHandler Pattern</p><p> </p><p><font face="courier new,courier">public void test() {</font></p><p><font face="courier new,courier"><span class="Apple-tab-span" style="white-space: pre">	</span>createCallBack().onSuccess(); verify(blah blah blah) ;  // for functionality testing</font></p><p><font face="courier new,courier">}</font></p><p><font face="courier new,courier"> </font></p><p><font face="courier new,courier">presenterTestable = new Presenter(){</font></p><p><font face="courier new,courier">@Override</font></p><p><font face="courier new,courier">void createCallback()  {</font></p><p><font face="courier new,courier"><span class="Apple-tab-span" style="white-space: pre">	</span>return mockCallback;  // for wiring up testing  verify(service).execute("argument", mockCallback)</font></p><p><font face="courier new,courier">} </font></p><p><font face="courier new,courier">}</font></p><p><font face="courier new,courier"> </font></p><p> </p><p>We in MOST cases need only one instance of a clickhandler or callback.. so this createClickHandler or createCallback must be wrapped into a singleton pattern -- that way for wiring up tests we dont need to override the presenter/viewhandler and make our methods return mocks. Like :</p><p> </p><p><font face="courier new,courier">void createCallBack() {<br /></font></p><p><font face="courier new,courier"><span class="Apple-tab-span" style="white-space: pre">	</span>return <strong><em>Singleton.return(</em></strong> new AsyncCallback<reply>{ ... onFailure() {} ....onSucess(){}   } <em><strong>)</strong></em></font></p><p><font face="courier new,courier">}</font></p><p><font face="courier new,courier"> </font></p><p>  What finally came out was :</p><p><font face="''courier new'', courier"> </font></p><p><font face="''courier new'', courier">import java.util.HashMap;</font></p><p><font face="''courier new'', courier"><br /></font></p><p><font face="''courier new'', courier">public class HandlerCache {</font></p><p><font face="''courier new'', courier">    private static HashMap<String, Object> registry = new HashMap<String, Object>();</font></p><p><font face="''courier new'', courier"><br /></font></p><p><font face="''courier new'', courier">    public synchronized static <T> T wrap(T handler) {</font></p><p><font face="''courier new'', courier">        String name = handler.getClass().getName();</font></p><p><font face="''courier new'', courier">        if (registry.containsKey(name))</font></p><p><font face="''courier new'', courier">            return (T) registry.get(name);</font></p><p><font face="''courier new'', courier">        else {</font></p><p><font face="''courier new'', courier">            registry.put(name, handler);</font></p><p><font face="''courier new'', courier">            return handler;</font></p><p><font face="''courier new'', courier">        }</font></p><p><font face="''courier new'', courier">    }</font></p><p><font face="''courier new'', courier"><br /></font></p><p><font face="''courier new'', courier">    public static void clear() {</font></p><p><font face="''courier new'', courier">        registry.clear();</font></p><p><font face="''courier new'', courier">    }</font></p><p><font face="''courier new'', courier">}</font></p><p> </p><p>with source looking like </p><p> </p><p><font face="''courier new'', courier"> doneButton.addClickHandler(createDoneClickHandler());</font></p><p><font face="''courier new'', courier"> </font></p><p> and test looking like :</p><p> </p><p><font face="''courier new'', courier"> verify(doneButton). addClickHandler(presenter. createDoneClickHandler());</font></p><p><font face="''courier new'', courier"> </font></p><p> And when it comes to creating new widgets for your GWT App, the easiest thing to do will be to have a class extending Composite with initWidget() call in it. Instead of this which combines the rendered HTML and the logic of the widget itself ; a better way would be to have the widget as a POJO, and have a renderer that can render the POJO into GWT UIObjects like :</p><p> </p><p><font face="''courier new'', courier">public class NumberGrid { </font></p><p><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre">	</span>ArrayList<NumberGridCell> grid = new ArrayList<NumberGridCell>();</font></p><p><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre">	</span>int cols; </font></p><p><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre">	</span>public NumberGrid (int maxno, int cols) {</font></p><p><span class="Apple-tab-span" style="white-space: pre"><font face="''courier new'', courier">	<span class="Apple-tab-span" style="white-space: pre">	</span></font></span><font face="''courier new'', courier">for(int i =0; i<maxno; i++)</font></p><p><span class="Apple-tab-span" style="white-space: pre"><font face="''courier new'', courier">		<span class="Apple-tab-span" style="white-space: pre">	</span></font></span><font face="''courier new'', courier"> grid.add(new NumberGridCell(i))</font></p><p><span class="Apple-tab-span" style="white-space: pre"><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre">	</span>	</font></span><font face="''courier new'', courier">this.cols = cols; </font></p><p><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre">	</span>} </font></p><p><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre">	</span>public NumberGridCell getCell(int row, int col) {</font></p><p><span class="Apple-tab-span" style="white-space: pre"><font face="''courier new'', courier">	<span class="Apple-tab-span" style="white-space: pre">	</span></font></span><font face="''courier new'', courier">return grid.get(row * cols + col) ;</font></p><p><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre">	</span>} </font></p><p><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre">	</span>public remove Number(int number){</font></p><p><span class="Apple-tab-span" style="white-space: pre"><font face="''courier new'', courier">	<span class="Apple-tab-span" style="white-space: pre">	</span></font></span><font face="''courier new'', courier">grid.remove(number); </font></p><p><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre">	</span>} </font></p><p><font face="''courier new'', courier">}</font></p><p><font face="''courier new'', courier"> </font></p><p><font face="''courier new'', courier">public class NumberGridTableRenderer extends FlexTable{</font></p><p><font face="''courier new'', courier">public void render (NumberGrid numberGrid, int rows, int columns) {</font></p><p><span class="Apple-tab-span" style="white-space: pre"><font face="''courier new'', courier">	</font></span><font face="''courier new'', courier">NumberGridCellDivRenderer  cellDivRenderer = new  NumberGridCellDivRenderer()</font></p><p><font face="''courier new'', courier"><span class="Apple-tab-span" style="white-space: pre"></span></font></p><p><span class="Apple-tab-span" style="white-space: pre"><font face="''courier new'', courier">	</font></span><font face="''courier new'', courier">for(int row = 0; row<rows; row++)</font></p><p><span class="Apple-tab-span" style="white-space: pre"><font face="''courier new'', courier">		</font></span><font face="''courier new'', courier">for(int col =0; col<columns; col++)</font></p><p><span class="Apple-tab-span" style="white-space: pre"><font face="''courier new'', courier">			</font></span><font face="''courier new'', courier"> super.setWidget(row, col, cellDivRenderer.render(numberGrid.getCell(row, col )))</font></p><p><font face="''courier new'', courier">}</font></p><p><font face="''courier new'', courier">}</font></p><p><font face="''courier new'', courier"> </font></p><p>This renders the NumberGrid with <table> <tr> <td>  tags.... with each individual cell rendered as a <div> . We can now potentially change the way NumberGrid is rendered using different renderers - for example make a NumberGridDivRenderer or NumberGrid_OL_LI_Renderer which renders the grid as a set of <div> tags or as a set of <ul> or <ol> tags... and a NumberGridCell_LI_Renderer which renders the cell as <li> tagged elements.</p><p> </p><p>  A GWT based enterprise project will often create lots of widgets like LabelledTextBox, ValuedButton, etc ..  Some of such commonly created widgets are actually just a collection of GWT standard widgets - LabelledTextBox = Label + TextBox  ;  DateWidget = 3 ComboBoxes (year month day)  ; TimeWidget = 3 ComboBoxes (hour minute seconds) ; RadioButtonGroup and so on...   In such cases it probably makes sense to follow the provider pattern :</p><p> </p><p> The functionality expected out of a DateWidget is like If you select day as 31 and month as February you might want the day combo deselected or selected 29 or 28 and so on.. To implement such functionality if we have DateWidget extending Composite or FlowPanel , and we have the widget in many places as is the case most of the time, then we are forced to using the same layout everywhere.. or have fields describing the layout in the widget.  Assuming we have a WidgetProvider as in DateWidgetProvider and it acts like a factory that gives you the 3 ComboBoxes :</p><p> </p><p><font face="''courier new'', courier">ComboBox dateWidgetProvider.getDayCombo()</font></p><p><font face="''courier new'', courier"> </font></p><p> Then we are free to use different layouts in different places and still logically bind the 3 ComboBoxes. For starters GWT does not have a ComboBox and you probably have to code up a class ComboBox extending ListBox with height 0.</p>', CAST(0x00009D1501518E10 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'I-want-to-see-BlizzCon-12', N'I want to see BlizzCon ''12', N'<p>BlizzCon or Blizzard Conferance is sort of a promo program that blizzard conducts for popularity and exposing their newest gaming software. BlizzCon 09 featured Demonstrations of starcraft 2 and diablo 3. It also featured costume contests tournaments, and other variety programs. Tickest cost around 125$ lol. but maybe its worth it to see your gaming characters come real! Lich king , Invoker, Succubi, Crystal Maiden, etc..</p><p> </p><table border="0" cellspacing="2" cellpadding="2" align="center">			<tbody>						<tr>									<td><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\f_000124.jpg" alt="" width="200px" height="200px" />;</td>																		<td><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\f_0001c6.jpg" alt="" width="200px" height="200px" /></td>												</tr>						<tr>									<td><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\f_0001d1.jpg" alt="" width="200px" height="200px" /></td>																		<td><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\f_000143.jpg" alt="" width="200px" height="200px" /></td>												</tr>				</tbody></table><p> Playing Mafia Wars - quite good for a HTML based game. Diablo 3 and Starcraft 2 are *still* unreleased! <img src="/ZaszBlog/Admin/TinyMCE/plugins/emotions/images/smiley-cry.gif" border="0" alt="Cry" title="Cry" />  Now dota on garena took a new dimension when all of us frnds players were connected thro voice links on skype... I even got to be observer on a match or 2 and can easily talk to the friendly players about enemy movements lol. Blizz Con ''12 has been scheduled to demonstrate a completely new game unrelated to the starcraft and diablo worlds from blizzard. Considering how popular WoW and starcraft and warcraft and diablo series are, the new one can only be better !</p><p> </p><p>Word to the wise : Ruby on Rails can be difficult to get started, Ruby being a new language to me. Rails framework is very vague without expert help - need to get some webcasts or videos. Leave a comment if u know where to find some quality tutorials in MPEG format.</p>', CAST(0x00009C7B014AB040 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Login-control-ASPNET-works-in-Firefox-but-not-in-IE', N'Login control + ASP.NET + works in Firefox, not in IE', N'<p>
<font size="3"><strong>Does the login control not work in IE (Internet Explorer 6 , 7 , any) and works fine in Firefox (1.0 , 2.0 , any )?</strong></font> 
</p>
<p>
<font size="3">    The problem always occurs after publishing, right?, not during development  (unless you''ve incorporated Google AdSense in the development version also).  The culprit is Google AdSense people. </font>
</p>
<p>
<font size="3">A simple test : Use the visual studio comment toolbutton to comment out all the google scripts you''ve incorporated into your site, and check if login control works ..... </font>
</p>
<p>
<font size="3">    I have created a custom user control that contains the javascript from google and am registering and using the usercontrol wherever i need the Advertisement.  So i commented out all the Ad usercontrols i used in the <em>login</em> page <strong>AND</strong> the <em>master</em> page that login.aspx uses, so that in the final rendered version, google''s scripts don''t come <strong>with</strong> login control''s rendered code at all. Now the login control works fine. Then i included Googles AdSense Scripts , uncommenting google script usercontrols and tried , the problem was back. </font>
</p>
<p>
<font size="3">    People think master pages are the reason login fails in IE-not-Firefox, but, no, the google ads mostly invariably placed in master pages are the real reason. Also not only does the login control cause problems in IE and not in Firefox, but also the LoginStatus control and a few other controls also cause problems in IE and not in Firefox. Some blogs & comments say authorization cookie is not picked up by the browser , i think that may be true , becoz google adsense scripts do some authentication cookie work themselves . The script downloaded from google by the stubs we put in our Aspx pages are probably the reason. I tried going through it , but could''nt make head or tail of it... way too complex for me. </font>
</p>
<p>
<font size="3">Both the login & loginstatus controls work fine in firefox alonside google ads & scripts , though sometimes i see wierd behaviour ... if I clear all cookies & temp. internet files in firefox, the first time i click on the login button, nothing happens but a refresh. The second time i click it , it login fine.(All of this alongside google adscripts) . Justification :</font> 
</p>
<ul>
	<li><font size="3">Google must have different scripts for IE and Firefox - which could be the reason IE can''t perform correct while using ASP.NET 2.0 Login Controls , while firefox can.</font></li>
	<li><font size="3">Or Login Control Library renders differently based on the browser (i don''t know) the login page is often the first page requested by the client , in which case the asp runtime can see the user agent string and render accordingly.... <br />
	</font></li>
	<li><font size="3">Google and ASP.NET may produce the same code for both browsers in which case , the browser architecture is responsible for this unique behaviour. (means Firefox is good!)</font></li>
	<li><font size="3">Some folks think remember me check box - may be the cause, it defenitely could becoz it (leaves) involves a cookie, which i think is what(the cookies) google script wrecks !</font></li>
	<li><font size="3">Most blogs and forums(especially in <a href="http://weblogs.asp.net/pwilson/archive/2006/04/04/441885.aspx" target="_blank" title="weblog.asp.net">aspblog</a>  <a href="http://forums.asp.net/t/1121401.aspx" title="forums.asp.net">aspforum</a> <a href="http://www.experts-exchange.com/Web_Development/Web_Languages-Standards/CSS/Q_23359193.html" target="_blank">expertsexchange</a> <a href="http://www.webdeveloper.com/forum/showthread.php?t=180660">webdeveloper</a>) say : Login control is suddenly broken - means it was working fine previously... they just don''t connect the point of time the problem was discovered was always after a short or long time <strong>AFTER </strong>hooking up google ads ... for me i took i long time discovering the error after setting up google adsense , so it didnt occur to me adsense could be the change that causes the problem.</font></li>
	<li><font size="3">We all use  different kinds of AdSense units  : so the problem also differs slightly : to some the pressing of login button does nothing but refresh the page, to me there was no reaction at all after i pressed the login button after entering correct & wrong pair of username and password , to some it seems there is redirect & error code 404 is returned once they click on the login button. </font></li>
</ul>
<p>
<font size="3"><strong>Best Workaround :</strong></font> 
</p>
<ol>
	<li><font size="3">Create another similar master page without the ads , and use this as master for login.aspx - you preserve the same look and feel, but forgo ads till Microsoft or Google comes up with a solution.</font></li>
	<li><font size="3">Enclose all ads between <% if(!Page.title.equals("Login")){ %>    and    <%} %>, which means u''ve solved the Login Control , but still the LoginStatus and other login controls could still give you a problem.(make sure you title the login page to "Login") </font></li>
	<li><font size="3">In case you are''nt using a master page at all for login.aspx , new login page without the ads , must be built.</font></li>
</ol>
<p>
<font size="3">  </font>
</p>
<p>
<font size="3">  </font>
</p>
<p>
<font size="3">  </font>
</p>
<p>
<font size="3">  </font>
</p>
', CAST(0x00009A9900D3C2F0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Moving-the-MBR-to-another-DeviceHard-Disk', N'Moving the MBR to another Device/Hard Disk', N'<div><font size="3"><br /></font></div><div><font size="3">The most common scenario for wanting to move the MBR to another Hard Disk is because you bought a newer faster/bigger drive and installed better OS in it and want to format the old Hard Disk so you can store other data in it.</font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3">Every hard disk has an MBR (Master Boot Record) in its Sector 0 (1 sector = 512 bytes) - On a multiple hard disk system you have multiple MBRs and the BIOS Bootscreen shows the priority in which the devices are considered for checking for MBR. </font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3">Usually your old hard disk willl contain an MBR, and new hard disks MBR will be missing. If you say, installed Windows 7 on the new Hard drive, you will still need the old hard disk as it contains the MBR that loads the Windows Boot Loader (which is also on the older hard drive) and this in turn bootstraps the Windows in the new Harddisk. So you wont be able to format the old Hard drive as it is the gateway to your OS on the new Harddisk.</font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3">Other things you will observe in this scenario are - If you see the Computer Management screen (R-Click My Computer and click manage) - > Storage -> Disk Management you will observe the old Harddisk is marked as System and you can''t format it as its disabled because it contains the MBR from which the OS booted from.</font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><strong><font size="3">Steps to resolve :</font></strong></div><div><font size="3"><br /></font></div><div><font size="3">1) Get EasyBCD 2.0+ and go to Bootloader Setup. In the create Bootable External Media section select your new harddisks OS partition and click on Install BCD - Press OK in the confirmation dialog regarding selection of BCD store if it turns up. This step will create empty BCD file & data on the new HardDisk itself, where you have the new OS (Windows 7 usually).</font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3">2) In the MBR Configuration Options, select Install the (Windows 7/ Windows XP) bootloader to the MBR, based on what OS is in the partition you selected in step 1. I recommend choosing Windows7 bootloader, even if you want only XP. This step will make the MBR in your new harddisk bootable and it will boot into window 7 bootloader or XP bootloader</font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3">3) Go to the Add New Entry tab and Add an entry for all the OSes you have, including the one in your new harddisk. This step is usually done only if you choose Windows  bootloader in the previous step. Even otherwise do this no worries. This will show all the OS options while booting up.</font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3">4) Finally restart Go to BIOS boot priority and give the New harddisk 1st priority, or atleast higher priority than the old harddisk.</font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3">5) Optional - Format the old harddisk and do whatever you want with it - this will delete the bootable MBR on it.</font></div><div><font size="3"> </font></div><div><font size="3"> </font></div><div><font size="3"><br /></font></div><div><font size="3">Cheers. Be sure not to FlusterCuck your Harddrives :P</font></div>', CAST(0x00009E6B012BED40 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Nested-MasterPages-seems-to-have-an-egg-or-two', N'Nested MasterPages seems to have an egg or two', N'<p style="margin-bottom: 0in"><font size="3" style="font-size: 13pt"><em>NestedMaster Pages – Content Place Holders in <head> Issue</em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in">If we have a Master Page say SiteMaster.master and a content page for it say Default.aspx with a ContentPlaceHolder in the <head> section of the master page.The idea is that content pages can add their own stylesheet links. Each content page, in our example, needs a different stylesheet.</p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in">Okay, the issue is using Page.Header.Controls property, in the code-behind of the Default.aspx, shows only the controls in the head section of the master page SiteMaster.master. We cannot access the controls of the head that arein the content part of the content placeholder, in our Default.aspx page.</p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in">If we are using Nested Master Pages ,with contentplaceholders in <head> section, then Page.Header.Controls exposes only the controls in the <head> tag that must be present in the outermost, most general master page. In either of these cases, If we try to skip head altogether and define the head tag in the asp:content of the content pages, ThenPage.Header simply becomes null when accessed.</p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in">For unavoidable cases, I recommend writing the <head> section with all the possible Content combinations, with Visibility=”False” [means the tagwon''t be rendered into the html sent to the browser] and group them like :</p><p style="margin-bottom: 0in"><font color="#7e0021"><em><br /><head></em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em><%-- forDefault.aspx --></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><linkhref=”..” rel=”..”/ runat=”server”ID = “Def1” Visibility=”False”></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><meta ..runat=”server” ID = “Def2”/></em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em><%-- forLinkz.aspx --></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><linkhref=”..” rel=”..” runat=”server”ID = “Lin1” /></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><meta .. runat=”server” ID = “Lin2” /></em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em></head></em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in">and then use the Page.Header.Controls as follows, in the Code-Behind of the MasterPage  SiteMaster.master :</p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em>protected voidPage_Load(object sender, EventArgs e)</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>{</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>string check;</em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em>if(Request.Path.Contains(“Default.aspx”))</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>check = “Def”;</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>if(Request.Path.Contains(“Linkz.aspx”))</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>check = “Lin”;</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>//.....................etc.,</em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em>foreach(Controlc in Page.Header.Controls)</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>{</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>if(c.ID.StartsWith(check,StringComparison.InvariantCultureIgnoreCase))</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>c.Visibility =true;</em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em>}</em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em>}</em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in">Another method is by using the scriptlets as suivantes:</p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em><head></em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em><%if(Request.Path.Contains(“Default .aspx”))  { %></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><linkhref=”..” rel=”..”/ runat=”server”ID = “Def1” Visibility=”False”></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><meta ..runat=”server” ID = “Def2”/></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><% }%></em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em><%if(Request.Path.Contains(“Linkz.aspx”))  { %></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><linkhref=”..” rel=”..” runat=”server”ID = “Lin1” /></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><meta .. runat=”server” ID = “Lin2” /></em></font></p><p style="margin-bottom: 0in"><font color="#7e0021"><em><% }%></em></font></p><p style="margin-bottom: 0in"> </p><p style="margin-bottom: 0in"><font color="#7e0021"><em></head></em></font></p><p> </p><p> </p>', CAST(0x00009B5500BD83A0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'New-Kind-of-Advertising--Spamming-around', N'New Kind of Advertising / Spamming around', N'<p>I can see a lot of blog posts on the internet with strange comments.</p><p> </p><p>People while commenting on posts, are given the option of hyperlinking their name to their site/blog/mailid. Someone thought : Wow Ill just write some generic comment on all posts on the internet, and link my name to my business. Also Ill specify my name as something like "easy personal loans"  and link it to my site "fastloansus.com"</p><p> </p><p>Talk about driving traffic to a site, there''s no limit to their innovation. My only question is : Is this commenting process manual or automated? It seems manual to me as lots of examples I have seen around the Net, are having comments whose content is sort of appropriate to the posts. Not just "nice post", "nice theme", etc. So it could very well be that the advertisers have a couple of people sitting around to browse the net and comment on posts. Boy I''d like that job, if it pays well. </p><p> </p><p>I saw some of these kind of comments on DotNetKicks.com before, and now they are not there anymore. They seem to have found a way to block all such comments probably by using blacklist of sites, and blocking comments that have a link to one or more of them. I will do the same if this becomes a serious problem, but until then let things be. </p><p> </p>', CAST(0x00009CC000BAC480 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'On-the-other-hand', N'On the other hand', N'<p>
 
</p>
<p>
The team Feeder  has its high times too. 
</p>
<p>
 
</p>
<p>
Note: While downloading this from certain browsers(Mozilla FF), you may
need to rename the downloaded file to the name shown in the link. 
</p>
<p>
 
</p>
<p>
Team matches: 
</p>
<p>
 
</p>
<p>
<a rel="enclosure" href="http://thiagarajan.net/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\Feeder+win+1.w3g">Zzzzzzzzz.w3g (544.40 kb)</a>
</p>
<p>
<a rel="enclosure" href="http://thiagarajan.net/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\feeder+win+2.w3g">N1Feeder.w3g (443.97 kb)</a>
</p>
<p>
 
</p>
<p>
Me (Axe): 
</p>
<p>
 
</p>
<p>
<a rel="enclosure" href="/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\unexpectedwin.w3g">KrobeAxe x MiranaAvernusAdmiral(513.82 kb)</a> 
</p>
<p>
<a rel="enclosure" href="/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\axevsdrowwin.w3g">Axe x Drow (200.18 kb)</a>
</p>
<p>
 
</p>
<p>
Use Replay Seeker. FFS to interesting timelines.
</p>
<p>
 
</p>
', CAST(0x00009C2100D70EB0 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Play-DotA', N'Play DotA', N'<div style="background-color: black"><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\E005.gif" alt="" /><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\H000.gif" alt="" /><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Hdgo.gif" alt="" /><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\PotM.gif" alt="" /> <br /></div><p> </p><p> For those of you who want to experience the 5v5 Multiplayer excitement in DotA AllStars, You can use the G-Arena or Garena client, all you need is Warcraft 3 Frozen Throne, the latest dota map , and the latest dota AI map (from <a href="http://www.getdota.com/" target="_blank" title="DotA">http://www.getdota.com/</a>) , and the Garena Gaming client . With 2mbps Internet connection of course.</p><p> </p><p>A standard game in Garena Dota India room takes about 4 - 14 mb traffic (based on time of gameplay), even the longest game is cant cross the 15 mb traffic and most''ll be over within 5 mb.</p><p> </p><ul>	<li>Go to <a href="http://www.garena.com/" target="_blank">www.garena.com</a>	, Register as free member (choose a dota based username for the "cool"	factor) , download the client software, around 30 mb I think.</li>	<li>Install the software , open it and enter in your username & password and login.TURN THE FIREWALL OFF (from control panel)</li>	<li>Then click on India rooms join a level 1 room with atleast more than 100 people in it.. then click on start game button.</li>	<li>It ''ll ask for the path of the game executable.. browse to the folder where u copied warcraft 3 and choose FrozenThrone.exe</li>	<li>In the game menu go to lan game . Wait till you see a game(mostly	no need to wait.. u can see 3 or 4 games at all times) and join a game..<br />	call me if u have any problems</li>	<li>U need to kno the jargon:</li></ul><p> </p><p>afk = away from keyboard<br />bb = bye bye<br />bbl = be back later<br />brb = be right back<br />bs = bullshit OR backstab (an ambush)<br />buff = make something better (an ability, stats, items etc)<br />dw = dont worry<br />gj = good job<br />gl hf = good luck, have fun<br />gw = good work<br />imba = imbalanced<br />lo = hello<br />lol = laughing out loud<br />nerf = make something worse (an ability, stats, items etc)<br />nm = nvm = never mind<br />ppl = people<br />gg = good game<br />spikin = experiencing hangs every few seconds (spikes)<br /></p><p> </p><p><br />Shortforms</p><p> </p><p>b = back = retreat<br />bkb = black king bar<br />dd = doubledamage<br />dmg = damage<br />dota = defence of the ancients<br />dps = damage per second<br />eos = eye of skadi<br />fend = defend<br />gg = good game<br />ks = killsteal<br />mkb = monkey king bar<br />pub = pubbie = public = public game<br />rax = barracks, if yours is destroyed the opposing team''s creeps get stronger <br />regen = regeneration<br />rm = remake<br />ror = ring of regenation<br />roh = ring of health<br />ulti = a hero''s ultimate spell<br />crit = critical<br />HP = hit points<br />MP = mana points<br />noob = someone relatively new to the game<br />XP = Experience<br />AoE= Area of effect. Used to describe spells which target an area rather then a single unit<br />dps = damage per second<br />ff = forfeit<br />mia = missing in action. Used to tell others that the enemy hero(s) in your lane is missing</p><p> </p><p>Item shortforms</p><p> </p><p>Harby/OD = Harbinger, the Obsidian Destroyer<br />BM = Rexxar, the BeastMaster<br />CM = Crystal Maiden<br />Pig/BB = Rigwarl, BristleBack<br />PA = Phantom Assassin<br />clinkz = Bone Clinkz, the BoneFletcher<br />sheepstick = Guinsoo''s Scythe of Vyse<br />sk = Sand King, Soul Keeper, Skeleton King<br />sniper = Kardel Sharpeye, the Dwarven Sniper<br />blink dagger = Dagger of Escape<br />BoT = Boots of Travel<br />Deso = Stygian Desolator<br />HoT = Heart of Tarrasque<br />Necro = Necromonicon<br />RoB = Ring of the Basilus<br />Manta = Manta Style<br />Null = Null talisman<br />HoM/Midas = Hand of Midas<br />Basher = Cranium Basher<br />Mael = Maelstrom<br />HoD = Helm of the Dominator<br />BF/Bfury = Battlefury<br />Divine = Divine Rapier<br />Angha / Scepter = Anghamins Scepter<br />MoM = Mask of Madness</p><p> </p><p><font size="3"><font color="red"><strong>Game Modes</strong></font></font></p><p><font size="3"><font color="red"></font></font><br />Typed by the blue player (usually the host) within the first 15 secondsof the game. As a general rule, the planned game mode(s) should alwaysbe included in the game name. Modes can now be entered on one line like"-apidsh" or "-dm -ar -sc". You do not need to worry about the orderyou enter the modes in, the game will handle it or warn you (and giveyou another chance) if the mode is incorrect/incompatible.<br /><br /><strong><font color="skyblue">-ap / -allpick</font> </strong><br />Player may pick hero from all teams'' taverns.<br /><br /><strong><font color="skyblue">-ar / -allrandom</font> </strong><br />All players start off with a random hero chosen out of both taverns.<br /><br /><strong><font color="skyblue">-du / duplicate mode</font> </strong><br />More than one copy of the same hero may be selected by different players. Currently only compatible with -allrandom mode.<br /><br /><strong><font color="skyblue">-mm / -mirrormatch</font> </strong><br />Players may choose a hero as normal, but after a given period of time,the teams will be randomized according to the heroes chosen by bothsides and corresponding players given the same hero. The resultingteams will be identical, hence the name of the mode (5v5 game = 5 pairsof heros chosen from 10 possible ones).<br /><br /><strong><font color="skyblue">-rd / -randomdraft</font></strong><br />This command gives a pool of 20(22?) heroes to pick in a 1-2-2-2-2-1format, with either blue or pink going first, and then it will workdown the rest of the colors with the team that is picking alternatingeach time. <br /><br /><strong><font color="skyblue">-sc / super creeps</font> </strong><br />Random super creeps may spawn every creep wave. Completely randomexcept for the progression of supercreeps (Golems, Scary Fish, AncientHydra) and played for the increased gameplay dynamics. Not completelyconsidered "fair", due to the randomness and inconsistency of the supercreeps spawning per side (e.g. Sentinels may receive spawns very latein the game compared to the Scourge getting spawns frequently earlieron).<br /><br /><strong><font color="skyblue">-em / easymode</font> </strong><br />Building and tower hit points are reduced, higher rate of heroexperience and gold accumulation. This mode was previously known asshortmode (-sm).<br /><br /><strong><font color="skyblue">-dm / deathmatch</font> </strong><br />If a player''s hero dies, that hero type is removed from gameplay andthe player chooses a new hero from the remaining selection. When a teamhas thirty deaths, it is defeated. (This mode is currently bugged inversion 6.12b when a hero dies he also loses 1 level)<br /><br /><strong><font color="skyblue">-id / itemdrop</font> </strong><br />Enables random item drop upon death instead of losing money.<br /><br /><strong><font color="skyblue">-lm / leaguemode</font> </strong><br />The teams will only be able to choose one hero at a time, until allplayers have picked their hero, in this order: Blue, Pink, Teal, LightBlue, Purple ... and finally Brown. This is to avoid one of the teamsonly choosing heroes countering the other teams heroes. This way thepicks are justly distributed.<br /><br /><strong><font color="skyblue">-teamrandom</font> </strong><br />Players receive a random hero on his corresponding side (eitherSentinel or Scourge), he can repick for 500 gold during the firstminute of the game by using the command -repick (see below).<br /><br /><strong><font color="skyblue">-new</font> </strong><br />Enables an additional tavern with a new hero at the bottom right of themap. It is to serve as a buffer for newly introduced heros which arenot yet balanced for normal play. Currently the only hero in thistavern is the Invoker. EDIT: This mode is no longer available.<br /><br /><strong><font color="skyblue">-as/ -aa/ -ai</font></strong><br />All strength/ agility/ intelligence heroes mode. Only strength/ agility/ intelligence heroes can be picked.<br /><br /><strong><font color="skyblue">-sh / samehero</font></strong><br />All players in the game will recieve the hero that the host either picks or randoms. <br /><br /><strong><font color="skyblue">-wtf</font></strong><br />enables wtf mode. All spell cooldowns are removed, and heroes have limitless mana.<br /><br /><font size="3"><font color="red"><strong>Commands available to all players</strong></font></font><br /><br /><strong><font color="skyblue">-repick</font> </strong><br />Gives you a new, random hero if you''re in an -ar game and you want tochange your hero (costs 500 gold). There is a limited time window forrepicking (the maximum number of "repicks" is one).<br /><br /><strong><font color="skyblue">-refresh</font> </strong><br />With the Phantom Assassin (PA), it is used for refreshing her"invisibility" (due to a bug that removes this invisibility on death).Since the release of version 6.10, it no longer casts a Frost Novaanimation on the PA.<br /><br /><strong><font color="skyblue">-random</font> </strong><br />Selects a random hero from your side. You can repick another randomhero by typing -repick, but it costs 150g. (note the different goldcosts for repicking in -allrandom games and repicking when you yourselfchoose to -random.)<br /><br /><strong><font color="skyblue">-movespeed</font> </strong><br />Displays current move speed (for debugging and informational purposes). Also works with -ms.<br /><br /><strong><font color="skyblue">-recreate</font> </strong><br />For heroes that have the ability to undergo a metamorphosis that is nottied to the unit in the world editor map, namely Dragon Knight,Lycanthropy, Lifestealer, and Soul Keeper, where there are occasionalproblems with losing control of the unit. This is resolved by bringingthe unit back to the ''fountain'' area and typing this command. Thecommand has a 200 second channeling time, to prevent abuses.<br /><br /><strong><font color="skyblue">-unstuck</font> </strong><br />Transports your hero to the fountain after 50 seconds; it''s used whenyou are stuck in a unmovable place (e.g. trapped in an area of trees).You cannot move while transporting.<br /><br /><strong><font color="skyblue">-matchup</font> </strong><br />Displays the enemy players'' alias along with which hero they are currently controlling. Also works with -ma.<br /><br /><strong><font color="skyblue">-cs/-cson/off</font> </strong><br />Shows you your current creep kills. The board(cson) continually shows the number, while the normal command does not.<br /><br /><strong><font color="skyblue">-swaphero</font></strong><br />Allows you to select any teammate from a menu. That teammate will begiven the option to either select ''yes'' or ''no'' to the question if hewants to trade his hero with you. If he chooses ''yes'', all items willbe carried over and control over the hero switches. If he chooses ''no'',nothing will happen. Either way, you cannot use the command -swapheroagain. Each player may use this command once, so it is possible thatone hero is swapped between multiple players. This command cannot betyped after the first wave of creep commences.<br /><br /><strong><font color="skyblue">-disablehelp / -enablehelp</font></strong><br />These two commands are designed to prevent abuses of Chen''s Test ofFaith. If you type -disablehelp at the beginning of the game, Chen''sTest of Faith will not work on you. If you type -enablehelp later on,Chen''s spell will work on you.<br /><br /><strong><font color="skyblue">-denyinfo</font></strong><br />This command shows the -cs board, and it also shows a ! whenever a creep or tower is denied. aka -di<br /><br />Refer to this thread: <a href="http://www.dotaportal.com/forums/What-command-can-I-type-in-Dota-games-Complete-t11253.html" target="_blank">http://www.dotaportal.com/forums/What-comm...ete-t11253.html</a> for a more comprehensive list of updated commands</p><p> <br /><font size="3"><font color="red"><strong>Heros</strong></font></font></p><p> <br />Heroes in Allstars are given certain classifications which willinfluence their method of play. For example, stunners (heroes which canstun enemies) are usually accompanied by assassins or nukers toefficiently kill an enemy hero.<br /><br /><font color="skyblue"><strong>Assassins</strong></font><br />Heroes which specialize at killing other heroes quickly throughphysical damage. All of them have some form of invisibility orambushing suddenly. Any hero with windwalk, an invisibility skill, orblink can fall into this category.<br /><br /><font color="skyblue"><strong>Disablers</strong></font><br />Heroes who possess the ability to disable other characters, basicallyforcing them into a disadvantage while they attempt to fight or flee.Disables include any spells that move the enemy without his or herconsent, stun an enemy, reduce movement speed, disallow movement,reduce damage, reduce attack speed, reduce armor, prevent physicalattack, or prevent spell-casting. Though many spells fall under thesecategories, the general rule of an effective disable is a spell thatcan extend an enemy''s presence in combat against his or her will, whichtherefore only includes the first four of the listed effects. Also,passive abilities are often ignored as disables. Rhasta and Lion aretwo famous examples, both having two disable skills (Lion has impaleand voodoo, rhasta has shackles and voodoo).<br /><br /><font color="skyblue"><strong>Nukers</strong></font><br />Heroes who possess the ability to cause a significant amount of damagein a single instant via use of activated abilities in lieu of aphysical attack. E.g. Lion with Impale and Finger of Death, Slayer withDragon Slave and Light Strike Array+Laguna Blade.<br /><br /><font color="skyblue"><strong>Support</strong></font><br />Heroes whose skills are meant to directly aid the rest of the team.Heroes with healing or protective skills fall into this category.Pushers can also be counted as support, although sometimes they can beused individually instead of working together with the team.<br /><br /><font color="skyblue"><strong>Pushers</strong></font><br />Heroes which can quickly destroy enemy towers and creep generators dueto their ability to summon additional units or deal damage to an areaof enemy creeps. E.g. Prophet with Force of Nature, Warlock withInfernals, and Keeper of the Light with Illuminate and Ignus Fatuus.<br /><br /><font color="skyblue"><strong>Spammers</strong></font><br />Heroes who spam offensive spells repeatedly in an attempt to kill anenemy hero or disrupt the opponents'' play. This frequently causes enemyheroes to go back to their Fountain of Health to heal, thereby wastingtime and causing the enemy hero to lose experience. E.g. Zeus withLightning Arc and Death Prophet with Carrion Swarm and Witchcraft. A"spammer" is typically just a specific kind of nuker.<br /><br /><font color="skyblue"><strong>Stunners</strong></font><br />Heroes who possess the ability to stun other characters. Certain heroeshave passive skills enabling their attacks to have a chance ofstunning. When such heroes are able to keep the enemy constantlystunned it is known informally as permastun. E.g. Lion with Impale,Leoric with Storm Bolt, and Sand King with Burrowstrike.<br /><br /><font color="skyblue"><strong>Tankers</strong></font><br />Heroes who can absorb huge amounts of damage with either high health orarmor count. Typically used to destroy enemy towers. E.g. TreantProtector with Living Armor, Centaur Warchief with high base Strengthand Great Fortitude, and Morphling with Morph Strength.<br /><br />-- <br />~ Game on! ~<br /> </p><p> </p>', CAST(0x00009B9B00CDFE60 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Pre-Fetching-Troubles-A-Good-Idea', N'Pre-Fetching Troubles? A Good Idea', N'<p> </p><p><u><span class="Apple-style-span" style="font-size: large">A Point in Case :</span></u></p><p> </p><p><span class="Apple-style-span" style="font-size: small">In a standard ASP.NET application you have some stylesheet links in some aspx pages. These links further hav links to images using the url(...) format. When the browser downloads these stylesheets, it assumes the url(...) constructs links within the stylesheet are relative to the path from which the stylesheet itself was downloaded. This is usually the case. Stylesheets are downloaded from a folder say "GreenTheme" and usually theres a folder called "images" within the "GreenTheme" folder and stylesheet has constructs like :</span></p><p><em><span class="Apple-style-span" style="font-size: small">background-color:url(''images/bg.png'')</span></em><span class="Apple-style-span" style="font-size: small"> </span></p><p><span class="Apple-style-span" style="font-size: small">This means that , these images , when requested by the browser are served by the IIS server itself. </span><strong><span class="Apple-style-span" style="font-size: small">These requests do not go through the ASP.NET runtime at all.</span></strong><span class="Apple-style-span" style="font-size: small"> Requests from browser to server will be like : </span><em><span class="Apple-style-span" style="font-size: small">http://www.yourdomain.tld/GreenTheme/images/bg.png</span></em><span class="Apple-style-span" style="font-size: small"> which points to a valid file in the server directory structure and so IIS server can and does serve it, all by itself.Problem is it </span><strong><span class="Apple-style-span" style="font-size: small">does not set required http headers that must be set if Image Pre-Fetching is needed.</span></strong></p><p> </p><p><u><span class="Apple-style-span" style="font-size: large">Why Pre-Fetch ?</span></u></p><p> </p><p><span class="Apple-style-span" style="font-size: small">Suppose you have a CSS segment like this:</span></p><p><em><span class="Apple-style-span" style="font-size: small">.classA</span></em><span class="Apple-style-span" style="font-size: small"> {  background-image:url(a.png); } </span></p><p><em><span class="Apple-style-span" style="font-size: small">.classA:hover</span></em><span class="Apple-style-span" style="font-size: small">{  background-image:url(b.png);  } </span></p><p><span class="Apple-style-span" style="font-size: small"> When the mouse hovers over an element which belongs to this class, it must display a different image. Simple, ain''t it? But you can observe a DELAY when you hover your pointer over the element for the first time. This is the time taken to request the new background image from the server.From the second time onwards - when you hover - there is no delay in showing the image because it has already been fetched and cached.</span></p><p><span class="Apple-style-span" style="font-size: small">A lot of such elements, (or) Big background images, (or) A slow internet connection  - any of these means that users will see the delay effect prominantly and your UI is not going to be well thought of at all by visitors. So if you Pre-Fetch these images - (not only images that''re required during hover) - in a , say , loading screen or in a previous page using a script that uses idle time, you ensure bestexperience for visitors.</span></p><p><span class="Apple-style-span" style="font-size: small">Also it may be necessary that users don''t see a partially rendered page - something todays advanced browsers are capable of showing (they render as the code is downloaded). We can use Pre-fetching to show a loading screen [as in </span><strong><span class="Apple-style-span" style="font-size: small">GMail</span></strong><span class="Apple-style-span" style="font-size: small"> - while inbox is loading] while images, scripts, and AJAX-lets, and xml-xsl s  are downloaded.</span></p><p> </p><p><u><span class="Apple-style-span" style="font-size: large">How to Pre-fetch?</span></u></p><p> </p><p><span class="Apple-style-span" style="font-size: small">I''ve used a page that shows "Loading... " while in the background a script pre-fetches some images, scripts, and stylesheets. This script keeps track of the various <img> tags and <link> tags that each points to a resource that is tobe prefetched. When all the elements are loaded , we assume all the links/images they are pointing to are fetched, and so we can move on to the next page.</span></p><p><em><span class="Apple-style-span" style="font-size: small"><div style=</span></em><span class="Apple-style-span" style="font-size: small">"visibility:hidden"></span></p><p><em><span class="Apple-style-span" style="font-size: small"><img src="GreenTheme/images/bg.jpg" alt="" onload="myfun()"</span></em><span class="Apple-style-span" style="font-size: small">  /></span></p><p><em><span class="Apple-style-span" style="font-size: small"><img src="GreenTheme/images/a.png" alt="" onload="myfun()"</span></em><span class="Apple-style-span" style="font-size: small">  /></span></p><p><em><span class="Apple-style-span" style="font-size: small"><img src="GreenTheme/images/b.png" alt="" onload="myfun()"</span></em><span class="Apple-style-span" style="font-size: small">  /> </span></p><p><span class="Apple-style-span" style="font-size: small"></div> </span></p><p><span class="Apple-style-span" style="font-size: small">myfun() may simply updates a global counter variable as it is  called each time, checking if the maximum is reached. For eg if you have 10 images and 2 stylesheets and 2 scripts to be prefetched, you use 10 <img src=".."> tags , 2 <link href=".."> and 2 <script src=".."> tags in the approperiate places (like in a hidden div) and max=10+2+2=14 for mfun(). When all 14 elements are loaded, use location.href in javascript to redirect to another page. Sometimes it is necessary to set visibility = hidden through javascript or our DIV tag, cause a browser may simply ignore elements within a div tag that is hidded (this is not likely)- but if u set visibility = hidden via javascript, as part of global code, we work around the issue.</span></p><p> </p><p><u><span class="Apple-style-span" style="font-size: large">If-Modified-Since problem</span></u><span class="Apple-style-span" style="font-size: large"> :</span></p><p> </p><p><span class="Apple-style-span" style="font-size: small">When we use a loading page for prefetching images required by another page (possibly the home page) we come across this strange problem. </span><strong><span class="Apple-style-span" style="font-size: small">HttpAnalyser </span></strong><span class="Apple-style-span" style="font-size: small">is a software that detects and hooks onto an Internet Explorer instance and logs & shows all HTTP requests/responses that tke place between the browser and any server.</span></p><p><span class="Apple-style-span" style="font-size: small">When we request for our site with a loading page, As Expected we see requests for all the Pre-fetcher Links we put in.</span></p><p><span class="Apple-style-span" style="font-size: small">Then we are redirected to a content aspx page (the page we redirected in the script using location.href) As Expected.</span></p><p><span class="Apple-style-span" style="font-size: small">But whats Not Expected is the HttpAnalyser shows browser sending </span><em><span class="Apple-style-span" style="font-size: small">If-Modified-Since</span></em><span class="Apple-style-span" style="font-size: small"> requests. </span></p><p><span class="Apple-style-span" style="font-size: small">                  For which the server replies </span><em><span class="Apple-style-span" style="font-size: small">Not-Modified</span></em><span class="Apple-style-span" style="font-size: small">. </span></p><p><span class="Apple-style-span" style="font-size: small">                                For all the pre-fetched images that occur in this page (for eg the Home Page).</span></p><p><span class="Apple-style-span" style="font-size: small">Even though we have prefetched our images that occur in the home page , and those images that may be required when Hovering , and scripts etc in the Loading Page itself, some additional HttpRequests for these resources are sent. Okay they are NOT downloaded again - becuase they were prefetched, but instead of directly using the cached copy of the prefetched images, the browser takes time to ask the server if </span><strong><span class="Apple-style-span" style="font-size: small">pre-fetched copy in cache - has it been modified since it was downloaded? </span></strong><span class="Apple-style-span" style="font-size: small"> Whenever a same image that was downloaded for a page, is needed for another page, the browser asks this question to the server in the form of a </span><em><span class="Apple-style-span" style="font-size: small">If-Modified-Since <DateTimeObject> </span></em><span class="Apple-style-span" style="font-size: small">HttpRequest. The Server replies </span><em><span class="Apple-style-span" style="font-size: small">Not-Modified </span></em><span class="Apple-style-span" style="font-size: small">and then the Cached copy is used.</span></p><p> </p><p><u><span class="Apple-style-span" style="font-size: large">The WorkAround :</span></u></p><p> </p><p><span class="Apple-style-span" style="font-size: small"> How do we eliminate this unnecessary if-modified-since request then? It is obviously not going to be necessay for us - coz stylesheet images, hover images and scripts are not going to be changed for a long time - and defenitely not in the short timespan between the display of the Loading Page and Home page. The Answer is the </span><em><span class="Apple-style-span" style="font-size: small">Expires header.</span></em><span class="Apple-style-span" style="font-size: small"> What the server must do is : when sending the images that are requested in the pre-fetch load page, it must add a header called </span><em><span class="Apple-style-span" style="font-size: small">Expires</span></em><span class="Apple-style-span" style="font-size: small"> to which it must assign a suitable value [im my case One Year]. This informs the browser that the images prefetched by it are not going to be modified for one year atleat. Its cached copies of those Hover images etc expires only after one year or so. So it does NOT send</span><em><span class="Apple-style-span" style="font-size: small"> If-Modified-since requests </span></em><span class="Apple-style-span" style="font-size: small">when prefetched images (prefetched in Loading Page) are referred to from the Home Page or Other Pages.</span></p><p> </p><p><u><span class="Apple-style-span" style="font-size: large">How to WorkAround ?</span></u></p><p> </p><p><span class="Apple-style-span" style="font-size: small">See the first section of this post. StyleSheet links directlt hit a valid image file. So they are served by the IIS Server, and so we cannot(no easy way to) tell the server that such and such an image must be sent with a caching header "expires"  filled in with an approperiate vale.</span></p><p><span class="Apple-style-span" style="font-size: small">What we''re looking for is Http Handlers. Create an ASP.NET ashx HttpHandler that serves an image that is present in the same directory as the ashx file. [This is Important] Seperate the ashx file and code using a dll or a class in App_Code, because we will be having multiple Ashx files pointing to the same class[coz thre''ll be many directories that contain stylesheet images]. In this class write the code to get a name from the QueryString and search for and write the image file coresponding to the given name to the response stream. Also use the </span><strong><span class="Apple-style-span" style="font-size: small">Response.Caching.* properties</span></strong><span class="Apple-style-span" style="font-size: small"> to set the caching location as public (-cache at proxy client and server) and set the </span><strong><span class="Apple-style-span" style="font-size: small">Expires header</span></strong><span class="Apple-style-span" style="font-size: small"> also from C# code.</span></p><p><span class="Apple-style-span" style="font-size: small">Place this handler(the ashx file) in all the folders where stylesheet images are present. Say inside "GreenTheme/images" and inside "RedTheme/images". Placing the ashx files here is important.</span></p><p><span class="Apple-style-span" style="font-size: small">Now the sylesheets </span><em><strong><span class="Apple-style-span" style="font-size: small">must</span></strong></em><span class="Apple-style-span" style="font-size: small"> contain modified constructs like </span></p><p><em><span class="Apple-style-span" style="font-size: small">background-color:url(''images/CssImage.ashx?name=bg.png'')</span></em><span class="Apple-style-span" style="font-size: small">  </span></p><p><span class="Apple-style-span" style="font-size: small">instead of</span></p><p><em><span class="Apple-style-span" style="font-size: small">background-color:url(''images/bg.png'')</span></em><span class="Apple-style-span" style="font-size: small">  </span></p><p><span class="Apple-style-span" style="font-size: small">This way all the browser requests will be like </span></p><p><em><span class="Apple-style-span" style="font-size: small">http://www.yourdomain.tld/GreenTheme/images/CssImage.ashx?name=bg.png</span></em></p><p><em><span class="Apple-style-span" style="font-size: small">http://www.yourdomain.tld/RedTheme/images/CssImage.ashx?name=bg.png</span></em><span class="Apple-style-span" style="font-size: small"> </span></p><p><span class="Apple-style-span" style="font-size: small">instead of </span></p><p><em><span class="Apple-style-span" style="font-size: small">http://www.yourdomain.tld/GreenTheme/images/bg.png</span></em></p><p><em><span class="Apple-style-span" style="font-size: small">http://www.yourdomain.tld/RedTheme/images/bg.png</span></em><span class="Apple-style-span" style="font-size: small"> </span></p><p><span class="Apple-style-span" style="font-size: small">If the stylesheets contain links as specified above, the server has no choice nut to handover the ashx requests to ASP.NET runtime, thus our C# class coresponding to the CssImage.ashx file  will serve the images </span><em><strong><span class="Apple-style-span" style="font-size: small">WITH  </span></strong></em><span class="Apple-style-span" style="font-size: small">the caching headers such as EXPIRES and LOCATION in place. Values may also be set approperiately in code for these headers. Thus modifying the stylesheets by hand to change the contents of url(..) clauses, will solve our problem , but has Side Effects such as</span>.</p><p><span class="Apple-style-span" style="font-size: 18px"><span class="Apple-style-span" style="text-decoration: underline; -webkit-text-decorations-in-effect: underline">Loss of Designer support :</span></span> </p><p> </p><p><span class="Apple-style-span" style="font-size: small"> Having urls like </span></p><p><em><span class="Apple-style-span" style="font-size: small">background-color:url(''images/CssImage.ashx?name=bg.png'')</span></em><span class="Apple-style-span" style="font-size: small">   </span></p><p><span class="Apple-style-span" style="font-size: small">in style sheets in Visual Studio will result in loss of designer support. During Design time you can''t use the WYSIWYG editor. I hava developed a means of working around this too. </span></p><ol>							<li><span class="Apple-style-span" style="font-size: small"> Create CssImage.ashx files in all the Css image directories and poin them to our CssImagHandler C3 class as instructed before but DO NOT modify the stylesheet urls.  </span></li>							<li><span class="Apple-style-span" style="font-size: small">Create a HttpHandler that serves stylesheets. This new handler serves stylesheets (.css files) after modifying the contents - changing all the url(images/xx.jpg) to url(images/CssImage.ashx?name=xx.jpg) whenever serving. Also this handler can be used to set the Caching Headers and Policies for the .css files themselves providing further boost in performance.</span></li>							<li><span class="Apple-style-span" style="font-size: small">Put this handler(.ashx file) in all places where there are stylesheet. Again we have multiple ashx files pointing to the same class, so we have to seperate the class coding and the ashx file itself. ( For eg. Put the new Css.ashx file copies  in "GreenTheme" and "RedTheme")</span></li>							<li><strong><span class="Apple-style-span" style="font-size: small">Information </span></strong><span class="Apple-style-span" style="font-size: small">: So now we have a handler that modifies stylesheet url contents, so that the urls point to a handler that handles image requests. In both handlers we set cachig headers and policies.</span></li>							<li><strong><span class="Apple-style-span" style="font-size: small">Don''t do this</span></strong><span class="Apple-style-span" style="font-size: small"> : Now we have to(but we don''t - so don''t do this step - just understand) change the <link> tags in our aspx pages from </span><em><span class="Apple-style-span" style="font-size: small"><link href="GreenTheme/style.css" rel="stylesheet" ... /></span></em><span class="Apple-style-span" style="font-size: small">  to </span><em><span class="Apple-style-span" style="font-size: small"><link href="GreenTheme/Css.ashx?name=style.css" rel="stylesheet" ... /> </span></em><span class="Apple-style-span" style="font-size: small"> which againresults in loss of designer support. The Designeer looks for link tags and automatically applies the stylesheet.. having  </span><em><span class="Apple-style-span" style="font-size: small">GreenTheme/Css.ashx?name=style.css</span></em><span class="Apple-style-span" style="font-size: small"> in the link tag is not understood by the designer.</span></li>							<li><span class="Apple-style-span" style="font-size: small">Do This : Instead what we do is leave the link tags unchanged, but write code in </span><strong><span class="Apple-style-span" style="font-size: small">Page_Load</span></strong><span class="Apple-style-span" style="font-size: small"> or </span><strong><span class="Apple-style-span" style="font-size: small">OnLoad</span></strong><span class="Apple-style-span" style="font-size: small"> handler etc .. that changes the link tags </span><em><span class="Apple-style-span" style="font-size: small"><link href="GreenTheme/style.css" rel="stylesheet" ... /></span></em><span class="Apple-style-span" style="font-size: small">  to </span><em><span class="Apple-style-span" style="font-size: small"><link href="GreenTheme/Css.ashx?name=style.css" rel="stylesheet" ... /></span></em></li>							<li><span class="Apple-style-span" style="font-size: small">Thus we make sure DYNAMICALLY, DURING A REQUEST,		</span>		<ul>																						<li><span class="Apple-style-span" style="font-size: small">That link tags are modified to make the stylesheets pass through the stylesheet handler,</span></li>											<li><span class="Apple-style-span" style="font-size: small">which makes sure that urls in the stylesheets it serves are modified tomake the images be requested through the image handler,</span></li>											<li><span class="Apple-style-span" style="font-size: small">both the handlers setting Client & Server Caching policies and headers,</span></li>											<li><span class="Apple-style-span" style="font-size: small">and we don''t lose designer support becoz handlers do their job only during when they are requested.</span></li>											<li><span class="Apple-style-span" style="font-size: small">As far as the designer sees ... links tag hrefs & targets are okay... and target stylesheets urls are also okay</span></li>				</ul>				</li></ol><p><span class="Apple-style-span" style="font-size: small">So the functionality of our stylesheet handling class will be</span></p><ul>							<li><span class="Apple-style-span" style="font-size: small">Get the name of the stylesheet of the querystring</span></li>							<li><span class="Apple-style-span" style="font-size: small">Look for the file in the same directory as the ashx file, becoz we put stylesheet-handling ashx files in all directories containing stylesheets.</span></li>							<li><span class="Apple-style-span" style="font-size: small">For the previous step we can use the Request.Path property to get path of current request (that is the request to the Css.ashx file, when browser sees the modified <link> tags)</span></li>							<li><span class="Apple-style-span" style="font-size: small">Using that as a string, substringing to uptotheLastIndexOf(''\'') we get the directory where the Css.ashx file and the .css file itself is to be found.</span></li>							<li><span class="Apple-style-span" style="font-size: small">Append  <name(from QueryString)>.css to the working string got from the prevoius step and use File Reader to read in contents of the stylesheet</span></li>							<li><span class="Apple-style-span" style="font-size: small">Use Regular Expressions or the logic I usedto Modify the url(..) clauses and send the string to Server Cache and Response stream</span></li>							<li><span class="Apple-style-span" style="font-size: small">Insert code in the beginning of the class that checks if modifies stylesheet is in  the cache.. If present no need to read again.. just send the server -side cached copy.</span></li></ul><p> </p><p> </p><p><span class="Apple-style-span" style="font-size: small">All of the above concepts have implemetations in this site itself  </span><span class="Apple-style-span" style="font-size: small"><img src="/ZaszBlog/Admin/TinyMCE/plugins/emotions/images/smiley-cool.gif" border="0" alt="Cool" title="Cool" /> .. Download all code from </span><a href="/Downloads/Assembly.zip"><span class="Apple-style-span" style="font-size: small">http://www.chandruon.net/Downloads/Assembly.zip</span></a><span class="Apple-style-span" style="font-size: small"> and </span><a href="/Downloads/Site.zip"><span class="Apple-style-span" style="font-size: small">http://www.chandruon.net/Downloads/Site.zip</span></a><span class="Apple-style-span" style="font-size: small">  </span></p><p><span class="Apple-style-span" style="font-size: small">Inside them see the class CssImage.ashx and Image.ashx and Css.ashx and the classes to which they are pointing to.</span></p><p><span class="Apple-style-span" style="font-size: small"><span class="Apple-style-span" style="font-size: 11px"><a href="http://www.ieinspector.com/httpanalyzer/"><span class="Apple-style-span" style="font-size: 13px">http://www.ieinspector.com/httpanalyzer/</span></a><span class="Apple-style-span" style="font-size: 13px"> Here you can get the Http Analyser and check all this out for yourself. </span></span></span></p><p><span class="Apple-style-span" style="font-size: small"><span class="Apple-style-span" style="font-size: 11px"><span class="Apple-style-span" style="font-size: 13px">Happy developing!</span></span></span></p>', CAST(0x00009B5500BEE330 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'ReBlog--Has-Google-Blundered-with-the-Gmail-Beta', N'ReBlog : Has Google Blundered with the Gmail Beta?', N'<p class="content">
The traditional business model of webmail providers worked by squeezing the storage quotas of the free users of the webmail service, and forcing users to upgrade to a premium service. Someone at Google realized that earning money from webmail by selling premium services was always going to be a tough ask, and an alternative business model was needed. The idea he/she came up was to focus on pushing targeted ads to the users of the webmail service. The idea is brilliant in its simplicity. All an email provider needs to do is to scan the message the user has asked to be displayed for keywords, and display some relevant ads along with it; the ad clicks come automatically. 
</p>
<p class="content">
 
</p>
<p class="content">
While developing this idea the Google people also realized that the new business model did not depend on squeezing the storage quotas of the users. The people at Google calculated that storage quotas of 1GB and more can be offered without an inordinate amount of expense. A whole Gigabyte of storage space for webmail was almost unthinkable at the time Google conceived of the idea. It would have been a massive marketing coup for Google''s new webmail service had the company offered such a storage quota to the mainstream user. Google did combine the two big insights it had, and several other innovations into its Gmail service. Gmail seems to be everything the users want. It offers users a large storage quota, has excellent email search capabilities, and incorporates a number of usability enhancements such as threaded discussions, and labels for grouping emails. Unfortunately, Gmail is still in beta and the average person can''t sign up for the service. 
</p>
<p class="content">
 
</p>
<p class="content">
While Gmail is in beta its competitors are busy copying its features. The massive storage quota of Gmail must have really scared Yahoo and Hotmail, so this was the first thing they copied. As of now Yahoo is offering 100 MB quotas on its free email accounts, and Hotmail is offering 250 MB. This is quite a big change from the paltry 4 MB and 2 MB quotas Yahoo and Hotmail were offering previously. Gmail''s competition is not trying to beat Gmail, but is only interested in avoiding a mass exodus of users. The well-established webmail players understand that switching a primary email address is a non-trivial task for any user. A user has to inform all of his/her contacts of the new email address, and even after doing that email just keeps on coming at the old email address. By offering larger quotas Gmail''s competition is trying to reduce the incentive of users to switch to Gmail. Gmail''s competitors certainly won''t stop at storage quotas; it is safe to assume that most of Gmail''s innovations will be incorporated into competing webmail services even before Gmail comes out of beta. 
</p>
<p class="content">
 
</p>
<p class="content">
Gmail''s beta was most likely a poorly planned exercise in market research. Google was interested in monitoring the behavior of Gmail users, and collecting data about ad click rates, searching habits, storage use, etc. Unfortunately, all of Google''s data collection will be useless, as the typical Gmail beta-tester is likely to be much more loyal to Gmail than the typical user which signs up after the beta. When Gmail finally comes out of the beta, users will certainly sign up in droves, but many of these users will only use Gmail as just another email account. With all the catching up Gmail''s competition is doing, users simply won''t have sufficient incentive to make Gmail their primary email address. This will translate into less ad clicks, lower revenue, and less profitability for Gmail. Had Google introduced Gmail without giving Gmail''s competitors time to clone Gmail''s functionality, a big fraction of web-mail users would have switched wholesale to Gmail. Gmail''s competitors would have been caught unprepared. Many of them would have panicked and done stupid things to stem the exodus of users to Gmail. Fortunately for them, Gmail''s beta gave everyone ample breathing room. 
</p>
<p class="content">
 
</p>
<p class="content">
Companies do betas because they expect a beta-tested product to yield more profits: better products typically lead to more sales and revenue. Unfortunately, Gmail''s beta has done more harm than good to Gmail''s prospects, and thus has been contradictory to the goals of a beta. Public betas are always a compromise between increasing the robustness of a product/service, and divulging product functionality and business plans. In some situations public betas are unavoidable. Microsoft has to release betas of Windows to developers, and a wide userbase in order to produce a usable version of Windows. By doing alphas and betas Microsoft is inviting its competitors to copy upcoming Windows functionality. In case of Longhorn, Linux developers are certainly picking and choosing functionality. A lengthy beta makes sense for Longhorn as Linux developers will not be able to clone all of Longhorn''s core functionality before Microsoft releases a final version. However, Gmail just doesn''t have the kind of sophisticated functionality which requires years of development effort to duplicate. If Hotmail''s creators had done what Google has done, there would be no Hotmail today. Other companies would have seen Hotmail''s potential and introduced competing web-mail services to snag users before Hotmail could. 
</p>
<p class="content">
 
</p>
<p class="content">
The most sensible course of action for Google was to do no beta or a very short beta. A couple of weeks of beta-testing would have sufficed for the level of functionality Gmail is offering. For market research, the company should have relied on some alternative means or preferably skipped the market research altogether. After all there aren''t many startups who would delay their product 6 months to collect some questionable statistics. Another option for Google was to do a limited beta, but do it in a way to mislead its competition. Google could have started the beta with a 10 MB storage quota for Gmail with the final release version of the service offering 1 GB. Of course, no one outside of Google was to be told of Google''s intent to offer 1 GB in the final version of the service. 
</p>
<p class="content">
 
</p>
<p class="content">
Unfortunately, the damage has been done, and these options are irrelevant to Google. Google can try to surprise its competitors by introducing significant new functionality in the final release of Gmail. But, the company seems to have played its best cards, and a radical revision of Gmail is unlikely. Gmail has certainly transformed the web-mail scene, and it will be a definite success. However, Gmail could have done much much better, and there are some important lessons to be learned. Companies must keep in mind that there are drawbacks to betas and ignoring the drawbacks can have disastrous consequences. 
</p>
<p class="content">
<br />
<br />
<br />
Based on views by <a href="http://www.techuser.net/about.html">Usman Latif</a>  [Aug 28, 2004] 
</p>
', CAST(0x00009B070101A120 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Starcraft-2-Opts-out-of-local-Multiplayer', N'Starcraft 2 Opts out of local Multiplayer', N'<a rel="nofollow" href="http://www.gamespot.com/pages/common/login.php"></a><br />
<div class="head">
<div class="wrap">
<h2>Starcraft II jettisons LAN support</h2>
<p>
 
</p>
</div>
</div>
<ul class="byline">
	<li>By <em class="title"><a href="http://www.gamespot.com/users/TomM_GScom/">Tom Magrino</a>, <a href="http://www.gamespot.com/"><em>GameSpot</em></a></em></li>
	<li class="date">Posted <strong>Jun 30, 2009 11:45 am PT</strong></li>
</ul>
<p class="deck">
 
</p>
<p class="deck">
Blizzard confirms anticipated sci-fi RTS will skip local multiplayer due to piracy, quality concerns.
</p>
<p>
 
</p>
<p>
As part of <a href="http://www.gamespot.com/news/6210427.html" class="gslink">Activision Blizzard''s pre-2009 Electronic Entertainment Expo tele-press conference</a>,
Blizzard Entertainment executive Michael Morhaime confirmed what many
had suspected: Starcraft II: Wings of Liberty is expected to launch for
the PC alongside the newly redesigned Battle.net online networking
service before the end of the year. However, when Starcraft II does see
release, it will do so without a hallmark of the real-time strategy
genre: a local area network multiplayer option.
</p>
<p>
 
</p>
<div class="embscreen">
<a href="http://www.gamespot.com/images/6212765/starcraft-ii-jettisons-lan-support/1/?path=2009%2F180%2FStarcraftII566_screen.jpg&caption=So%2Bmuch%2Bfor%2BStarcraft%2BII%2BLAN%2Bparties...&blog=1&cvr=AcG0">
<div style="text-align: center">
<img class="thumb" src="http://image.com.com/gamespot/images/2009/180/StarcraftII566_embed.jpg" alt="" />
</div>
</a>
<p class="caption">
 
</p>
<p class="caption">
<a href="http://www.gamespot.com/images/6212765/starcraft-ii-jettisons-lan-support/1/?path=2009%2F180%2FStarcraftII566_screen.jpg&caption=So%2Bmuch%2Bfor%2BStarcraft%2BII%2BLAN%2Bparties...&blog=1&cvr=AcG0">So much for Starcraft II LAN parties...</a>
</p>
<p class="caption">
 
</p>
</div>
<p>
Blizzard today confirmed for GameSpot that LAN functionality will be
absent from Starcraft II''s multiplayer component, as both a piracy
prevention mechanism and a quality-assurance initiative.
</p>
<p>
 
</p>
<p>
"We don''t currently plan to support LAN play with Starcraft II,
as we are building Battle.net to be the ideal destination for
multiplayer gaming with Starcraft II and future Blizzard Entertainment
games," a Blizzard representative said in a statement. "While this was
a difficult decision for us, we felt that moving away from LAN play and
directing players to our upgraded Battle.net service was the best
option to ensure a quality multiplayer experience with Starcraft II and
safeguard against piracy."
</p>
<p>
 
</p>
<p>
"Several Battle.net features like advanced communication
options, achievements, stat-tracking, and more, require players to be
connected to the service, so we''re encouraging everyone to use
Battle.net as much as possible to get the most out of Starcraft II,"
the statement continued. "We''re looking forward to sharing more details
about Battle.net and online functionality for Starcraft II in the near
future."
</p>
<p>
 
</p>
<p>
Speaking with GameSpot during BlizzCon 2008, <a href="http://www.gamespot.com/news/6199603.html" class="gslink">Blizzard Entertainment cofounder Frank Pearce noted</a> that piracy was a concern for the developer and that Battle.net would play a role in helping to counteract theft of the game. 
</p>
<p>
 
</p>
<p>
"We''re definitely talking about ways with Battle.net that we can
provide the best online experience for our customers so that there''s
not an incentive to pirate the product but instead an incentive to be
part of that community of gamers playing that game and they''d want to
be part of that social experience on top of the single-player
experience," he said.
</p>
<p>
 
</p>
<p>
 
</p>
<p>
And more such crap. This means a huge problem - LAN engines like garena cant use starcraft. You must buy Battle.NET accounts - sad thing to buy in India ( - poor service ) And if u want to play with your brother for example, you need two licensed copies of Starcraft 2 and an active battle.net account. On top of that since the server is far away u experience poor QoS.... wtf?? Blizzard will go down if it keeps this up..
</p>
', CAST(0x00009C3900A85D90 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'This-site-is-going-to-get-an-overhaul!', N'This site is going to get an overhaul!', N'<p><span class="Apple-style-span" style="font-size: medium">I just moved this site to the cloud, and just decided that this whole shebang needs an overhaul. The new site, I''m afraid, will be less personal and more sleek and shiny, with a business look - think wordpress! And some parts may not work. </span></p><p><span class="Apple-style-span" style="font-size: medium"> </span></p><p><span class="Apple-style-span" style="font-size: medium">Net feeling after porting to cloud is : It''s almost like owning another computer, except you can''t touch it. Installed usual stuff like chrome, notepad++ and even VLC media player on my server :P - Amazing the amount of control you have over your hardware. Now Server OSes which used to do some virtualization over hardware,  might just degenerate back into simpler versions, as they find themselves suddenly running on virtualized hardware.</span></p><p> </p><p><span class="Apple-style-span" style="font-size: medium">And other feeling is Windows Authentication in IIS really sucks - it needs a whole bunch of configuration, and after that, it needs some more configuration, and after that - just a little more configuration and finally it does''nt work (something about NETWORK SECURITY account needing permissions on a folder etc, it does work after setting it, though) . Enjoy using SQL Server authentication instead, and on a side note - there is this cloud advantage - if you install (or enable) iSCSI then you got 30 GB of hard disk on the internet - It Is Yours To Own and as fast as your internet connection.</span></p><p><span class="Apple-style-span" style="font-size: medium"> </span></p><p><span class="Apple-style-span" style="font-size: medium">I hope to get rid of the the comment spam on some posts once and for all, it discourages my friends to leave a comment or two when they read the post. And ReCAPTCHA comes to the mind - no more quick and easy comments. Happy Diwali everyone ! Night sky is so lit up (atleast upto the point when it rained). </span></p><p><span class="Apple-style-span" style="font-size: medium"> </span></p><p><span class="Apple-style-span" style="font-size: medium">Updates :</span></p><p><span class="Apple-style-span" style="font-size: medium"> </span></p><p><span class="Apple-style-span" style="font-size: medium">For those people who enjoy Wodehouse : Terry Pratchett & Neil Gaiman''s - Good Omens  is a must. [ </span><a href="http://en.wikipedia.org/wiki/Good_Omens"><span class="Apple-style-span" style="font-size: medium">http://en.wikipedia.org/wiki/Good_Omens</span></a><span class="Apple-style-span" style="font-size: medium"> ]</span></p><p> </p><p><span class="Apple-style-span" style="font-size: medium">And those Noobs a.k.a Starcrafters : Check out Husky'' VLOG - www.youtube.com/HuskyStarcraft </span></p><p> </p><p><span class="Apple-style-span" style="font-size: medium">And Dota-maniacs : Valve hires Icefrog for Dota 2.0 ETA 2011 [ </span><a href="http://www.rockpapershotgun.com/2010/10/13/valve-announces-dota-2/"><span class="Apple-style-span" style="font-size: medium">http://www.rockpapershotgun.com/2010/10/13/valve-announces-dota-2/</span></a><span class="Apple-style-span" style="font-size: medium"> ]</span></p>', CAST(0x00009E25011B7280 AS DateTime), N'Both')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'ThoughtWorks', N'ThoughtWorks', N'<p>
In Diamond District, Bangalore, @ ThoughtWorks for training. 
</p>
<p>
 
</p>
<p>
 
</p>
<p>
Some cool stuff. Hehehe Here Training = fun activities, makin new frnds, shopping, buffet in 5 star hotels. (Till now) Bangalore is colder than chennai, (AC apartments provided <img src="/ZaszBlog/Admin/TinyMCE/plugins/emotions/images/smiley-cool.gif" border="0" alt="Cool" title="Cool" /> duh!) and 4 outa 5 people know tamil here, Nice. Damn I dont have our family digicam (zzzzzzzzz), I may be buying new one here. Got to meet some cool people (some foreign guys even), and know some JOB stuff like bank accounts (yay!), tax <img src="/ZaszBlog/Admin/TinyMCE/plugins/emotions/images/smiley-cry.gif" border="0" alt="Cry" title="Cry" /> , insurance etc.
</p>
<p>
 
</p>
<p>
 
</p>
<p>
Looking for the gaming communities here, while learning all the infrastructure and admin stuff. Looks like being Dev is a hectic job, but ideal one for career climbing. Found out a person can be overwhelmed by meeting excess contacts and necessity to remember all of ''em. ^_^
</p>
<p>
 
</p>
<p>
 Addendum : October 5
</p>
<p>
 
</p>
<p>
Mascal TW Trip :
</p>
<p>
 
</p>
<div align="center">
<img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\IMG_0827zz.JPG" alt="" />
</div>
<div align="center">
  <br />
</div>
<div align="center">
Me Setting Up Tent<br />
<br />
<br />
<img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\IMG_0902zz.JPG" alt="" />
</div>
<div align="center">
 
</div>
<div align="center">
Me Jumaring Ready <br />
</div>
<div align="center">
<br />
<img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\IMG_0905zz.JPG" alt="" /><br />
<br />
</div>
<div align="center">
Me Jumaring HalfWay<br />
<br />
<img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\IMG_0908zz.JPG" alt="" />
</div>
<div align="center">
 
</div>
<div align="center">
Me Jumaring  TOP<br />
</div>
<div align="center">
 
</div>
<div align="center">
<img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\IMG_2574.JPG" alt="" /><br />
<br />
</div>
<div align="center">
Me Rappelling
</div>
<div align="center">
<br />
<img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\IMG_2612.JPG" alt="" />
</div>
<div align="center">
 
</div>
<div align="center">
Frnds Priyanka, Soumya, Jake <br />
</div>
<div align="center">
 
</div>
<div align="center">
<br />
<br />
<img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\IMG_2557zz.JPG" alt="" />
</div>
<div align="center">
 
</div>
<div align="center">
Group Click<br />
</div>
<br />
<br />
<br />
', CAST(0x00009C9100CAB2A0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Training-At-TWU', N'Training At TWU', N'<p>ThoughtWorks University training , is a very different experience. Talk about diversity, our batch of 14 people including one 1 U.S. participant , have trainers from Netherlands( who likes to hand out dropjes ) , from australia (who likes to impersonate/enact clients, P.M.s, and meetings for making the concepts clear to us) , from london (who plays basketball with me, who is also a PC gamer), and from India. We have training at Hotel Royal Orchid, (imba lunches and breakfasts), and here are some photos snapped during sessions.</p><p> </p><p>Check the same photos on Facebook : <a href="http://www.facebook.com/photo.php?pid=2631903&l=69d71df328&id=815596121"><span>http://www.facebook.com/photo.php?pid=2631903&l=69d71df328&id=815596121</span></a></p><p> </p><p> </p><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image328.jpg" alt="" width="60%" height="60%" /><p> </p><p> My China Clay Phone developed over Evolving requirements</p><p> </p><p> </p><p> </p><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image329.jpg" alt="" width="60%" height="60%" /><p> </p><p>Ice Cream meter = logs late comers = too many late comings and u end up sponsoring the ice cream treat for the weekend for the team</p><p> </p><p> </p><p> </p><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image330.jpg" alt="" width="60%" height="60%" /><p> </p><p>Puzzles, Parking for questions and Accomplishments Post-its</p><p> </p><p> </p><p> </p><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image331.jpg" alt="" width="60%" height="60%" /><p> </p><p>After 2 weeks!</p><p> </p><p> </p><p> </p><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image332.jpg" alt="" width="60%" height="60%" /><p> </p><p>Agile Software development session.<br />4 iterations (3 mins / iteration build time ) (= 12 mins).<br />Changing requirements.<br />Continuous client feedback. etc etc blah blah...</p><p> </p><p> </p><p> </p><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image333.jpg" alt="" width="60%" height="60%" /><p> </p><p>Our pizza delivery system... it will suck if implemented as per our specifications!</p><p> </p><p> </p><p> </p><img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image334.jpg" alt="" width="60%" height="60%" /><p> </p><p>Classroom</p><p> </p><p> </p><p> </p>', CAST(0x00009C9B014C9C70 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'USB-Guard', N'USB Guard', N'<p>
 
</p>
<p>
To enable the viewing of Hidden files follow these steps:<br />
<br />
Close all programs so that you are at your desktop. <br />
Double-click on the My Computer icon. <br />
Select the Tools menu and click Folder Options. <br />
After the new window appears select the View tab. <br />
Put a checkmark in the checkbox labeled Display the contents of system folders. <br />
Under the Hidden files and folders section select the radio button labeled Show hidden files and folders. <br />
Remove the checkmark from the checkbox labeled Hide file extensions for known file types. <br />
Remove the checkmark from the checkbox labeled Hide protected operating system files. <br />
Press the Apply button and then the OK button and shutdown My Computer. <br />
Now your computer is configured to show all hidden files. <br />
<br />
<br />
Next you will click on Start --> Run and type in “gpedit.msc” and press “Enter”. Then you will open “Group Policy”. There you will select User Configuration --> Administrative Templates --> System --> and there you will double click on  “Turn Off Autoplay” and in the window there you should select “Enabled” and select “All drives” (they say in this Thai webside that select all turn of Autoplay will be safer for not getting viruses). Now you can close the Group Policy.<br />
<br />
<br />
If a file has both the hidden and system attributes set, an attempt to remove only one of the attributes failS with one of the above error messages. For example, if the file C:\ONE.TWO is marked as both system and hidden, the command(s) 
</p>
<p>
<br />
c:\dos\attrib c:\one.two -h <br />
<br />
c:\dos\attrib c:\one.two -s 
</p>
<p>
<br />
produce the respective error messages: 
</p>
<p>
<br />
Not resetting system file C:\ONE.TWO <br />
Not resetting hidden file C:\ONE.TWO 
</p>
<p>
<br />
To remove either attribute, use the following command to remove BOTH attributes at the same time: <br />
c:\dos\attrib c:\one.two -s -h 
</p>
<p>
<br />
If necessary, you can use the following command to remove the read-only, system, and hidden attributes simultaneously: <br />
c:\dos\attrib c:\one.two -s -h -r 
</p>
<p>
 
</p>
<p>
You can check if your pen drive has viruses by, going to the command prompt, <strong>cd </strong>ing to the pen drive, and checking whether a certain <strong>autorun.inf</strong> file is present. If present type autorun.inf in the prompt to see what <em>particular file(s)</em> is given in it. All the <em>particular file(s) are viruse(s)  </em>unless you know for sure that they are''nt. You can delete them using the <strong>attrib -s -h -r <filename or folder name></strong> command, and the <strong>erase/a </strong>command, and the <strong>del/a</strong> & <strong>rmdir - S </strong>commands.
</p>
', CAST(0x00009B10017B93E0 AS DateTime), N'Pro')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'Welcome-to-ZaszBlog', N'Welcome to ZaszBlog', N'<p>
<font size="3">If you see this post it means that ZaszBlog is up and running. Now the only thing that remains is for you to get in and start talking to the world. There are features to explore and take advantage of, for those who''re inquisitive. Now this will soon become full version, till then please feel free to try out anything and all.</font> 
</p>
<h2><font size="5">Permission to address the world</font></h2>
<p>
<font size="3">To be able to log in to the blog and writing posts, you need to get yourself an account, this can be done by sending me an email. All of the CSE ''A'' TCE class students, and some of the old-timers will have one account by the time this comes out of beta. This is where you can put up anything you know or would like to know, anything at all that would give you life on the Internet. Beta-testers you can download the entire source for this website, for now its given as a link, which i update after every revision, soon you can use the svn repository directly, soon as the proper arrangements are made with the Web Host.</font> 
</p>
<h2><font size="5">Posts & Pages</font></h2>
<p>
<font size="3">Find the sign-in link located in the Navigation Tree and click it. Put in your username and password, which you ought to know, if your account was created by email to me, then you will or would''ve been given your credentials also by mail. Now you can use the Control Panel to create your posts and pages. These will be exposed to all users of the Internet, and subject to commenting, if what you created was a post.  Pages are just static information, which you can use to upload your photos, or software, or projects you''re working on, and so on. You design them anyway you like and you will see link to it on the home page after you have created it. You can use any html editor(Frontpage, Publisher) to create your pages, and put in the html here. Create as many as you would like and organize them if needed setting Parent-Child settings. You can later link to these pages in any post or comment here, or practically from anywhere else from the internet(mail, blog, forum, etc.)</font> 
</p>
<h2><font size="5">On the web</font> </h2>
<p>
<font size="3">You can find other details on the <a href="/">Main Page</a>. Also check out the BlogEngine.NET </font><font size="3">project </font><font size="3">which inspired this blog on Codeplex where you''ll find tutorials, documentation, tips and tricks and much more. The ongoing development of this website can be followed at the <a href="/Linkz.aspx">Linkz</a> where the daily builds will be put up. </font>
</p>
<p>
<font size="3">Good luck and happy writing. </font>
</p>
<p>
<font size="3">T. Chandirasekar </font>
</p>
', CAST(0x00009A8600000000 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'WTF-Sadness', N'WTF Sadness', N'<p><span class="Apple-style-span" style="font-size: large">The renowned  and the famous </span><span class="Apple-style-span" style="font-weight: bold"><span class="Apple-style-span" style="font-size: large">clan</span></span><span class="Apple-style-span" style="font-size: large"> </span><span class="Apple-style-span" style="font-weight: bold"><span class="Apple-style-span" style="font-style: italic"><span class="Apple-style-span" style="text-decoration: underline"><span class="Apple-style-span" style="font-size: large">Feeder</span></span><span class="Apple-style-span" style="font-style: normal; font-weight: normal"><span class="Apple-style-span" style="font-size: large"> comprised of</span></span></span></span></p><p><span class="Apple-style-span" style="font-size: large"> </span></p><ul>	<li>Feeder~SamJEf.in         (Captain)<br />	</li>															<li>Feeder~Imini.in<br />	</li>															<li>Feeder~Zasz.in             a.k.a. Zasz.zasZ                      (Commander)								</li>															<li>Feeder~Starcraft.in       a.k.a. Feeder~Kamal                a.k.a. kamalanth</li>															<li>Feeder~Nitin.in              a.k.a. Phantom~Nitin               (Well-Known leaver lagger)</li>															<li>Feeder~Tony.in             (Administrator)</li>															<li>Feeder~Muthu.in                                                         (Cheerlead) </li>											<li>Feeder~Maddy.in                                                        (Team Mascot)</li>	<li>Feeder~6x-xxxxxx.in     (AFK member)<br />	</li>											<li>Feeder~Ravi.in              (currently Inactive)</li>									<li>Feeder~Qqqqqqqq.in      (currently Inactive)<br />	</li>									<li>Feeder~baabz.in            (currently Inactive)<br />	</li></ul><p> </p><p><span class="Apple-style-span" style="font-size: medium">has made history. Never has the world seen such skill. Demonstrated in the following attached replay :</span></p><p><span class="Apple-style-span" style="font-size: medium"> </span></p><p style="text-align: center"><a rel="enclosure" href="http://chandruon.net/ThonHttpHandlers/File.ashx?filepath=~/App_Data/ZaszBlog/Files\Ultimate+Feeding.w3g">Ultimate Feeding.w3g (663.13 kb)</a></p><p> </p><p> </p><p>Note: While downloading this from certain browsers(Mozilla FF), you may need to rename the downloaded file to the name shown in the link. </p><p> </p><p>Statuatory Warning : Pls don see this if u are in a good mood.</p><p> </p><p>Teams MYM and Ks.int can''t hold a candle to team Feeder. </p><p> </p><p>Tonight we played a game we almost won 29 - 31. not as bad as the attached replay. </p><p>Kamal left so we lost.</p><p> </p><p> </p><p><span class="Apple-style-span" style="font-weight: bold">The replay needs v1.23 Warcraft Frozen Throne and,  Dota 6.59d map in Maps\DOTA directory.</span></p><p> </p><p>Feeder team, if u see this, leave ur main Email ids as comment. I have only maddy''s , mano''s and desingh''s. Not sure if they are the main ids though!</p><p> </p><p> </p>', CAST(0x00009C1E01815870 AS DateTime), N'Rest')
INSERT [dbo].[Posts] ([Slug], [Title], [Content], [Timestamp], [Site_Name]) VALUES (N'ZaszzasZ', N'Zasz.zasZ', N'<p> </p><p> </p><p style="text-align: center"><span class="Apple-style-span" style="font-size: x-large">Zasz.zasZ</span> </p><p style="text-align: center">Level 22 Noob </p><p style="text-align: center"> </p><p><font face="''comic sans ms'', sand">I''ve been hiding behind this ID on Garena for a long time. It seems correct to connect me and my ID here </font><font face="''comic sans ms'', sand"><img src="/ZaszBlog/Admin/TinyMCE/plugins/emotions/images/smiley-cool.gif" border="0" alt="Cool" title="Cool" />.  Searching Google for Zasz.zasZ gave no results pointing to me so, me is writing this post! Zasz is the main villain in starcraft belonging to the Zerg community, starcraft brood wars used to engage me for a while some years before. Some bugger took Zasz ID already and so now I''m Zasz.zasZ </font><font face="''comic sans ms'', sand"><img src="/ZaszBlog/Admin/TinyMCE/plugins/emotions/images/smiley-cry.gif" border="0" alt="Cry" title="Cry" />. Also having 3 more IDs </font><span class="Apple-style-span" style="text-decoration: underline"><font face="''comic sans ms'', sand">Feeder~Zasz</font></span><font face="''comic sans ms'', sand"> and </font><font face="''comic sans ms'', sand" style="text-decoration: underline">ItsPayne</font><font face="''comic sans ms'', sand"> and <span class="Apple-style-span" style="text-decoration: underline">~Feed3R~</span>.</font></p><p><font face="''comic sans ms'', sand"> </font></p><p> </p><p><font face="''comic sans ms'', sand">Clan history : Belonged to DOTA clans Blood Hunters </font><strong><font face="''comic sans ms'', sand">BB@D</font></strong><font face="''comic sans ms'', sand"> first as examiner, then Xiaolin </font><strong><font face="''comic sans ms'', sand">a[k]</font></strong><font face="''comic sans ms'', sand"> clan as examiner, now in Sk-Hunters </font><strong><font face="''comic sans ms'', sand">krypt</font></strong><font face="''comic sans ms'', sand"> clan as organizer. Me only level 22 so cant create a clan of my own. Me and college frnds including Tony(Deingh), Kamal, Jine (Mano), planned on creating the feeder clan when we were in college, seeing how poor we played lolz. Now all of us are decent players thanks to sad long hours in Garena xD.</font></p><p> </p><p><font face="''comic sans ms'', sand"> </font></p><p><font face="''comic sans ms'', sand">Ladder history last season : 146 wins 111 loses including Dcs. Played only 1 season ladder, coz ladder is MFing, full of leavers hackers powercuts and sad hosts.</font></p><p> </p><p><font face="''comic sans ms'', sand"> </font></p><p><font face="''comic sans ms'', sand">Havent updated my site for a while now, Havent learned a new language (dream about ruby and php) , havent read a novel continuosly because of going out with frnds or xbox or garena. And 26 days of holidays only remaining before going to job </font><font face="''comic sans ms'', sand"><img src="/ZaszBlog/Admin/TinyMCE/plugins/emotions/images/smiley-frown.gif" border="0" alt="Frown" title="Frown" />.  TCS doesnt seem to care about us recruits, but anyway me going for ThoughtWorks 5.15 per anum and job in chennai, is sure sweeter than 3.15 per anum and job @ who knows where. Many college frnds coming to chennai for job, I seem to be spending time on giving them tours lolz. 2 guys were lucky when i got permission to take our car out for the roaming around :-)</font></p><p> </p><p><font face="''comic sans ms'', sand"> </font></p><p><font face="''comic sans ms'', sand">Russel Peters new video Red White and Brown Rocks! And so does JayZ ft rihanna and kayne west Run this Town! Still watching and waiting for Starcraft 2 and Diablo 3 to come out. Monk gameplay and intro trailers are good, but not worth the download - 12 mins video only for 68 mb, that too poor quality in Hi-Res?? Blizzard downloader utility also sucks not allowing us to resume pause downloads. OK having publicized Zasz.zasZ in my site me signin'' out.</font></p><p><font face="''comic sans ms'', sand"> </font></p><p><font face="''comic sans ms'', sand"> </font></p><p><font face="''comic sans ms'', sand">Garena Clan Profile :  </font><a href="http://www1.garena.com/clan/index.php?module=memberprofile&uid=11087057"><font face="''comic sans ms'', sand">http://www1.garena.com/clan/index.php?module=memberprofile&uid=11087057</font></a><font face="''comic sans ms'', sand"> </font></p><p><font face="''comic sans ms'', sand">Garena Forum Profile : </font><a href="http://www.garena.com/forum/viewpro.php?uid=11087057"><font face="''comic sans ms'', sand">http://www.garena.com/forum/viewpro.php?uid=11087057</font></a><font face="''comic sans ms'', sand"> </font></p><p> </p><p style="text-align: center"> </p><p> </p><div style="text-align: center"><a style="font-size: 11px; font-variant: normal; font-style: normal; font-weight: normal; color: #3b5998; text-decoration: none" href="http://en-gb.facebook.com/Chandirasekar.Zasz" target="_TOP" title="Chandirasekar Zasz">Chandirasekar Zasz</a><span style="font-family: ''lucida grande'', tahoma, verdana, arial, sans-serif; font-size: 11px; line-height: 16px; font-variant: normal; font-style: normal; font-weight: normal; color: #555555; text-decoration: none"> | </span><a style="font-size: 11px; font-variant: normal; font-style: normal; font-weight: normal; color: #3b5998; text-decoration: none" href="http://en-gb.facebook.com/facebook-widgets/" target="_TOP" title="Make your own badge!">Create your badge</a></div><!-- Facebook Badge START --><div style="text-align: center"><a href="http://en-gb.facebook.com/Chandirasekar.Zasz" target="_TOP" title="Chandirasekar Zasz"><span class="Apple-style-span" style="color: #000000; -webkit-text-decorations-in-effect: none"></span></a><a href="http://en-gb.facebook.com/Chandirasekar.Zasz" target="_TOP" title="Chandirasekar Zasz"><img style="border-style: initial; border-color: initial; border-width: 0px" src="http://badge.facebook.com/badge/815596121.2578.703699520.png" alt="" width="360" height="265" /></a></div><p style="text-align: center"> </p><p style="text-align: center"> </p><p style="text-align: center">Some Pics :)</p><p style="text-align: center"> </p><p style="text-align: center"> </p><table border="0" cellspacing="10px">	<tbody>		<tr>			<td>			<a href="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\fountain+gone.JPG" target="_blank"> <img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\fountain+gone.JPG" alt="" width="400px" height="300px" /></a> </td>						<td>			<a href="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\feeders.JPG" target="_blank">			<img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\feeders.JPG" alt="" width="400px" height="300px" /></a>			</td>				</tr>		<tr>			<td>			Fountain Gone! Destroyed by Skeleton King Leoric</td>			<td>			Feeder Team (We Won)			</td>				</tr>	</tbody></table>', CAST(0x00009C7F01342AA0 AS DateTime), N'Rest')
/****** Object:  Table [dbo].[Passphrases]    Script Date: 05/02/2011 17:38:52 ******/
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
/****** Object:  Table [dbo].[Logs]    Script Date: 05/02/2011 17:38:52 ******/
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
/****** Object:  Table [dbo].[EdmMetadata]    Script Date: 05/02/2011 17:38:52 ******/
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
/****** Object:  Table [dbo].[Tags]    Script Date: 05/02/2011 17:38:52 ******/
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
/****** Object:  Table [dbo].[TagPosts]    Script Date: 05/02/2011 17:38:52 ******/
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
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'gwt java', N'Integrity')
INSERT [dbo].[TagPosts] ([Tag_Name], [Post_Slug]) VALUES (N'java', N'Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61')
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
/****** Object:  ForeignKey [Tag_Posts_Source]    Script Date: 05/02/2011 17:38:52 ******/
ALTER TABLE [dbo].[TagPosts]  WITH CHECK ADD  CONSTRAINT [Tag_Posts_Source] FOREIGN KEY([Tag_Name])
REFERENCES [dbo].[Tags] ([Name])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagPosts] CHECK CONSTRAINT [Tag_Posts_Source]
GO
/****** Object:  ForeignKey [Tag_Posts_Target]    Script Date: 05/02/2011 17:38:52 ******/
ALTER TABLE [dbo].[TagPosts]  WITH CHECK ADD  CONSTRAINT [Tag_Posts_Target] FOREIGN KEY([Post_Slug])
REFERENCES [dbo].[Posts] ([Slug])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagPosts] CHECK CONSTRAINT [Tag_Posts_Target]
GO
