﻿using System;
using System.Globalization;
using Marvin.AbstractionLayer;
using Marvin.Container;
using Marvin.Model;
using Marvin.Products.Management;
using Marvin.Products.Model;
using Marvin.Tools;

namespace Marvin.Products.Samples
{
    [StrategyConfiguration(typeof(WatchType), DerivedTypes = false)]
    [Plugin(LifeCycle.Transient, typeof(IProductTypeStrategy), Name = nameof(WatchStrategy))]
    public class WatchStrategy : TypeStrategyBase
    {
        /// <inheritdoc />
        public override bool HasChanged(IProductType current, IGenericColumns dbProperties)
        {
            var watch = (WatchType) current;
            return Math.Abs(watch.Weight - dbProperties.Float1) > 0.01 
                || Math.Abs(watch.Price - dbProperties.Float2) > 0.01;
        }

        /// <inheritdoc />
        public override void SaveType(IProductType source, IGenericColumns target)
        {
            var watch = (WatchType)source;
            target.Float1 = watch.Weight;
            target.Float2 = watch.Price;
        }

        /// <inheritdoc />
        public override void LoadType(IGenericColumns source, IProductType target)
        {
            var watch = (WatchType)target;
            watch.Weight = source.Float1;
            watch.Price = source.Float2;
        }
    }

    [StrategyConfiguration(typeof(WatchInstance), DerivedTypes = false)]
    [Plugin(LifeCycle.Transient, typeof(IProductInstanceStrategy), Name = nameof(WatchInstanceStrategy))]
    public class WatchInstanceStrategy : InstanceStrategyBase
    {
        /// <inheritdoc />
        public override void SaveInstance(ProductInstance source, IGenericColumns target)
        {
            var watch = (WatchInstance) source;
            target.Integer1 = watch.TimeSet ? 1 : 0;
            target.Integer2 = watch.DeliveryDate.ToBinary();
        }

        /// <inheritdoc />
        public override void LoadInstance(IGenericColumns source, ProductInstance target)
        {
            var watch = (WatchInstance) target;
            watch.TimeSet = source.Integer1 == 1;
            watch.DeliveryDate = DateTime.FromBinary(source.Integer2);
        }
    }

    [StrategyConfiguration(typeof(NeedlePartLink))]
    [Plugin(LifeCycle.Transient, typeof(IProductLinkStrategy), Name = nameof(NeedleLinkStrategy))]
    public class NeedleLinkStrategy : LinkStrategyBase
    {
        public override void LoadPartLink(IGenericColumns linkEntity, IProductPartLink target)
        {
            var link = (NeedlePartLink) target;
            link.Role = (NeedleRole) linkEntity.Integer1;
        }

        public override void SavePartLink(IProductPartLink source, IGenericColumns target)
        {
            var link = (NeedlePartLink) source;
            target.Integer1 = (int) link.Role;
        }
    }
}