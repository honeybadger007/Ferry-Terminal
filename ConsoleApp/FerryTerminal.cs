using System.Collections.Generic;

public class FerryTerminal
{   

    public int Id { get; private set; }

    public List<int> DocksId { get; set; }

    public List<int> DocumentsIds { get; set; }

    public FerryTerminal(int id)
    {
        Id = id;
        // To avoid checking if it is null when the class is consumed
        DocksId = new List<int>();
        DocumentsIds = new List<int>();
    }



}