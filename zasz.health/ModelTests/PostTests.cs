using Xunit;
using zasz.me.Models;

namespace zasz.health.ModelTests
{
    public class PostTests
    {
        private readonly Post postOne;
        private readonly Post postTwo;

        public PostTests()
        {
            postOne = new Post
                          {
                              Content =
                                  "<p>After installing patch 1.1, which completed successfully, everything else broke. Can't play multiplayer, nothing happens after pressing <strong>Find match</strong> (except that button getting disabled and text changing to <strong>waiting</strong>).</p><p> </p><p>Takes a long while to switch between single and multiplayer etc, and I've disabled all firewall antivirus etc. It all worked fine before. Blizzard is on a pedestal AFAIK but it really sucks if patches come out this way  :( I mailed it o 'em and raised an issue. What else? </p><p> </p><p>ZZZZZZZZZZZZZZZZZZZ </p><p> </p><p>Do something Blizzard! </p>"
                          };
            postTwo = new Post
                          {
                              Content =
                                  "<p>  <!--  /* Font Definitions */  @font-face  {font-family:SimSun;  panose-1:2 1 6 0 3 1 1 1 1 1;  mso-font-alt:宋体;  mso-font-charset:134;  mso-generic-font-family:auto;  mso-font-pitch:variable;  mso-font-signature:3 135135232 16 0 262145 0;}  @font-face  {font-family:'@SimSun';  panose-1:2 1 6 0 3 1 1 1 1 1;  mso-font-charset:134;  mso-generic-font-family:auto;  mso-font-pitch:variable;  mso-font-signature:3 135135232 16 0 262145 0;}  /* Style Definitions */  p.MsoNormal, li.MsoNormal, div.MsoNormal  {mso-style-parent:'';  margin:0in;  margin-bottom:.0001pt;  mso-pagination:widow-orphan;  font-size:12.0pt;  font-family:'Times New Roman';  mso-fareast-font-family:SimSun;}  @page Section1  {size:8.5in 11.0in;  margin:1.0in 1.25in 1.0in 1.25in;  mso-header-margin:.5in;  mso-footer-margin:.5in;  mso-paper-source:0;}  div.Section1  {page:Section1;}  /* List Definitions */  @list l0  {mso-list-id:813832042;  mso-list-type:hybrid;  mso-list-template-ids:-1770370396 67698703 67698713 67698715 67698703 67698713 67698715 67698703 67698713 67698715;}  @list l0:level1  {mso-level-tab-stop:.5in;  mso-level-number-position:left;  text-indent:-.25in;}  @list l1  {mso-list-id:1241715920;  mso-list-type:hybrid;  mso-list-template-ids:3807600 67698703 67698713 67698715 67698703 67698713 67698715 67698703 67698713 67698715;}  @list l1:level1  {mso-level-tab-stop:.5in;  mso-level-number-position:left;  text-indent:-.25in;}  @list l2  {mso-list-id:2125418187;  mso-list-type:hybrid;  mso-list-template-ids:277931596 67698703 67698713 67698715 67698703 67698713 67698715 67698703 67698713 67698715;}  @list l2:level1  {mso-level-tab-stop:.5in;  mso-level-number-position:left;  text-indent:-.25in;}  ol  {margin-bottom:0in;}  ul  {margin-bottom:0in;}  -->  </p>  <p class='MsoNormal'>  <span style='font-size: 10pt; font-family: Arial'></span>  </p>  <p class='MsoNormal'>  <span style='font-size: 10pt; font-family: Arial'>The browser of the future, a browser 2.0, must be in sync with the current usage of the Internet. The Web 2.0 or the semantic Web is now a place where interactivity and collaboration are the catch words. Web solutions no longer provide static content and dull detailed info to be browsed. Now Web solutions have become the epitome of</span>   </p>  <p class='MsoNormal'>  <span style='font-size: 10pt; font-family: Arial'>interactivity - Flickr : upload download / view share publish photos ; YouTube : videos publish share view ; BlogSpot : publish ideas Forums to discuss technology and etc ... So if at all we have a new browser it must have the following features (that’s how I imagine it)</span>   </p>  <p class='MsoNormal'>     </p>  <ol style='margin-top: 0in'>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>An area must be rendered by the browser given a clump of xml tags and attributes</span></li>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>If and when the user drags a file onto the area, it must be uploaded to the server and the progress also must be shown.</span></li>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>This will allow us to , say , go to Flickr and select some photos in the explorer, and drag-drop them into the area, which will send them to Flickr or You Tube.</span></li>  </ol>  <p class='MsoNormal'>  <span style='font-size: 10pt; font-family: Arial'></span>  </p>  <p class='MsoNormal'>  <span style='font-size: 10pt; font-family: Arial'></span>  </p>  <ol style='margin-top: 0in'>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>Now a rich text editor is created by downloading a lot of JavaScript and Html/CSS</span></li>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>These form an area where we can type info. when we click on the bold button, JavaScript code finds out what portion of the text is selected and dynamically enclose them with <b> and </b> tags so that they become bold</span></li>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>What i propose is: why not incorporate a client side word processor into the browser? Say, WordPad for windows, emacs for Linux etc... Why download a lot of JavaScript to force the browser to do word-processing (something the browser is not made/designed to do ) JavaScript isn't a language suitable for word processing, its difficult to do lexical analysis or NFA or DFA. Best thing JavaScript can do is execute Regular Expressions which is at best difficult to code and debug coz of the weak typing characteristic of JavaScript. Spell check is available only in precious few editors. And editors have a lot of issues in the various browsers in the market today</span></li>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>This can also be realized by a custom browser with a clump of XML.</span></li>  </ol>  <p class='MsoNormal'>  <span style='font-size: 10pt; font-family: Arial'></span>  </p>  <p class='MsoNormal'>  <span style='font-size: 10pt; font-family: Arial'></span>  </p>  <p class='MsoNormal'>  <span style='font-size: 10pt; font-family: Arial'></span>  </p>  <ol style='margin-top: 0in'>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>Each installation of the browser must be able to contact the organization that made the browser.</span></li>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>The organization must provide a web service, that connects to all clients and collects info that enhances customer experience.</span></li>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>Also combined central burner for RSS/Atom feeds and server of storage space would attract more people to span the internet more thoroughly.</span></li>   <li class='MsoNormal'><span style='font-size: 10pt; font-family: Arial'>The browser must also have modules that integrate with the default client side WordProcessing software.(No Windows version comes without WordPad, No Linux Distro comes sans EMACS All Macs have TextEdit builtin) If in the ultimate worst case of no client editor being present, we can fall back to web based editors. </span></li>  </ol>  <p>     </p>  <p>   P. S. Look out for the next set of features in the future browser in Part II   </p>  <em>'And I can't help but wonder where I'm bound, where I'm bound.'</em> (Tom Paxton)   "
                          };
        }

        [Fact]
        public void TestGetDescriptionGetsOnlyTextForThresholdLimit()
        {
            var result = postOne.GetDescription(100);
            // Last 3 characters will be dots
            Assert.Equal(103, result.Length);
            Assert.False(result.Contains("<"));
            Assert.False(result.Contains(">"));
        }

        [Fact]
        public void TestGetDescriptionWorksForComplexStringsWithCSSComments()
        {
            var result = postTwo.GetDescription(80);
            // Last 3 characters will be dots
            Assert.Equal(83, result.Length);
            Assert.False(result.Contains("<"));
            Assert.False(result.Contains(">"));
            Assert.True(result.StartsWith("The browser of the future"));
        }

        [Fact]
        public void TestGetDescriptionPutsNoDotsForShortPosts()
        {
            postTwo.Content = "<p>Short<b>Content</b></p>";
            var result = postTwo.GetDescription(80);
            // Last 3 characters will be dots
            Assert.Equal(12, result.Length);
            Assert.False(result.Contains("<"));
            Assert.False(result.Contains(">"));
            Assert.True(result.Equals("ShortContent"));
        }
    }
}