﻿namespace RoutesTaskSpace;

/// <summary>
/// Class that represents an edge in a non-oriented graph. 
/// </summary>
public class Edge
{
    /// <summary>
    /// Beginning vertex.
    /// </summary>
    public int Beginning { get; }
    
    /// <summary>
    /// End vertex.
    /// </summary>
    public int End { get; }

    /// <summary>
    /// A label that carries certain information
    /// about an edge (lenght in this case).
    /// </summary>
    public int Length { get; }

    internal Edge(int beginning, int end, int length)
    {
        this.Beginning = beginning;
        this.End = end;
        this.Length = length;
    }

    /// <summary>
    /// Overriden ToString method used to represent an edge for a task.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
        => $"{this.End} ({this.Length})";
}
