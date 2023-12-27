using Godot;
using StateOfClone.GameMap;
using System;

public partial class HexMesh : MeshInstance3D
{
    private HexMeshGenerator hexMeshGenerator;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        hexMeshGenerator = new();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
