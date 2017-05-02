using OrientationApi.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrientationApi.Models;
using System.Data;
using Dapper;

namespace OrientationApi.DAL
{
    public class LineItemRepository : ILineItemRepository
    {
        readonly IDbConnection _dbConnection;

        public LineItemRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void AddLineItem(LineItem newLineItem)
        {
            var sql = @"Insert into LineItem(ProductId, CartOrderId)
                        Values(@productId, @cartOrderId)";

            _dbConnection.Execute(sql, newLineItem);
        }

        public IEnumerable<LineItem> GetAllLineItems()
        {
            var sql = @"Select ProductId, CartOrderId from LineItem";

            return _dbConnection.Query<LineItem>(sql).ToList();
        }

        public LineItem RetrieveLineItem(int lineItemId)
        {
            var sql = @"Select ProductId, CartOrderId from LineItem 
                        Where LineItemId = @lineItemId";

            //_dbConnection.Execute(sql, itemId);

            return _dbConnection.QuerySingle<LineItem>(sql, new { LineItemId = lineItemId});
        }

        public void RemoveLineItem(int lineItemId)
        {
            var sql = @"Delete from LineItem 
                        Where LineItemId = @lineItemId";

            _dbConnection.Execute(sql, new { LineItemId = lineItemId});
        }

        public void EditLineItem(LineItem updatedItem)
        {
            var sql = @"Update LineItem
                        Set CartOrderId = @cartOrderId,
                            ProductId = @productId
                        Where LineItemId = @lineItemId";

            _dbConnection.Execute(sql, updatedItem);
        }

    }
}