﻿using System.Collections.Generic;
using Caliburn.Micro;
using Marvin.Container;

namespace Marvin.Products.UI.Interaction
{
    /// <summary>
    /// Factory for ImportProductsViewModel view model
    /// </summary>
    [PluginFactory]
    internal interface IProductDialogFactory
    {
        /// <summary>
        /// Create ImportViewModel instance
        /// </summary>
        IImportViewModel CreateImportDialog();

        /// <summary>
        /// Create a dialog to remove a product
        /// </summary>
        IRemoveProductViewModel CreateRemoveProductViewModel(StructureEntryViewModel productToRemove);

        /// <summary>
        /// Creates a dialog to show revisions
        /// </summary>
        IRevisionsViewModel CreateShowRevisionsDialog(string identifier);

        /// <summary>
        /// Create CreateReviosionViewModel instance
        /// </summary>
        ICreateRevisionViewModel CreateCreateRevisionDialog(StructureEntryViewModel structureEntry);

        /// <summary>
        /// Destroy DiagramInfoViewModel instance
        /// </summary>
        void Destroy(IScreen instance);
    }
}
