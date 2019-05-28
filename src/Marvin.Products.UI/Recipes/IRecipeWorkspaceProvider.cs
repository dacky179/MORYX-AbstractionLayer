﻿namespace Marvin.Products.UI.Recipes
{
    /// <summary>
    /// Recipe editor facade
    /// </summary>
    public interface IRecipeWorkspaceProvider
    {
        /// <summary>
        /// Creates a workspace to load the given recipes
        /// </summary>
        /// <param name="title">Title of the recipe editor</param>
        /// <param name="recipeIds">List of recipes that can be edited</param>
        /// <returns>An instance that implements <see cref="IRecipeWorkspace"/></returns>
        IRecipeWorkspace CreateWorkspace(string title, params long[] recipeIds);

        /// <summary>
        /// Creates a workspace to load the given product.
        /// </summary>
        /// <param name="title">Title of the recipe editor</param>
        /// <param name="productId">Product to be used</param>
        /// <returns>An instance that implements <see cref="IRecipeWorkspace"/></returns>
        IRecipeWorkspace CreateWorkspace(string title, long productId);
    }
}
