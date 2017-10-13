using System;
using Xamarin.Forms;

namespace BelzonaMobile.Views
{
public class LocalHtml : ContentPage
{
    public LocalHtml ()
    {
        var browser = new WebView();

        var htmlSource = new HtmlWebViewSource ();

        htmlSource.Html = @"<html><body>
<h2>Belzona 1111 (Super Metal)</h2>
<p>Welcome to WebView.</p>
<p>A 2-part&nbsp;repair composite for metal repair and resurfacing based on solvent-free epoxy resin reinforced with silicon steel alloy. This repair material will not corrode and resists a wide range of chemicals. 
It is easy to mix and apply without the need of specialist tools and can be machined using conventional tools.&nbsp;</p><h4>Key benefits:</h4><ul><li>Multi-purpose durable repair composite</li>
li>Fully machinable using conventional tools</li><li>Application and cure at room temperature - no hot work involved</li><li>Simple mixing ratio</li><li>Reduced health and safety risks as it is solvent-free</li>
<li>No shrinkage, expansion or distortion</li><li>Excellent adhesion to metals including stainless steel, carbon steel, aluminium, brass and copper</li><li>Will adhere to many other natural and synthetic materials including glass and wood&nbsp;</li>
<li>Outstanding corrosion resistance</li><li>Excellent chemical resistance against a wide range of chemicals</li><li>Excellent electrical insulation characteristics</li></ul>
<h4>Applications for Belzona 1111 (Super Metal) include:</h4><ul><li>Repair of cracks and holes on engine and pump casings, pipes, tanks and other equipment</li>
<li>Resurface of pitted metal surfaces</li><li>Repair of damaged shafts and hydraulic rams</li><li>In-situ flange repair</li><li>High strength structural adhesive for metal bonding</li>
<li>Creation of irregular load bearing shims and reforming of bearing housings</li></ul><p>Belzona 1111 (Super Metal)&nbsp;is suitable for contact with potable water as it is certified to&nbsp;
<a href='http://info.nsf.org/Certified/PwsComponents/Listings.asp?Company=05720&amp;Standard=061' target='_blank'>NSF/ANSI Standard 61</a>&nbsp;and satisfies the UK Drinking Water Inspectorate requirements.&nbsp;</p>
<table class='product_table'><tbody><tr><th colspan='2'>Key technical data:</th></tr><tr><td>Working life at 25&deg;C (77&deg;F)</td><td>15 minutes</td></tr><tr><td>Time to immersion service at 25&deg;C (77&deg;F)</td>
<td>20 hours</td></tr><tr><td>Pull off adhesion (D4541 / ISO 4624)</td><td>3,240 psi (22.33MPa) ambient cure on blasted mild steel</td></tr><tr><td>Compressive strength (ASTM D695)</td><td>12,900 psi (88.9MPa) ambient cure</td>
</tr><tr><td>Temperature resistance</td><td>93&deg;C (200&deg;F) immersed, 200&deg;C (392&deg;F) dry</td></tr><tr><td>Bonds to</td><td>Aluminium, copper, steel, stainless steel, cast iron, lead, glass, wood and many more</td>
</tr><tr><td>Typical applications</td><td>Bonding, shimming, filling, gluing, patch repairs and many more</td></tr><tr><td>Unit size</td><td>1kg, 2kg, 5kg. Pack sizes may vary locally</td></tr><tr><td>Availability*</td>
<td>Global</td></tr></tbody></table><p>* All products are subject to regional restrictions. Check with your local Distributor for more information</p><hr /><table class='product_table'><tbody><tr><th colspan='2'>Approvals:</th></tr>
<tr><td><h4>ABS&nbsp;Approval</h4></td><td><img alt='ABS' src='http://www.belzona.com/assets/data/images/approvals/ABS.jpg' style='border-style:solid; border-width:0px; height:92px; width:92px' /></td></tr><tr><td>
<h4>NSF/ANSI 61</h4></td><td><img alt='NSF-ANS-61' src='http://www.belzona.com/assets/data/images/approvals/NSF-ANS-61.jpg' style='border-style:solid; border-width:0px; height:124px; width:92px\' /></td></tr>
<tr><td><h4>Bureau Veritas Type Approval</h4></td><td><img alt='Bureau Veritas logo' src='http://www.belzona.com/assets/data/images/approvals/bureau-veritas.jpg'style='border-style:solid; border-width:0px; height:100px; width:92px' /></td></tr>
<tr><td><h4>WRAS Approved Material</h4></td><td><img alt='Bureau Veritas logo\' src='http://www.belzona.com/assets/data/images/approvals/WRAS-logo.jpg' style='border-style:solid; border-width:0px; height:55px; width:152px' /></td>
</tr><tr><td><h4>Germanischer Lloyd Approval</h4></td><td><img alt='Germanischer Lloyd logo' src='http://www.belzona.com/assets/data/images/approvals/Germanischer-Lloyd.jpg' 
style='border-style:solid; border-width:0px; height:65px; width:92px' /></td></tr><tr><td><h4>China Classification Society</h4></td><td><img alt='CSS logo' 
src='http://www.belzona.com/assets/data/images/approvals/CSS-logo.jpg' style='border-style:solid; border-width:0px; height:117px; width:90px' /></td></tr></tbody></table>
</body>
</html>";
        
        
        browser.Source = htmlSource;

        Content = browser;
    }
}
}

