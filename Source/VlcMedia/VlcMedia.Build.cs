// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class VlcMedia : ModuleRules
{
	public VlcMedia( ReadOnlyTargetRules target ) : base( target )
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		DynamicallyLoadedModuleNames.AddRange(
			new[]
			{
				"Media",
			} );

		PrivateDependencyModuleNames.AddRange(
			new[]
			{
				"Core",
				"CoreUObject",
				"MediaUtils",
				"Projects",
				"RenderCore",
				"VlcMediaFactory",
			} );

		PrivateIncludePathModuleNames.AddRange(
			new[]
			{
				"Media",
			} );

		PrivateIncludePaths.AddRange(
			new[]
			{
				"VlcMedia/Private",
				"VlcMedia/Private/Player",
				"VlcMedia/Private/Shared",
				"VlcMedia/Private/Vlc",
			} );

		// add VLC libraries
		var baseDirectory = Path.GetFullPath( Path.Combine( ModuleDirectory, "..", ".." ) );
		var vlcDirectory = Path.Combine( baseDirectory, "ThirdParty", "vlc", target.Platform.ToString() );

		if ( target.Platform == UnrealTargetPlatform.Linux )
		{
			vlcDirectory = Path.Combine( vlcDirectory, target.Architecture.ToString(), "lib" );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlc.so" ) );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlc.so.5" ) );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlc.so.5.6.0" ) );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlccore.so" ) );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlccore.so.9" ) );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlccore.so.9.0.0" ) );
		}
		else if ( target.Platform == UnrealTargetPlatform.Mac )
		{
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlc.dylib" ) );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlc.5.dylib" ) );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlccore.dylib" ) );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlccore.9.dylib" ) );
		}

		else if ( target.Platform == UnrealTargetPlatform.Win64 )
		{
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlc.dll" ) );
			RuntimeDependencies.Add( Path.Combine( vlcDirectory, "libvlccore.dll" ) );
		}

		// add VLC plug-ins
		var pluginDirectory = Path.Combine( vlcDirectory, "plugins" );

		if ( target.Platform == UnrealTargetPlatform.Linux )
		{
			pluginDirectory = Path.Combine( vlcDirectory, "vlc", "plugins" );
		}

		if ( Directory.Exists( pluginDirectory ) )
		{
			foreach ( var plugin in Directory.EnumerateFiles( pluginDirectory, "*.*", SearchOption.AllDirectories ) )
			{
				RuntimeDependencies.Add( Path.Combine( pluginDirectory, plugin ) );
			}
		}
	}
}
