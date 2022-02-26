﻿using Sandbox;
using System;
using System.Linq;

partial class PlayerBase
{
	public void SpawnAsGhost()
	{
		CurrentTeam = TeamEnum.Spectator;
		SetModel( "models/player/ghost/ghost.vmdl" );

		Controller = new GhostController();
		CameraMode = new FirstPersonCamera();

		EnableAllCollisions = false;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		var spawnpoints = Entity.All.OfType<PigmaskSpawn>();
		var randomSpawnPoint = spawnpoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		if ( randomSpawnPoint == null )
		{
			Log.Error( "THIS MAP ISN'T SUPPORTED FOR ULTIMATE CHIMERA HUNT" );
			return;
		}

		Position = randomSpawnPoint.Position;
	}

	public void SpawnAsGhostAtLocation(Vector3 location)
	{
		Position = location;

		SpawnAsGhost();
	}
}
