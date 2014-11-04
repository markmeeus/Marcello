﻿using System;
using Marcello.AllocationStrategies;
using Marcello.Collections;
using Marcello.Serialization;
using Marcello.Transactions;

namespace Marcello
{
    public class Marcello
    {
        internal IStorageStreamProvider StreamProvider { get; set; }

        internal Transaction CurrentTransaction { get; set; }

        public Marcello (IStorageStreamProvider streamProvider)
        {
            StreamProvider = streamProvider;
        }

        public Collection<T> GetCollection<T>()
        {
            return new Collection<T>(this, 
                new BsonSerializer<T>(), 
                new DoubleSizeAllocationStrategy());
        }

        public void Transaction(Action action)
        {
            EnsureTransaction();
            try
            {
                CurrentTransaction.Enlist();
                action();
                CurrentTransaction.Leave();
            }
            catch(Exception exc)
            {
                CurrentTransaction.Rollback();
                throw exc;
            }
            finally 
            {
                if (!CurrentTransaction.Running) 
                {
                    CurrentTransaction = null;
                }
            }
        }

        #region private methods
        void EnsureTransaction()
        {
            if (CurrentTransaction == null) 
            {
                CurrentTransaction = new Transaction();
            }
        }
        #endregion
    }
}

