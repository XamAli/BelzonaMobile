using System;
using SQLite;

namespace BelzonaMobile
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

