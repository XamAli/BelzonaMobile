using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelzonaMobile
{
	public class ProductManager
	{
		IRestService restService;

        public ProductManager (IRestService service)
		{
			restService = service;
		}

        public Task<List<BelProduct>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

		//public Task SaveTaskAsync (TodoItem item, bool isNewItem = false)
		//{
		//	return restService.SaveTodoItemAsync (item, isNewItem);
		//}

		//public Task DeleteTaskAsync (TodoItem item)
		//{
		//	return restService.DeleteTodoItemAsync (item.ID);
		//}
	}
}
