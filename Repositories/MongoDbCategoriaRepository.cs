using System;
using System.Collections.Generic;
using home_finance_categories.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace home_finance_categories.Repositories
{
    public class MongoDbCategoriaRepository : ICategoriaRepository
    {
        private const string databaseName = "categoria";
        private const string collectionName = "categorias";

        private readonly IMongoCollection<Categoria> categoriaCollection;
        private readonly FilterDefinitionBuilder<Categoria> filterBuilder = Builders<Categoria>.Filter;

        public MongoDbCategoriaRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            categoriaCollection = database.GetCollection<Categoria>(collectionName);
        }

        public void CreateCategoria(Categoria categoria)
        {
            categoriaCollection.InsertOne(categoria);
        }

        public void DeleteCategoria(Guid id)
        {
            var filter = filterBuilder.Eq(categoria => categoria.Id, id);
            categoriaCollection.DeleteOne(filter);
        }

        public Categoria GetCategoria(Guid id)
        {
            var filter = filterBuilder.Eq(categoria => categoria.Id, id);
            return categoriaCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return categoriaCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateCategoria(Categoria categoria)
        {
            var filter = filterBuilder.Eq(existingCategoria => existingCategoria.Id, categoria.Id);
            categoriaCollection.ReplaceOne(filter, categoria);
        }
    }
}