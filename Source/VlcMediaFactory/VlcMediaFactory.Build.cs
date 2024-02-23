// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class VlcMediaFactory : ModuleRules
{
	public VlcMediaFactory( ReadOnlyTargetRules target ) : base( target )
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
				"MediaAssets",
			} );

		PrivateIncludePathModuleNames.AddRange(
			new[]
			{
				"Media",
				"VlcMedia",
			} );

		PrivateIncludePaths.AddRange(
			new[]
			{
				"VlcMediaFactory/Private",
			} );

		PublicDependencyModuleNames.AddRange(
			new[]
			{
				"Core",
				"CoreUObject",
			} );

		if ( target.Type == TargetRules.TargetType.Editor )
		{
			DynamicallyLoadedModuleNames.Add( "Settings" );
			PrivateIncludePathModuleNames.Add( "Settings" );
		}

		if ( target.Platform == UnrealTargetPlatform.Mac ||
		     target.Platform == UnrealTargetPlatform.Linux ||
		     target.Platform == UnrealTargetPlatform.Win64 )
		{
			DynamicallyLoadedModuleNames.Add( "VlcMedia" );
		}
	}
}
