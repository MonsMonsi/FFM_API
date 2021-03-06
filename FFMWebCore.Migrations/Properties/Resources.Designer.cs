//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FFMWebCore.Migrations.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FFMWebCore.Migrations.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to CREATE TABLE Users (
        ///	Id INT IDENTITY(1, 1) NOT NULL,
        ///	Identifier NVARCHAR(100) NOT NULL,
        ///	EMail NVARCHAR(100) NOT NULL,
        ///	PRIMARY KEY (Id)
        ///)
        ///GO
        ///
        ///CREATE TABLE Seasons (
        ///	Id INT IDENTITY(1, 1) NOT NULL,
        ///	Name NVARCHAR(50) NOT NULL,
        ///	PRIMARY KEY(Id)
        ///)
        ///
        ///CREATE TABLE UserTeams (
        ///	Id INT IDENTITY(1, 1) NOT NULL,
        ///	Name NVARCHAR(50) NOT NULL,
        ///	UserId INT NOT NULL,
        ///	SeasonId INT NOT NULL,
        ///	PRIMARY KEY (Id),
        ///	CONSTRAINT FK_UserTeams_UserId FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCAD [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _001_up {
            get {
                return ResourceManager.GetString("_001_up", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Players (
        ///	Id INT NOT NULL,
        ///	FirstName NVARCHAR(50) NOT NULL,
        ///	LastName NVARCHAR(50) NOT NULL,
        ///	BirthDate NVARCHAR(20) NOT NULL,
        ///	BirthCountry NVARCHAR(50) NOT NULL,
        ///	BirthPlace NVARCHAR(50) NOT NULL,
        ///	Nationality NVARCHAR(50) NOT NULL,
        ///	Height NVARCHAR(10) NOT NULL,
        ///	Weight NVARCHAR(10) NOT NULL,
        ///	Position NVARCHAR(50) NOT NULL,
        ///	Photo NVARCHAR(100) NOT NULL,
        ///	
        ///	TeamId INT NOT NULL,
        ///	PRIMARY KEY (Id)
        ///)
        ///GO
        ///
        ///CREATE TABLE UserTeamSquads (
        ///	Id INT IDENTITY (1, 1) NOT NULL,
        ///	Use [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _002_up {
            get {
                return ResourceManager.GetString("_002_up", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Leagues (
        ///	Id INT NOT NULL,
        ///	Name NVARCHAR(50) NOT NULL,
        ///	Country NVARCHAR(25) NOT NULL,
        ///	Logo NVARCHAR(100) NOT NULL,
        ///	Flag NVARCHAR(100) NOT NULL,
        ///	PRIMARY KEY (Id),
        ///);
        ///GO
        ///
        ///CREATE TABLE Teams (
        ///	Id INT NOT NULL,
        ///	Name NVARCHAR(50) NOT NULL,
        ///	Logo NVARCHAR(100) NOT NULL,
        ///	LeagueId INT NOT NULL
        ///	PRIMARY KEY (Id),
        ///	CONSTRAINT FK_Teams_LeagueId FOREIGN KEY (LeagueId) REFERENCES Leagues(Id) ON DELETE CASCADE,
        ///);.
        /// </summary>
        internal static string _003_up {
            get {
                return ResourceManager.GetString("_003_up", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALTER TABLE Players
        ///ADD FOREIGN KEY (TeamId) REFERENCES Teams(Id) ON DELETE CASCADE;.
        /// </summary>
        internal static string _004_up {
            get {
                return ResourceManager.GetString("_004_up", resourceCulture);
            }
        }
    }
}
