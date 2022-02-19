using Altairis.Fakturoid.Client;

namespace Luxuryphile.Fakturoid
{
  /// <summary>Proxy class for working with subjects/contacts.</summary>
  public class FakturoidSubjectsProxy : FakturoidEntityProxy
  {
    internal FakturoidSubjectsProxy(FakturoidContext context)
      : base(context)
    {
    }

    /// <summary>Gets list of all subjects matching query.</summary>
    /// <param name="query">The query used to search subject.</param>
    /// <returns>
    /// List of <see cref="T:Altairis.Fakturoid.Client.JsonSubject" /> instances.
    /// </returns>
    public IEnumerable<JsonSubject> Select(string? query = null)
    {
      return GetAllPagedEntities<JsonSubject>("subjects/search.json", new
      {
        query
      });
    }

    /// <summary>Gets list of all subjects matching query.</summary>
    /// <param name="query">The query used to search subject.</param>
    /// <returns>
    /// List of <see cref="T:Altairis.Fakturoid.Client.JsonSubject" /> instances.
    /// </returns>
    public async Task<IEnumerable<JsonSubject>> SelectAsync(
      string? query = null)
    {
      var pagedEntitiesAsync = await this.GetAllPagedEntitiesAsync<JsonSubject>(
        "subjects/search.json", (object) new
        {
          query = query
        });
      return pagedEntitiesAsync;
    }
  }
}
