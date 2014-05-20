using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.Common.Clr.Linq.Hierarchy
{
    // Stefan Cruysberghs, http://www.scip.be, March 2008

    public static class LinqExtensionMethods
    {
        private static IEnumerable<HierarchyNode<TEntity>> CreateHierarchy<TEntity, TProperty>(IEnumerable<TEntity> allItems, TEntity parentItem, Func<TEntity, TProperty> idProperty, Func<TEntity, TProperty> parentIdProperty, int depth)
            where TEntity : class
        {
            TProperty parentItemId = default(TProperty);
            if (parentItem != null)
                parentItemId = idProperty(parentItem);

            IEnumerable<TEntity> children = allItems.Where(i => parentIdProperty(i).Equals(parentItemId));

            if (!children.Any()) 
                yield break;
            
            depth++;
            foreach (var item in children)
            {
                HierarchyNode<TEntity> hierarchyNode = new HierarchyNode<TEntity>();
                hierarchyNode.Entity = item;
                hierarchyNode.ChildNodes = CreateHierarchy(allItems, item, idProperty, parentIdProperty, depth);
                hierarchyNode.Depth = depth;

                yield return hierarchyNode;
            }
        }

        /// <summary>
        /// LINQ IEnumerable AsHierachy() extension method
        /// </summary>
        /// <typeparam name="TEntity">Entity class</typeparam>
        /// <typeparam name="TProperty">Property of entity class</typeparam>
        /// <param name="allItems">Flat collection of entities</param>
        /// <param name="idProperty">Reference to Id/Key of entity</param>
        /// <param name="parentIdProperty">Reference to parent Id/Key</param>
        /// <returns>Hierarchical structure of entities</returns>
        public static IEnumerable<HierarchyNode<TEntity>> AsHierarchy<TEntity, TProperty>(this IEnumerable<TEntity> allItems, Func<TEntity, TProperty> idProperty, Func<TEntity, TProperty> parentIdProperty)
            where TEntity : class
        {
            return CreateHierarchy(allItems, default(TEntity), idProperty, parentIdProperty, 0);
        }
    }
}