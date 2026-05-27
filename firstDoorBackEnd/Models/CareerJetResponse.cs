namespace firstDoorBackEnd.Models
{
    public record CareerJetResponse(string Type, int Hits, int Pages, List<Job> Jobs)
    {}
}
