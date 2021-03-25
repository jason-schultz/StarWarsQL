import { MongoClient } from 'mongodb';

const DbMain = async () => {
  const uri = '';
  const client = new MongoClient(uri);

  try {
    await client.connect();

    await listDatabases(client);
  } catch (e) {
    console.error(e);
  } finally {
    await client.close();
  }
};

const listDatabases = async (client: MongoClient) => {
  const databaseList = await client.db().admin().listDatabases();

  console.log('Databases');
  databaseList.databases.foreach((db: any) => console.log(`- ${db.name}`));
};

export default DbMain;
