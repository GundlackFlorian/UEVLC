// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class VlcMediaEditor : ModuleRules
{
	public VlcMediaEditor( ReadOnlyTargetRules target ) : base( target )
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PrivateDependencyModuleNames.AddRange(
			new[]
			{
				"Core",
				"CoreUObject",
				"MediaAssets",
				"UnrealEd",
			} );

		PrivateIncludePaths.AddRange(
			new[]
			{
				"VlcMediaEditor/Private",
			} );
	}
}
