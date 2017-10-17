using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelzonaMobile
{
    public interface IRestService
	{
        Task<List<BelProduct>> RefreshDataAsync ();

		//Task SaveTodoItemAsync (TodoItem item, bool isNewItem);

		//Task DeleteTodoItemAsync (string id);
	}
}
