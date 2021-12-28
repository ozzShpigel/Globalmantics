﻿using Globalmantics.DAL;
using Highway.Data;

namespace Globalmantics.IntegrationTests
{
    public abstract class TestContext
    {
        public IRepository Repository { get; }
        public DataContext Context { get; }

        protected TestContext()
        {
            var configuration = new GlobalmanticsMappingConfiguration();
            Context = new DataContext("GlobalmanticsContext", configuration);
            Repository = new Repository(Context);
        }
    } 
}
