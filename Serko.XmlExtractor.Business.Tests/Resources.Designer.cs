﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Serko.XmlExtractor.Business.Tests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Serko.XmlExtractor.Business.Tests.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;expense&lt;cost_centre&gt;DEV002&lt;/cost_centre&gt;
        ///&lt;total&gt;1024.01&lt;/total&gt;&lt;payment_method&gt;personal card&lt;/payment_method&gt;
        ///&lt;/expense&gt;
        ///.
        /// </summary>
        internal static string InvalidXml {
            get {
                return ResourceManager.GetString("InvalidXml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hi Yvaine,
        ///Please create an expense claim for the below. Relevant details are marked up as
        ///requested...
        ///&lt;expense&gt;
        ///&lt;total&gt;1024.01&lt;/total&gt;&lt;payment_method&gt;personal card&lt;/payment_method&gt;
        ///&lt;/expense&gt;
        ///From: Ivan Castle
        ///Sent: Friday, 16 February 2018 10:32 AM
        ///To: Antoine Lloyd &lt;Antoine.Lloyd@example.com&gt;
        ///Subject: test
        ///Hi Antoine,
        ///Please create a reservation at the &lt;vendor&gt;Viaduct Steakhouse&lt;/vendor&gt; our
        ///&lt;description&gt;development team’s project end celebration dinner&lt;/description&gt; on
        ///&lt;date&gt;Tuesday 27 Apr [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TextWithMissingCostCentre {
            get {
                return ResourceManager.GetString("TextWithMissingCostCentre", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hi Yvaine,
        ///Please create an expense claim for the below. Relevant details are marked up as
        ///requested...
        ///&lt;expense&gt;&lt;cost_centre&gt;DEV002&lt;/cost_centre&gt;
        ///&lt;payment_method&gt;personal card&lt;/payment_method&gt;
        ///&lt;/expense&gt;
        ///From: Ivan Castle
        ///Sent: Friday, 16 February 2018 10:32 AM
        ///To: Antoine Lloyd &lt;Antoine.Lloyd@example.com&gt;
        ///Subject: test
        ///Hi Antoine,
        ///Please create a reservation at the &lt;vendor&gt;Viaduct Steakhouse&lt;/vendor&gt; our
        ///&lt;description&gt;development team’s project end celebration dinner&lt;/description&gt; on
        ///&lt;date&gt;Tue [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TextWithMissingTotal {
            get {
                return ResourceManager.GetString("TextWithMissingTotal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hi Yvaine,
        ///Please create an expense claim for the below. Relevant details are marked up as
        ///requested...
        ///&lt;expense&gt;&lt;cost_centre&gt;DEV002&lt;/cost_centre&gt;
        ///&lt;total&gt;1024.01&lt;/total&gt;&lt;payment_method&gt;personal card&lt;/payment_method&gt;
        ///&lt;/expense&gt;
        ///From: Ivan Castle
        ///Sent: Friday, 16 February 2018 10:32 AM
        ///To: Antoine Lloyd &lt;Antoine.Lloyd@example.com&gt;
        ///Subject: test
        ///Hi Antoine,
        ///Please create a reservation at the &lt;vendor&gt;Viaduct Steakhouse&lt;/vendor&gt; our
        ///&lt;description&gt;development team’s project end celebration dinner&lt;/desc [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TextWithValidXml {
            get {
                return ResourceManager.GetString("TextWithValidXml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;expense&gt;&lt;cost_centre&gt;DEV002&lt;/cost_centre&gt;
        ///&lt;total&gt;1024.01&lt;/total&gt;&lt;payment_method&gt;personal card&lt;/payment_method&gt;
        ///&lt;/expense&gt;
        ///.
        /// </summary>
        internal static string ValidXml {
            get {
                return ResourceManager.GetString("ValidXml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;expense&lt;cost_centre&gt;DEV002&lt;/cost_centre&gt;
        ///&lt;total&gt;1024.01&lt;/total&gt;&lt;payment_method&gt;personal card&lt;/payment_method&gt;
        ///&lt;/expense&gt;.
        /// </summary>
        internal static string XmlWithInvalidXml {
            get {
                return ResourceManager.GetString("XmlWithInvalidXml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;expense&gt;
        ///&lt;total&gt;1024.01&lt;/total&gt;&lt;payment_method&gt;personal card&lt;/payment_method&gt;
        ///&lt;/expense&gt;.
        /// </summary>
        internal static string XmlWithMissingCostCentre {
            get {
                return ResourceManager.GetString("XmlWithMissingCostCentre", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;expense&gt;&lt;cost_centre&gt;DEV002&lt;/cost_centre&gt;
        ///&lt;payment_method&gt;personal card&lt;/payment_method&gt;
        ///&lt;/expense&gt;.
        /// </summary>
        internal static string XmlWithMissingTotal {
            get {
                return ResourceManager.GetString("XmlWithMissingTotal", resourceCulture);
            }
        }
    }
}
