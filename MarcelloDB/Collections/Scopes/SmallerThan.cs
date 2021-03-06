﻿using System;
using System.Collections.Generic;
using MarcelloDB.Records;
using MarcelloDB.Index.BTree;
using System.Collections;

namespace MarcelloDB.Collections.Scopes
{
    public class SmallerThan<TObj, TAttribute> : BaseScope<TObj, TAttribute>
    {
        BaseIndexedValue<TObj, TAttribute> IndexedValue { get; set; }

        TAttribute Value { get; set; }

        bool OrEqual { get; set; }

        internal SmallerThan(BaseIndexedValue<TObj, TAttribute> indexedValue, TAttribute value, bool orEqual)
        {
            this.IndexedValue = indexedValue;
            this.Value = value;
            this.OrEqual = orEqual;
        }

        internal override CollectionEnumerator<TObj, ValueWithAddressIndexKey<TAttribute>> BuildEnumerator(bool descending)
        {
            var startKey = new ValueWithAddressIndexKey<TAttribute>{
                V = this.Value
            };
            var range = new BTreeWalkerRange<ValueWithAddressIndexKey<TAttribute>>();

            if (!descending)
            {
                range.SetEndAt(startKey);
                range.IncludeEndAt = this.OrEqual;
            }
            else
            {
                range.SetStartAt(startKey);
                range.IncludeStartAt = this.OrEqual;
            }

            return this.IndexedValue
                .BuildEnumerator(new BTreeWalkerRange<ValueWithAddressIndexKey<TAttribute>>[]{range}, descending);
        }
    }
}

