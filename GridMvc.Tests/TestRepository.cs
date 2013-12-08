﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GridMvc.Tests
{
    internal class TestRepository
    {
        public IQueryable<TestModel> GetAll()
        {
            return GetTestData().AsQueryable();
        }

        private IEnumerable<TestModel> GetTestData()
        {
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "A1",
                        Created = new DateTime(2012, 2, 3),
                        Child = new TestModelChild {ChildTitle = "B1", ChildCreated = new DateTime(1994, 3, 16),}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "C3",
                        Created = new DateTime(1998, 1, 1),
                        Child = new TestModelChild {ChildTitle = "C3", ChildCreated = new DateTime(1998, 1, 1),}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "D3",
                        Created = new DateTime(2009, 3, 15),
                        Child = new TestModelChild {ChildTitle = "D3", ChildCreated = new DateTime(2011, 2, 7),}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "B2",
                        Created = new DateTime(2003, 1, 3),
                        Child = new TestModelChild {ChildTitle = "B2", ChildCreated = new DateTime(1991, 6, 9),}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "D2",
                        Created = new DateTime(2009, 3, 16),
                        Child = new TestModelChild {ChildTitle = "D2", ChildCreated = new DateTime(1994, 3, 16)}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "D1",
                        Created = new DateTime(2010, 9, 15),
                        Child = new TestModelChild {ChildTitle = "D1", ChildCreated = new DateTime(1995, 9, 15)}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "C2",
                        Created = new DateTime(2007, 8, 4),
                        Child = new TestModelChild {ChildTitle = "C2", ChildCreated = new DateTime(2007, 8, 4),}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "E1",
                        Created = new DateTime(2012, 4, 11),
                        Child = new TestModelChild {ChildTitle = "E1", ChildCreated = new DateTime(1990, 2, 4)}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "E3",
                        Created = new DateTime(1993, 2, 21),
                        Child = new TestModelChild {ChildTitle = "E3", ChildCreated = new DateTime(1993, 2, 21)}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "B1",
                        Created = new DateTime(1997, 2, 26),
                        Child = new TestModelChild {ChildTitle = "A1", ChildCreated = new DateTime(1997, 2, 26)}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "E2",
                        Created = new DateTime(2002, 6, 17),
                        Child = new TestModelChild {ChildTitle = "E2", ChildCreated = new DateTime(2002, 6, 17)}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "C1",
                        Created = new DateTime(2002, 5, 1),
                        Child = new TestModelChild {ChildTitle = "C1", ChildCreated = new DateTime(2002, 5, 1)}
                    };
            yield return
                new TestModel
                    {
                        Id = 1,
                        Title = "B3",
                        Created = new DateTime(2002, 2, 5),
                        Child = new TestModelChild {ChildTitle = "B3", ChildCreated = new DateTime(2002, 5, 1)}
                    };
        }
    }
}