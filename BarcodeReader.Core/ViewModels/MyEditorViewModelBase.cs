using BarcodeReader.Core.ModelServices.Infrastructure;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using System.Collections.Generic;

namespace BarcodeReader.Core.ViewModels
{
     public abstract class MyEditorViewModelBase<TEntity, TRepository> : EditorViewModelBase<TEntity>
     where TEntity : class, new()
     where TRepository : IRepository<TEntity>, new()
    {
        //tesss
        #region Fields

        private IRepository<TEntity> _repository;

        #endregion

        #region Properties

        public IRepository<TEntity> Repository
        {
            get
            {
                if (_repository == null)
                    _repository = new TRepository();

                return _repository;
            }
        }

        #endregion

        #region Methods
        
        #endregion
    }
}
