﻿using System;

namespace MarcelloDB.Storage.StreamActors
{
    internal class JournalledReader<T> : Reader<T>
    {
        internal JournalledReader(Marcello session, string collectionName) 
            : base(session, collectionName) 
        {
        }

        internal override byte[] Read (long address, int length)
        {
            var readBytes = base.Read (address, length);
            Session.Journal.ApplyToData (typeof(T), address, readBytes);
            return readBytes;
        }
    }
}

