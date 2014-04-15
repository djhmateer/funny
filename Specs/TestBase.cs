﻿using Funny.DB;
using System;

namespace Specs {
    public class TestBase : IDisposable {
        public TestBase(){
            new Session().Database.ExecuteSqlCommand("DELETE FROM Votes");
            new Session().Database.ExecuteSqlCommand("DELETE FROM Stories");
        }

        public void Dispose(){
            new Session().Database.ExecuteSqlCommand("DELETE FROM Votes");
            new Session().Database.ExecuteSqlCommand("DELETE FROM Stories");
        }
    }
}
