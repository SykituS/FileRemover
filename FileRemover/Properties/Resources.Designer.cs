﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileRemover.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FileRemover.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Usuwanie plików.
        /// </summary>
        internal static string fileremoval_information_processing {
            get {
                return ResourceManager.GetString("fileremoval.information.processing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Szukanie plików w podanej lokalizacji: {0}.
        /// </summary>
        internal static string label_info_files_searching {
            get {
                return ResourceManager.GetString("label.info.files.searching", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Znaleziono {0} plików do usunięcia.
        /// </summary>
        internal static string label_info_foundedfiles {
            get {
                return ResourceManager.GetString("label.info.foundedfiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Application version: {0}.
        /// </summary>
        internal static string label_version {
            get {
                return ResourceManager.GetString("label.version", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ustaw lokalizację folderu.
        /// </summary>
        internal static string messagebox_content_filepath_error {
            get {
                return ResourceManager.GetString("messagebox.content.filepath.error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nie znaleziono plików w podanej lokalizacji.
        /// </summary>
        internal static string messagebox_content_files_error {
            get {
                return ResourceManager.GetString("messagebox.content.files.error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Podczas wyszukiwania plików wystąpił nieoczekiwany problem! Upewnij się że podana ścieżka istnieje.
        /// </summary>
        internal static string messagebox_content_files_notfound {
            get {
                return ResourceManager.GetString("messagebox.content.files.notfound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Natpotkany problem w trakcie wydobrywania plików.
        /// </summary>
        internal static string messagebox_content_files_unexpectederror {
            get {
                return ResourceManager.GetString("messagebox.content.files.unexpectederror", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data startowa nie może być większa niż data końcowa.
        /// </summary>
        internal static string messagebox_content_startdate_error {
            get {
                return ResourceManager.GetString("messagebox.content.startdate.error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Startowa godzina nie może być większa niż końcowa godzina.
        /// </summary>
        internal static string messagebox_content_starttime_error {
            get {
                return ResourceManager.GetString("messagebox.content.starttime.error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uwaga!.
        /// </summary>
        internal static string messagebox_title_warning {
            get {
                return ResourceManager.GetString("messagebox.title.warning", resourceCulture);
            }
        }
    }
}
