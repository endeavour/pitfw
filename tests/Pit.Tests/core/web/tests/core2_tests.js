registerNamespace("Pit.Test.JsArrayTest");
registerNamespace("Pit.Test.SetTests");
registerNamespace("Pit.Test.ObservableTests");
registerNamespace("Pit.Test.Event2Tests");
registerNamespace("Pit.Test.EventsTest");
registerNamespace("Pit.Test.ListTest");
registerNamespace("Pit.Test.SeqTest");
registerNamespace("Pit.Test.ArrayTest");
registerNamespace("Pit.Test.Array2DTest");
Pit.Test.SetTests.Create = (function() {
    return test("create", function() {
        var s = Pit.FSharp.Collections.SetModule.Empty().Add(1).Add(2);
        var c = Pit.FSharp.Collections.SetModule.Count(s);
        return equal(2, c, "Set Create");
    });
});
Pit.Test.SetTests.Add = (function() {
    return test("add", function() {
        var s = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SetModule.Empty())((function(set) {
            return Pit.FSharp.Collections.SetModule.Add(1)(set);
        })))((function(set) {
            return Pit.FSharp.Collections.SetModule.Add(2)(set);
        }));
        var c = Pit.FSharp.Collections.SetModule.Count(s);
        return equal(2, c, "Set Add");
    });
});
Pit.Test.SetTests.AddOp = (function() {
    return test("addop", function() {
        var s1 = Pit.FSharp.Collections.SetModule.OfArray([1, 2, 3]);
        var s2 = Pit.FSharp.Collections.SetModule.OfArray([4, 5]);
        var add = Pit.FSharp.Collections.FSharpSet1.op_Addition(s1, s2);
        var c = Pit.FSharp.Collections.SetModule.Count(add);
        return equal(5, c, "Set AddOp");
    });
});
Pit.Test.SetTests.Contains = (function() {
    return test("contains", function() {
        var s = Pit.FSharp.Collections.SetModule.Empty().Add(1).Add(2);
        var f = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(set) {
            return Pit.FSharp.Collections.SetModule.Contains(2)(set);
        }));
        return equal(true, f, "Set Contains");
    });
});
Pit.Test.SetTests.Exists = (function() {
    return test("exists", function() {
        var s = Pit.FSharp.Collections.SetModule.OfArray([1, 2, 3, 4, 5]);
        var f = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(set) {
            return Pit.FSharp.Collections.SetModule.Contains(3)(set);
        }));
        return equal(true, f, "Set Exists");
    });
});
Pit.Test.SetTests.Filter = (function() {
    return test("filter", function() {
        var s = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10)))))((function(set) {
            return Pit.FSharp.Collections.SetModule.Filter((function(e) {
                return (e % 2) == 0;
            }))(set);
        }));
        var c = Pit.FSharp.Collections.SetModule.Count(s);
        return equal(5, c, "Set Filter");
    });
});
Pit.Test.SetTests.Difference = (function() {
    return test("diff", function() {
        var s1 = Pit.FSharp.Collections.SetModule.OfArray([1, 2, 3]);
        var s2 = Pit.FSharp.Collections.SetModule.OfArray([3, 4, 5]);
        var diff = Pit.FSharp.Collections.SetModule.Difference(s1)(s2);
        var diffc = Pit.FSharp.Collections.SetModule.Count(diff);
        return equal(2, diffc, "Set Difference");
    });
});
Pit.Test.SetTests.DifferenceOp = (function() {
    return test("diff op", function() {
        var s1 = Pit.FSharp.Collections.SetModule.OfArray([1, 2, 3]);
        var s2 = Pit.FSharp.Collections.SetModule.OfArray([3, 4, 5]);
        var diff = Pit.FSharp.Collections.FSharpSet1.op_Subtraction(s1, s2);
        var diffc = Pit.FSharp.Collections.SetModule.Count(diff);
        return equal(2, diffc, "Set Difference");
    });
});
Pit.Test.SetTests.Fold = (function() {
    return test("fold", function() {
        var sumSet = (function(set) {
            return Pit.FSharp.Collections.SetModule.Fold(function(acc) {
                return (function(elem) {
                    return (acc + elem);
                });
            })(0)(set);
        });
        var s = Pit.FSharp.Collections.SetModule.OfArray([1, 2, 3]);
        var res = sumSet(s);
        return equal(6, res, "Set Fold");
    });
});
Pit.Test.SetTests.FoldBack = (function() {
    return test("foldback", function() {
        var subSetBack = (function(set) {
            return Pit.FSharp.Collections.SetModule.FoldBack(function(elem) {
                return (function(acc) {
                    return (elem - acc);
                });
            })(set)(0);
        });
        var s = Pit.FSharp.Collections.SetModule.OfArray([1, 2, 3]);
        var res = subSetBack(s);
        return equal(2, res, "Set Foldback");
    });
});
Pit.Test.SetTests.ForAll = (function() {
    return test("forall", function() {
        var predicate = (function(el) {
            return el >= 0;
        });
        var allPositive = (function(set) {
            return Pit.FSharp.Collections.SetModule.ForAll(predicate)(set);
        });
        var s = Pit.FSharp.Collections.SetModule.OfArray([1, 2, 3]);
        var f = allPositive(s);
        return equal(true, f, "Set ForAll");
    });
});
Pit.Test.SetTests.Intersect = (function() {
    return test("intersect", function() {
        var set1 = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(3))));
        var set2 = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(2)(6))));
        var s = Pit.FSharp.Collections.SetModule.Intersect(set1)(set2);
        var c = Pit.FSharp.Collections.SetModule.Count(s);
        return equal(2, c, "Set Intersect");
    });
});
Pit.Test.SetTests.IntersectMany = (function() {
    return test("intersect many", function() {
        var sets = [Pit.FSharp.Collections.SetModule.OfArray(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(9)))), Pit.FSharp.Collections.SetModule.OfArray(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(5)(8))))];
        var setres = Pit.FSharp.Collections.SetModule.IntersectMany(sets);
        var c = Pit.FSharp.Collections.SetModule.Count(setres);
        return equal(4, c, "Set Intersect Many");
    });
});
Pit.Test.SetTests.IsEmpty = (function() {
    return test("isempty", function() {
        var f = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SetModule.Empty())((function(set) {
            return Pit.FSharp.Collections.SetModule.IsEmpty(set);
        }));
        return equal(true, f, "Set IsEmpty");
    });
});
Pit.Test.SetTests.IsProperSubset = (function() {
    return test("ispropersubset", function() {
        var s1 = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(6))));
        var s2 = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(4))));
        var f = Pit.FSharp.Collections.SetModule.IsProperSubset(s2)(s1);
        var f2 = Pit.FSharp.Collections.SetModule.IsSubset(s2)(s1);
        equal(true, f, "Set IsProperSubset");
        return equal(true, f2, "Set IsSubset");
    });
});
Pit.Test.SetTests.IsProperSuperset = (function() {
    return test("ispropersuperset", function() {
        var s1 = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(4))));
        var s2 = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(6))));
        var f = Pit.FSharp.Collections.SetModule.IsProperSuperset(s2)(s1);
        var f2 = Pit.FSharp.Collections.SetModule.IsSuperset(s2)(s1);
        equal(true, f, "Set IsProperSuperset");
        return equal(true, f2, "Set IsSuperset");
    });
});
Pit.Test.SetTests.Iterate = (function() {
    return test("iterate", function() {
        var s = Pit.FSharp.Collections.SetModule.Empty().Add(1).Add(2);
        var i = 1;
        return Pit.FSharp.Core.Operators.op_PipeRight(s)((function(set) {
            return Pit.FSharp.Collections.SetModule.Iterate(function(e) {
                equal(e, i, "Set Iterate");
                return i = 2;
            })(set);
        }));
    });
});
Pit.Test.SetTests.Map = (function() {
    return test("map", function() {
        var s = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SetModule.Empty().Add(1).Add(2))((function(set) {
            return Pit.FSharp.Collections.SetModule.Map((function(e) {
                return (e + 2);
            }))(set);
        }));
        var i = 3;
        return Pit.FSharp.Core.Operators.op_PipeRight(s)((function(set) {
            return Pit.FSharp.Collections.SetModule.Iterate(function(e) {
                equal(e, i, "Set Iterate");
                return i = 4;
            })(set);
        }));
    });
});
Pit.Test.SetTests.MaxElement = (function() {
    return test("maxelement", function() {
        var s = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))));
        var m = Pit.FSharp.Collections.SetModule.MaxElement(s);
        return equal(10, m, "Set MaxElement");
    });
});
Pit.Test.SetTests.MinElement = (function() {
    return test("minelement", function() {
        var s = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(5)(10))));
        var m = Pit.FSharp.Collections.SetModule.MinElement(s);
        return equal(5, m, "Set MinElement");
    });
});
Pit.Test.SetTests.OfArray = (function() {
    return test("ofarray", function() {
        var s = Pit.FSharp.Collections.SetModule.OfArray([1, 2, 3]);
        var c = Pit.FSharp.Collections.SetModule.Count(s);
        return equal(3, c, "Set OfArray");
    });
});
Pit.Test.SetTests.OfList = (function() {
    return test("oflist", function() {
        var s = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(3))));
        var c = Pit.FSharp.Collections.SetModule.Count(s);
        return equal(3, c, "Set OfList");
    });
});
Pit.Test.SetTests.OfSeq = (function() {
    return test("ofseq", function() {
        var s = Pit.FSharp.Collections.SetModule.OfSeq(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(3)));
        var c = Pit.FSharp.Collections.SetModule.Count(s);
        return equal(3, c, "Set OfSeq");
    });
});
Pit.Test.SetTests.Partition = (function() {
    return test("partition", function() {
        var s = Pit.FSharp.Collections.SetModule.OfArray([-2, -1, 1, 2]);
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(set) {
            return Pit.FSharp.Collections.SetModule.Partition((function(t) {
                return t < 0;
            }))(set);
        }));
        var p = patternInput.Item2;
        var n = patternInput.Item1;
        var nc = Pit.FSharp.Collections.SetModule.Count(n);
        return equal(2, nc, "Set Partition");
    });
});
Pit.Test.SetTests.Remove = (function() {
    return test("remove", function() {
        var s = Pit.FSharp.Collections.SetModule.Empty().Add(1).Add(2);
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(set) {
            return Pit.FSharp.Collections.SetModule.Remove(2)(set);
        }));
        var c = Pit.FSharp.Core.Operators.op_PipeRight(r)((function(set) {
            return Pit.FSharp.Collections.SetModule.Count(set);
        }));
        return equal(1, c, "Set Remove");
    });
});
Pit.Test.SetTests.Singleton = (function() {
    return test("singleton", function() {
        var s = Pit.FSharp.Collections.SetModule.Singleton(1);
        var c = Pit.FSharp.Collections.SetModule.Count(s);
        return equal(1, c, "Set Singleton");
    });
});
Pit.Test.SetTests.Union = (function() {
    return test("union", function() {
        var s1 = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_RangeStep(2)(2)(8))));
        var s2 = Pit.FSharp.Collections.SetModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_RangeStep(1)(2)(9))));
        var s3 = Pit.FSharp.Collections.SetModule.Union(s1)(s2);
        var c = Pit.FSharp.Collections.SetModule.Count(s3);
        return equal(9, c, "Set Union");
    });
});
Pit.Test.SetTests.UnionMany = (function() {
    return test("union many", function() {
        var sets = [Pit.FSharp.Collections.SetModule.OfArray(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(9)))), Pit.FSharp.Collections.SetModule.OfArray(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(5)(8))))];
        var setres = Pit.FSharp.Collections.SetModule.UnionMany(sets);
        var c = Pit.FSharp.Collections.SetModule.Count(setres);
        return equal(9, c, "Set Union Many");
    });
});
Pit.Test.SetTests.run = function() {
    Pit.Test.SetTests.Create();
    Pit.Test.SetTests.Add();
    Pit.Test.SetTests.AddOp();
    Pit.Test.SetTests.Contains();
    Pit.Test.SetTests.Exists();
    Pit.Test.SetTests.Filter();
    Pit.Test.SetTests.Difference();
    Pit.Test.SetTests.DifferenceOp();
    Pit.Test.SetTests.Fold();
    Pit.Test.SetTests.FoldBack();
    Pit.Test.SetTests.ForAll();
    Pit.Test.SetTests.Intersect();
    Pit.Test.SetTests.IntersectMany();
    Pit.Test.SetTests.IsEmpty();
    Pit.Test.SetTests.IsProperSubset();
    Pit.Test.SetTests.IsProperSuperset();
    Pit.Test.SetTests.Iterate();
    Pit.Test.SetTests.Map();
    Pit.Test.SetTests.MaxElement();
    Pit.Test.SetTests.MinElement();
    Pit.Test.SetTests.OfArray();
    Pit.Test.SetTests.OfList();
    Pit.Test.SetTests.OfSeq();
    Pit.Test.SetTests.Partition();
    Pit.Test.SetTests.Remove();
    Pit.Test.SetTests.Singleton();
    Pit.Test.SetTests.Union();
    return Pit.Test.SetTests.UnionMany();
};
registerNamespace("Pit.Test");
Pit.Test.ObservableTests.EventTest = (function() {
    function EventTest() {
        var thisObject = this;
        thisObject.evt = new Pit.FSharp.Control.FSharpEvent1();
        thisObject.evt2 = new Pit.FSharp.Control.FSharpEvent1();
        thisObject.i = 0;
        thisObject.i2 = 0;
    }
    EventTest.prototype.FakeCall = function() {
        var thisObject = this;
        thisObject.evt.Trigger(thisObject.i);
        return thisObject.i = (thisObject.i + 1);
    };
    EventTest.prototype.FakeCall2 = function() {
        var thisObject = this;
        thisObject.evt2.Trigger(thisObject.i2);
        return thisObject.i2 = (thisObject.i2 + 1);
    };
    EventTest.prototype.get_Evt = function() {
        return this.evt.get_Publish();
    };
    EventTest.prototype.get_Evt2 = function() {
        return this.evt2.get_Publish();
    };
    return EventTest;
})();
Pit.Test.ObservableTests.Add = (function() {
    return test("add", function() {
        var e = new Pit.Test.ObservableTests.EventTest();
        var n = 0;
        Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add(function(i) {
                equal(n, i, "Observable Add Test");
                return n = (n + 1);
            })(source);
        }));
        e.FakeCall();
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.ObservableTests.Map = (function() {
    return test("map", function() {
        var e = new Pit.Test.ObservableTests.EventTest();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(source) {
            return Pit.FSharp.Control.ObservableModule.Map(function(i) {
                return {
                    Item1: i,
                    Item2: (i + 1)
                };
            })(source);
        })))((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add(function(tupledArg) {
                var k = tupledArg.Item1;
                var l = tupledArg.Item2;
                equal(k, 0, "Observable Map Test");
                return equal(l, 1, "Observable Map Test");
            })(source);
        }));
        return e.FakeCall();
    });
});
Pit.Test.ObservableTests.Choose = (function() {
    return test("choose", function() {
        var e = new Pit.Test.ObservableTests.EventTest();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(source) {
            return Pit.FSharp.Control.ObservableModule.Choose(function(i) {
                return (function(thisObject) {
                    if (i == 1) {
                        return new Pit.FSharp.Core.FSharpOption1.Some({
                            Item1: i,
                            Item2: (i + 1)
                        });
                    } else {
                        return new Pit.FSharp.Core.FSharpOption1.None();
                    }
                })(this);
            })(source);
        })))((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add(function(tupledArg) {
                var k = tupledArg.Item1;
                var l = tupledArg.Item2;
                equal(k, 1, "Observable Choose Test");
                return equal(l, 2, "Observable Choose Test");
            })(source);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.ObservableTests.Filter = (function() {
    return test("filter", function() {
        var e = new Pit.Test.ObservableTests.EventTest();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(source) {
            return Pit.FSharp.Control.ObservableModule.Filter(function(i) {
                return (function(thisObject) {
                    if (i == 1) {
                        return true;
                    } else {
                        return false;
                    }
                })(this);
            })(source);
        })))((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add((function(k) {
                return equal(k, 1, "Observable Filter Test");
            }))(source);
        }));
        e.FakeCall();
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.ObservableTests.Merge = (function() {
    return test("merge", function() {
        var e = new Pit.Test.ObservableTests.EventTest();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(source2) {
            return Pit.FSharp.Control.ObservableModule.Merge(e.get_Evt2())(source2);
        })))((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add((function(k) {
                return equal(k, 0, "Event Merge test");
            }))(source);
        }));
        e.FakeCall();
        return e.FakeCall2();
    });
});
Pit.Test.ObservableTests.PairWise = (function() {
    return test("pairwise", function() {
        var e = new Pit.Test.ObservableTests.EventTest();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(source) {
            return Pit.FSharp.Control.ObservableModule.Pairwise(source);
        })))((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add(function(tupledArg) {
                var k = tupledArg.Item1;
                var l = tupledArg.Item2;
                equal(k, 0, "Observable Pairwise Test");
                return equal(l, 1, "Observable Pairwise Test");
            })(source);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.ObservableTests.Partition = (function() {
    return test("partition", function() {
        var e = new Pit.Test.ObservableTests.EventTest();
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(source) {
            return Pit.FSharp.Control.ObservableModule.Partition((function(l) {
                return l == 1;
            }))(source);
        }));
        var e2 = patternInput.Item2;
        var e1 = patternInput.Item1;
        Pit.FSharp.Core.Operators.op_PipeRight(e1)((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add((function(l) {
                return equal(l, 1, "Observable partition test");
            }))(source);
        }));
        Pit.FSharp.Core.Operators.op_PipeRight(e2)((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add((function(k) {
                return equal(k, 0, "Observable parition test");
            }))(source);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.ObservableTests.Scan = (function() {
    return test("scan", function() {
        var initialState = 0;
        var i = 1;
        var e = new Pit.Test.ObservableTests.EventTest();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(source) {
            return Pit.FSharp.Control.ObservableModule.Scan(function(state) {
                return (function(_arg1) {
                    return (state + 1);
                });
            })(initialState)(source);
        })))((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add(function(l) {
                equal(i, l, "Event Scan Test");
                return i = (i + 1);
            })(source);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.ObservableTests.OddEven = function(i) {
    return (function(thisObject) {
        if ((i % 2) == 0) {
            return new Pit.FSharp.Core.FSharpChoice2.Choice1Of2(i);
        } else {
            return new Pit.FSharp.Core.FSharpChoice2.Choice2Of2(i);
        }
    })(this);
};
Pit.Test.ObservableTests.Split = (function() {
    return test("split", function() {
        var initialState = 0;
        var e = new Pit.Test.ObservableTests.EventTest();
        var patternInput = Pit.FSharp.Control.ObservableModule.Split((function(i) {
            return Pit.Test.ObservableTests.OddEven(i);
        }))(e.get_Evt());
        var OddResult = patternInput.Item1;
        var EvenResult = patternInput.Item2;
        Pit.FSharp.Core.Operators.op_PipeRight(OddResult)((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add((function(k) {
                return equal(k, 0, "Event Split test");
            }))(source);
        }));
        Pit.FSharp.Core.Operators.op_PipeRight(EvenResult)((function(source) {
            return Pit.FSharp.Control.ObservableModule.Add((function(k) {
                return equal(k, 1, "Event Split test");
            }))(source);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.ObservableTests.run = function() {
    module("Observable Tests");
    Pit.Test.ObservableTests.Add();
    Pit.Test.ObservableTests.Map();
    Pit.Test.ObservableTests.Choose();
    Pit.Test.ObservableTests.Filter();
    Pit.Test.ObservableTests.Merge();
    Pit.Test.ObservableTests.PairWise();
    Pit.Test.ObservableTests.Partition();
    Pit.Test.ObservableTests.Scan();
    return Pit.Test.ObservableTests.Split();
};
registerNamespace("Pit.Test");
Pit.Test.Event2Tests.Args = (function() {
    function Args(x) {
        var thisObject = this;
        thisObject.x = x;
    }
    Args.prototype.get_XValue = function() {
        return this.x;
    };
    return Args;
})();
Pit.Test.Event2Tests.Event2Test = (function() {
    function Event2Test() {
        var thisObject = this;
        thisObject.ev = new Pit.FSharp.Control.FSharpEvent2();
        thisObject.ev2 = new Pit.FSharp.Control.FSharpEvent2();
        thisObject.i = 0;
        thisObject.i2 = 0;
    }
    Event2Test.prototype.FakeCall = function() {
        var thisObject = this;
        thisObject.ev.Trigger(thisObject, new Pit.Test.Event2Tests.Args(thisObject.i));
        return thisObject.i = (thisObject.i + 1);
    };
    Event2Test.prototype.FakeCall2 = function() {
        var thisObject = this;
        thisObject.ev2.Trigger(thisObject, new Pit.Test.Event2Tests.Args(thisObject.i2));
        return thisObject.i2 = (thisObject.i2 + 1);
    };
    Event2Test.prototype.get_Evt = function() {
        return this.ev.get_Publish();
    };
    Event2Test.prototype.get_Evt2 = function() {
        return this.ev2.get_Publish();
    };
    return Event2Test;
})();
Pit.Test.Event2Tests.Add = (function() {
    return test("add", function() {
        var e = new Pit.Test.Event2Tests.Event2Test();
        Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(arg) {
                return equal(arg.get_XValue(), 0, "Event2 add test");
            }))(sourceEvent);
        }));
        return e.FakeCall();
    });
});
Pit.Test.Event2Tests.Map = (function() {
    return test("map", function() {
        var e = new Pit.Test.Event2Tests.Event2Test();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Map(function(a) {
                return {
                    Item1: a.get_XValue(),
                    Item2: (a.get_XValue() + 1)
                };
            })(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add(function(tupledArg) {
                var k = tupledArg.Item1;
                var l = tupledArg.Item2;
                equal(k, 0, "Event2 Map test");
                return equal(l, 1, "Event2 Map test");
            })(sourceEvent);
        }));
        return e.FakeCall();
    });
});
Pit.Test.Event2Tests.Choose = (function() {
    return test("choose", function() {
        var e = new Pit.Test.Event2Tests.Event2Test();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Choose(function(arg) {
                return (function(thisObject) {
                    if (arg.get_XValue() == 1) {
                        return new Pit.FSharp.Core.FSharpOption1.Some({
                            Item1: arg.get_XValue(),
                            Item2: (arg.get_XValue() + 1)
                        });
                    } else {
                        return new Pit.FSharp.Core.FSharpOption1.None();
                    }
                })(this);
            })(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add(function(tupledArg) {
                var k = tupledArg.Item1;
                var l = tupledArg.Item2;
                equal(k, 1, "Event2 Choose test");
                return equal(l, 2, "Event2 Choose test");
            })(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.Event2Tests.Filter = (function() {
    return test("filter", function() {
        var e = new Pit.Test.Event2Tests.Event2Test();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Filter(function(arg) {
                return (function(thisObject) {
                    if (arg.get_XValue() == 1) {
                        return true;
                    } else {
                        return false;
                    }
                })(this);
            })(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(k) {
                return equal(k.get_XValue(), 1, "Event2 filter test");
            }))(sourceEvent);
        }));
        e.FakeCall();
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.Event2Tests.Merge = (function() {
    return test("merge", function() {
        var e = new Pit.Test.Event2Tests.Event2Test();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(event2) {
            return Pit.FSharp.Control.EventModule.Merge(e.get_Evt2())(event2);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(arg) {
                return equal(arg.get_XValue(), 0, "Event2 Merge test");
            }))(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall2();
    });
});
Pit.Test.Event2Tests.PairWise = (function() {
    return test("pairwise", function() {
        var e = new Pit.Test.Event2Tests.Event2Test();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Pairwise(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add(function(tupledArg) {
                var k = tupledArg.Item1;
                var l = tupledArg.Item2;
                equal(k.get_XValue(), 0, "Event2 Pairwise test");
                return equal(l.get_XValue(), 1, "Event2 Pairwise test");
            })(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.Event2Tests.Partition = (function() {
    return test("partition", function() {
        var e = new Pit.Test.Event2Tests.Event2Test();
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Partition((function(l) {
                return l.get_XValue() == 1;
            }))(sourceEvent);
        }));
        var e2 = patternInput.Item2;
        var e1 = patternInput.Item1;
        Pit.FSharp.Core.Operators.op_PipeRight(e1)((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(l) {
                return equal(l.get_XValue(), 1, "Event2 Partition test");
            }))(sourceEvent);
        }));
        Pit.FSharp.Core.Operators.op_PipeRight(e2)((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(l) {
                return equal(l.get_XValue(), 0, "Event2 Partition test");
            }))(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.Event2Tests.Scan = (function() {
    return test("scan", function() {
        var initialState = 0;
        var i = 1;
        var e = new Pit.Test.Event2Tests.Event2Test();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Scan(function(state) {
                return (function(_arg1) {
                    return (state + 1);
                });
            })(initialState)(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add(function(l) {
                equal(i, l, "Event2 Scan Test");
                return i = (i + 1);
            })(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.Event2Tests.OddEven = function(i) {
    return (function(thisObject) {
        if ((i.get_XValue() % 2) == 0) {
            return new Pit.FSharp.Core.FSharpChoice2.Choice1Of2(i.get_XValue());
        } else {
            return new Pit.FSharp.Core.FSharpChoice2.Choice2Of2(i.get_XValue());
        }
    })(this);
};
Pit.Test.Event2Tests.Split = (function() {
    return test("split", function() {
        var initialState = 0;
        var e = new Pit.Test.Event2Tests.Event2Test();
        var patternInput = Pit.FSharp.Control.EventModule.Split((function(i) {
            return Pit.Test.Event2Tests.OddEven(i);
        }))(e.get_Evt());
        var OddResult = patternInput.Item1;
        var EvenResult = patternInput.Item2;
        Pit.FSharp.Core.Operators.op_PipeRight(OddResult)((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(k) {
                return equal(k, 0, "Event2 Split test");
            }))(sourceEvent);
        }));
        Pit.FSharp.Core.Operators.op_PipeRight(EvenResult)((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(k) {
                return equal(k, 1, "Event2 Split test");
            }))(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.Event2Tests.run = function() {
    module("Event2 Tests");
    Pit.Test.Event2Tests.Add();
    Pit.Test.Event2Tests.Map();
    Pit.Test.Event2Tests.Choose();
    Pit.Test.Event2Tests.Filter();
    Pit.Test.Event2Tests.Merge();
    Pit.Test.Event2Tests.PairWise();
    Pit.Test.Event2Tests.Partition();
    Pit.Test.Event2Tests.Scan();
    return Pit.Test.Event2Tests.Split();
};
registerNamespace("Pit.Test");
Pit.Test.EventsTest.EventTest = (function() {
    function EventTest() {
        var thisObject = this;
        thisObject.evt = new Pit.FSharp.Control.FSharpEvent1();
        thisObject.evt2 = new Pit.FSharp.Control.FSharpEvent1();
        thisObject.i = 0;
        thisObject.i2 = 0;
    }
    EventTest.prototype.FakeCall = function() {
        var thisObject = this;
        thisObject.evt.Trigger(thisObject.i);
        return thisObject.i = (thisObject.i + 1);
    };
    EventTest.prototype.FakeCall2 = function() {
        var thisObject = this;
        thisObject.evt2.Trigger(thisObject.i2);
        return thisObject.i2 = (thisObject.i2 + 1);
    };
    EventTest.prototype.get_Evt = function() {
        return this.evt.get_Publish();
    };
    EventTest.prototype.get_Evt2 = function() {
        return this.evt2.get_Publish();
    };
    return EventTest;
})();
Pit.Test.EventsTest.Add = function() {
    var e = new Pit.Test.EventsTest.EventTest();
    return test("add", function() {
        Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(i) {
                return equal(i, 0, "Event Add test");
            }))(sourceEvent);
        }));
        return e.FakeCall();
    });
};
Pit.Test.EventsTest.Map = function() {
    var e = new Pit.Test.EventsTest.EventTest();
    return test("map", function() {
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Map(function(i) {
                return {
                    Item1: i,
                    Item2: (i + 1)
                };
            })(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add(function(tupledArg) {
                var k = tupledArg.Item1;
                var l = tupledArg.Item2;
                equal(k, 0, "Event Map test");
                return equal(l, 1, "Event Map test");
            })(sourceEvent);
        }));
        return e.FakeCall();
    });
};
Pit.Test.EventsTest.Choose = function() {
    var e = new Pit.Test.EventsTest.EventTest();
    return test("choose", function() {
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Choose(function(i) {
                return (function(thisObject) {
                    if (i == 1) {
                        return new Pit.FSharp.Core.FSharpOption1.Some({
                            Item1: i,
                            Item2: (i + 1)
                        });
                    } else {
                        return new Pit.FSharp.Core.FSharpOption1.None();
                    }
                })(this);
            })(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add(function(tupledArg) {
                var k = tupledArg.Item1;
                var l = tupledArg.Item2;
                equal(k, 1, "Event Choose test");
                return equal(l, 2, "Event Choose test");
            })(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
};
Pit.Test.EventsTest.Filter = function() {
    var e = new Pit.Test.EventsTest.EventTest();
    return test("filter", function() {
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Filter(function(i) {
                return (function(thisObject) {
                    if (i == 1) {
                        return true;
                    } else {
                        return false;
                    }
                })(this);
            })(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(k) {
                return equal(k, 1, "Event Filter test");
            }))(sourceEvent);
        }));
        e.FakeCall();
        e.FakeCall();
        return e.FakeCall();
    });
};
Pit.Test.EventsTest.Merge = function() {
    var e = new Pit.Test.EventsTest.EventTest();
    return test("merge", function() {
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(event2) {
            return Pit.FSharp.Control.EventModule.Merge(e.get_Evt2())(event2);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(k) {
                return equal(k, 0, "Event Merge test");
            }))(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall2();
    });
};
Pit.Test.EventsTest.PairWise = function() {
    var e = new Pit.Test.EventsTest.EventTest();
    return test("pairwise", function() {
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Pairwise(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add(function(tupledArg) {
                var k = tupledArg.Item1;
                var l = tupledArg.Item2;
                equal(k, 0, "Event PairWise test");
                return equal(l, 1, "Event PairWise test");
            })(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
};
Pit.Test.EventsTest.Partition = (function() {
    return test("partition", function() {
        var e = new Pit.Test.EventsTest.EventTest();
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Partition((function(l) {
                return l == 1;
            }))(sourceEvent);
        }));
        var e2 = patternInput.Item2;
        var e1 = patternInput.Item1;
        Pit.FSharp.Core.Operators.op_PipeRight(e1)((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(l) {
                return equal(l, 1, "Event Partition test");
            }))(sourceEvent);
        }));
        Pit.FSharp.Core.Operators.op_PipeRight(e2)((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(l) {
                return equal(l, 0, "Event Partition test");
            }))(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.EventsTest.Scan = (function() {
    return test("scan", function() {
        var initialState = 0;
        var i = 1;
        var e = new Pit.Test.EventsTest.EventTest();
        Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(e.get_Evt())((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Scan(function(state) {
                return (function(_arg1) {
                    return (state + 1);
                });
            })(initialState)(sourceEvent);
        })))((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add(function(l) {
                equal(i, l, "Event Scan Test");
                return i = (i + 1);
            })(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.EventsTest.OddEven = function(i) {
    return (function(thisObject) {
        if ((i % 2) == 0) {
            return new Pit.FSharp.Core.FSharpChoice2.Choice1Of2(i);
        } else {
            return new Pit.FSharp.Core.FSharpChoice2.Choice2Of2(i);
        }
    })(this);
};
Pit.Test.EventsTest.Split = (function() {
    return test("split", function() {
        var initialState = 0;
        var e = new Pit.Test.EventsTest.EventTest();
        var patternInput = Pit.FSharp.Control.EventModule.Split((function(i) {
            return Pit.Test.EventsTest.OddEven(i);
        }))(e.get_Evt());
        var OddResult = patternInput.Item1;
        var EvenResult = patternInput.Item2;
        Pit.FSharp.Core.Operators.op_PipeRight(OddResult)((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(k) {
                return equal(k, 0, "Event Split test");
            }))(sourceEvent);
        }));
        Pit.FSharp.Core.Operators.op_PipeRight(EvenResult)((function(sourceEvent) {
            return Pit.FSharp.Control.EventModule.Add((function(k) {
                return equal(k, 1, "Event Split test");
            }))(sourceEvent);
        }));
        e.FakeCall();
        return e.FakeCall();
    });
});
Pit.Test.EventsTest.run = function() {
    module("Event Tests");
    Pit.Test.EventsTest.Add();
    Pit.Test.EventsTest.Map();
    Pit.Test.EventsTest.Choose();
    Pit.Test.EventsTest.Filter();
    Pit.Test.EventsTest.Merge();
    Pit.Test.EventsTest.PairWise();
    Pit.Test.EventsTest.Partition();
    Pit.Test.EventsTest.Scan();
    return Pit.Test.EventsTest.Split();
};
registerNamespace("Pit.Test.ListTest.Transaction");
Pit.Test.ListTest.Transaction = function() {
    this.Tag = 0;
    this.IsWithdrawal = false;
    this.IsDeposit = false;
};
Pit.Test.ListTest.Transaction.Deposit = function() {};
Pit.Test.ListTest.Transaction.Deposit.prototype = new Pit.Test.ListTest.Transaction();
Pit.Test.ListTest.Transaction.Deposit.prototype.equality = function(compareTo) {
    var result = true;
    return result;
};
Pit.Test.ListTest.Transaction.Withdrawal = function() {};
Pit.Test.ListTest.Transaction.Withdrawal.prototype = new Pit.Test.ListTest.Transaction();
Pit.Test.ListTest.Transaction.Withdrawal.prototype.equality = function(compareTo) {
    var result = true;
    return result;
};
Pit.Test.ListTest.Transaction.prototype.get_Tag = function() {
    return this.Tag;
};
Pit.Test.ListTest.Transaction.prototype.get_IsWithdrawal = function() {
    return this instanceof Pit.Test.ListTest.Transaction.Withdrawal;
};
Pit.Test.ListTest.Transaction.prototype.get_IsDeposit = function() {
    return this instanceof Pit.Test.ListTest.Transaction.Deposit;
};
Pit.Test.ListTest.Declare1 = (function() {
    return test("declare1", function() {
        var list123 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        return equal(list123.get_Head(), 1, "Declare List type 1:");
    });
});
Pit.Test.ListTest.Declare2 = (function() {
    return test("declare2", function() {
        var list123 = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10)));
        return equal(list123.get_Head(), 1, "Declare List type 2:");
    });
});
Pit.Test.ListTest.Declare3 = (function() {
    return test("declare3", function() {
        var list123 = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return (i * i);
            }))(Pit.FSharp.Core.Operators.op_Range(1)(10));
        }))));
        return equal(list123.get_Head(), 1, "Declare List type 3:");
    });
});
Pit.Test.ListTest.AttachElements = (function() {
    return test("attach elements", function() {
        var list123 = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return (i * i);
            }))(Pit.FSharp.Core.Operators.op_Range(1)(10));
        }))));
        var list2 = new Pit.FSharp.Collections.FSharpList1.Cons(100, list123);
        return equal(list2.get_Head(), 100, "Attach elements:");
    });
});
Pit.Test.ListTest.ConcatenateElements = (function() {
    return test("concatenate", function() {
        var list1 = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return (i * i);
            }))(Pit.FSharp.Core.Operators.op_Range(1)(10));
        }))));
        var list2 = Pit.FSharp.Collections.ListModule.OfArray([100]);
        var list3 = Pit.FSharp.Core.Operators.op_Append(list1)(list2);
        return equal(list3.get_Head(), 1, "Concatenate elements:");
    });
});
Pit.Test.ListTest.Properties = (function() {
    return test("properties", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        equal(list1.get_IsEmpty(), false, "List Empty property:");
        equal(list1.get_Length(), 3, "List Length property:");
        equal(list1.get_Head(), 1, "List Head property:");
        equal(list1.get_Tail().get_Head(), 2, "List Tail property");
        equal(list1.get_Tail().get_Tail().get_Head(), 3, "List.Tail.Tail.Head");
        return equal(list1.get_Item(1), 2, "List.Item(1)");
    });
});
Pit.Test.ListTest.Recursion1 = function() {
    var sum = function(list) {
            var loop = function(list1) {
                    return function(acc) {
                        return (function(thisObject) {
                            if (list1 instanceof Pit.FSharp.Collections.FSharpList1.Empty) {
                                return acc;
                            } else {
                                var tail = list1.get_Tail();
                                var head = list1.get_Head();
                                return loop(tail)((acc + head));
                            }
                        })(this);
                    };
                };
            return loop(list)(0);
        };
    return test("recursion1", function() {
        var list = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        return equal(sum(list), 6, "List Recursion 1");
    });
};
Pit.Test.ListTest.Recursion2 = function() {
    var IsPrimeMultipleTest = function(n) {
            return function(x) {
                return (function(thisObject) {
                    if (x == n) {
                        return true;
                    } else {
                        return (x % n) != 0;
                    }
                })(this);
            };
        };
    var RemoveAllMultiples = function(listn) {
            return function(listx) {
                return (function(thisObject) {
                    if (listn instanceof Pit.FSharp.Collections.FSharpList1.Empty) {
                        return listx;
                    } else {
                        var tail = listn.get_Tail();
                        var head = listn.get_Head();
                        return RemoveAllMultiples(tail)(Pit.FSharp.Collections.ListModule.Filter(IsPrimeMultipleTest(head))(listx));
                    }
                })(this);
            };
        };
    var GetPrimesUpTo = function(n) {
            var max = Pit.FSharp.Core.Operators.ToInt(Pit.FSharp.Core.Operators.Sqrt(Pit.FSharp.Core.Operators.ToDouble(n)));
            return RemoveAllMultiples(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(2)(max))))(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(n))));
        };
    return test("recursion2", function() {
        var primes = GetPrimesUpTo(100);
        equal(Pit.FSharp.Collections.ListModule.Get(primes)(1), 2, "List Recursion 2 - First element");
        return equal(Pit.FSharp.Collections.ListModule.Get(primes)(25), 97, "List Recursion 2 - 25th element");
    });
};
Pit.Test.ListTest.containsNumber = function(number) {
    return (function(list) {
        return Pit.FSharp.Collections.ListModule.Exists((function(elem) {
            return elem == number;
        }))(list);
    });
};
Pit.Test.ListTest.BooleanOperation = (function() {
    return test("boolean op", function() {
        var list0to3 = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(0)(3)));
        return equal(Pit.Test.ListTest.containsNumber(0)(list0to3), true, "Boolean Operation:");
    });
});
Pit.Test.ListTest.isEqualElement = function(list1) {
    return (function(list2) {
        return Pit.FSharp.Collections.ListModule.Exists2(function(elem1) {
            return (function(elem2) {
                return elem1 == elem2;
            });
        })(list1)(list2);
    });
};
Pit.Test.ListTest.Exists2 = (function() {
    return test("exists2", function() {
        var list1to5 = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5)));
        var list5to1 = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_RangeStep(5)(-1)(1)));
        var result = Pit.Test.ListTest.isEqualElement(list1to5)(list5to1);
        return (function(thisObject) {
            if (result) {
                return equal(result, true, "List.exists2 function.");
            } else {
                return equal(result, false, "List.exists2 function.");
            }
        })(this);
    });
});
Pit.Test.ListTest.ForAll = (function() {
    return test("forall", function() {
        var isAllZeroes = (function(list) {
            return Pit.FSharp.Collections.ListModule.ForAll((function(elem) {
                return elem == 0;
            }))(list);
        });
        equal(isAllZeroes(Pit.FSharp.Collections.ListModule.OfArray([0, 0])), true, "List.forall function");
        return equal(isAllZeroes(Pit.FSharp.Collections.ListModule.OfArray([0, 1])), false, "List.forall function");
    });
});
Pit.Test.ListTest.listEqual = function(list1) {
    return (function(list2) {
        return Pit.FSharp.Collections.ListModule.ForAll2(function(elem1) {
            return (function(elem2) {
                return elem1 == elem2;
            });
        })(list1)(list2);
    });
};
Pit.Test.ListTest.ForAll2 = (function() {
    return test("forall2", function() {
        equal(Pit.Test.ListTest.listEqual(Pit.FSharp.Collections.ListModule.OfArray([0, 1, 2]))(Pit.FSharp.Collections.ListModule.OfArray([0, 1, 2])), true, "List.forall2 function");
        return equal(Pit.Test.ListTest.listEqual(Pit.FSharp.Collections.ListModule.OfArray([0, 0, 0]))(Pit.FSharp.Collections.ListModule.OfArray([0, 1, 0])), false, "List.forall2 function");
    });
});
Pit.Test.ListTest.Sort = (function() {
    return test("sort", function() {
        var sortedList1 = Pit.FSharp.Collections.ListModule.Sort(Pit.FSharp.Collections.ListModule.OfArray([1, 4, 8, -2, 5]));
        return equal(Pit.FSharp.Collections.ListModule.Get(sortedList1)(1), 1, "List.sort function");
    });
});
Pit.Test.ListTest.SortBy = (function() {
    return test("sortby", function() {
        var sortedList2 = Pit.FSharp.Collections.ListModule.SortBy((function(elem) {
            return Pit.FSharp.Core.Operators.Abs(elem);
        }))(Pit.FSharp.Collections.ListModule.OfArray([1, 4, 8, -2, 5]));
        return equal(Pit.FSharp.Collections.ListModule.Get(sortedList2)(1), -2, "List.sortBy function");
    });
});
Pit.Test.ListTest.Find = (function() {
    return test("find", function() {
        var isDivisibleBy = function(number) {
                return (function(elem) {
                    return (elem % number) == 0;
                });
            };
        var result = Pit.FSharp.Collections.ListModule.Find(isDivisibleBy(5))(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(100))));
        return equal(result, 5, "List.find function");
    });
});
Pit.Test.ListTest.Pick = (function() {
    return test("pick", function() {
        var valuesList = Pit.FSharp.Collections.ListModule.OfArray([{
            Item1: "a",
            Item2: 1
        }, {
            Item1: "b",
            Item2: 2
        }, {
            Item1: "c",
            Item2: 3
        }]);
        var resultPick = Pit.FSharp.Collections.ListModule.Pick(function(elem) {
            return (function(thisObject) {
                if (elem.Item2 == 2) {
                    var value = elem.Item1;
                    return new Pit.FSharp.Core.FSharpOption1.Some(value);
                } else {
                    return new Pit.FSharp.Core.FSharpOption1.None();
                }
            })(this);
        })(valuesList);
        return equal(resultPick, "b", "List.pick function");
    });
});
Pit.Test.ListTest.TryFind = (function() {
    return test("tryfind", function() {
        var list1d = Pit.FSharp.Collections.ListModule.OfArray([1, 3, 7, 9, 11, 13, 15, 19, 22, 29, 36]);
        var isEven = (function(x) {
            return (x % 2) == 0;
        });
        var matchValue = Pit.FSharp.Collections.ListModule.TryFind(isEven)(list1d);
        (function(thisObject) {
            if (matchValue instanceof Pit.FSharp.Core.FSharpOption1.None) {
                return null;
            } else {
                var value = matchValue.get_Value();
                return equal(value, 22, "List.tryFind function");
            }
        })(this);
        var matchValue = Pit.FSharp.Collections.ListModule.TryFindIndex(isEven)(list1d);
        return (function(thisObject) {
            if (matchValue instanceof Pit.FSharp.Core.FSharpOption1.None) {
                return null;
            } else {
                var value = matchValue.get_Value();
                return equal(value, 8, "List.tryFindIndex function");
            }
        })(this);
    });
});
Pit.Test.ListTest.ArithemeticOperations = (function() {
    return test("arithmetic operations", function() {
        var sum1 = Pit.FSharp.Collections.ListModule.Sum(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))));
        equal(sum1, 55, "List.sum function");
        var sum2 = Pit.FSharp.Collections.ListModule.SumBy((function(elem) {
            return (elem * elem);
        }))(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))));
        equal(sum2, 385, "List.sumBy function");
        var avg1 = Pit.FSharp.Collections.ListModule.Average(Pit.FSharp.Collections.ListModule.OfArray([0, 1, 1, 2]));
        equal(avg1, 1, "List.average function");
        var avg2 = Pit.FSharp.Collections.ListModule.AverageBy((function(elem) {
            return Pit.FSharp.Core.Operators.ToDouble(elem);
        }))(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))));
        return equal(avg2, 5.5, "List.averageBy function");
    });
});
Pit.Test.ListTest.Zip = (function() {
    return test("zip", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var list2 = Pit.FSharp.Collections.ListModule.OfArray([-1, -2, -3]);
        var listZip = Pit.FSharp.Collections.ListModule.Zip(list1)(list2);
        var f = Pit.FSharp.Core.Operators.Fst(listZip.get_Head());
        equal(f, 1, "List.zip function");
        return equal(Pit.FSharp.Core.Operators.Snd(listZip.get_Head()), -1, "List.zip function");
    });
});
Pit.Test.ListTest.Zip3 = (function() {
    return test("zip3", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var list2 = Pit.FSharp.Collections.ListModule.OfArray([-1, -2, -3]);
        var list3 = Pit.FSharp.Collections.ListModule.OfArray([0, 0, 0]);
        var listZip3 = Pit.FSharp.Collections.ListModule.Zip3(list1)(list2)(list3);
        var patternInput = listZip3.get_Head();
        var f3 = patternInput.Item3;
        var f2 = patternInput.Item2;
        var f1 = patternInput.Item1;
        equal(f1, 1, "List.zip function");
        equal(f2, -1, "List.zip function");
        return equal(f3, 0, "List.zip function");
    });
});
Pit.Test.ListTest.UnZip = (function() {
    return test("unzip", function() {
        var lists = Pit.FSharp.Collections.ListModule.Unzip(Pit.FSharp.Collections.ListModule.OfArray([{
            Item1: 1,
            Item2: 2
        }, {
            Item1: 3,
            Item2: 4
        }]));
        equal(Pit.FSharp.Core.Operators.Fst(lists).get_Head(), 1, "List.unzip function");
        return equal(Pit.FSharp.Core.Operators.Snd(lists).get_Head(), 2, "List.unzip function");
    });
});
Pit.Test.ListTest.UnZip3 = (function() {
    return test("unzip3", function() {
        var listsUnzip3 = Pit.FSharp.Collections.ListModule.Unzip3(Pit.FSharp.Collections.ListModule.OfArray([{
            Item1: 1,
            Item2: 2,
            Item3: 3
        }, {
            Item1: 4,
            Item2: 5,
            Item3: 6
        }]));
        var i3 = listsUnzip3.Item3;
        var i2 = listsUnzip3.Item2;
        var i1 = listsUnzip3.Item1;
        equal(i1.get_Head(), 1, "List.unzip3 function");
        equal(i2.get_Head(), 2, "List.unzip3 function");
        return equal(i3.get_Head(), 3, "List.unzip3 function");
    });
});
Pit.Test.ListTest.Map = (function() {
    return test("map", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var newList = Pit.FSharp.Collections.ListModule.Map((function(x) {
            return (x + 1);
        }))(list1);
        return equal(newList.get_Head(), 2, "List.map function");
    });
});
Pit.Test.ListTest.Map2 = (function() {
    return test("map2", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var list2 = Pit.FSharp.Collections.ListModule.OfArray([4, 5, 6]);
        var sumList = Pit.FSharp.Collections.ListModule.Map2(function(x) {
            return (function(y) {
                return (x + y);
            });
        })(list1)(list2);
        return equal(sumList.get_Head(), 5, "List.map2 function");
    });
});
Pit.Test.ListTest.Map3 = (function() {
    return test("map3", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var list2 = Pit.FSharp.Collections.ListModule.OfArray([4, 5, 6]);
        var newList2 = Pit.FSharp.Collections.ListModule.Map3(function(x) {
            return function(y) {
                return (function(z) {
                    return ((x + y) + z);
                });
            };
        })(list1)(list2)(Pit.FSharp.Collections.ListModule.OfArray([2, 3, 4]));
        return equal(newList2.get_Head(), 7, "List.map3 function");
    });
});
Pit.Test.ListTest.Mapi = (function() {
    return test("mapi", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var newListAddIndex = Pit.FSharp.Collections.ListModule.MapIndexed(function(i) {
            return (function(x) {
                return (x + i);
            });
        })(list1);
        return equal(newListAddIndex.get_Head(), 1, "List.mapi function");
    });
});
Pit.Test.ListTest.Mapi2 = (function() {
    return test("mapi2", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var list2 = Pit.FSharp.Collections.ListModule.OfArray([4, 5, 6]);
        var listAddTimesIndex = Pit.FSharp.Collections.ListModule.MapIndexed2(function(i) {
            return function(x) {
                return (function(y) {
                    return ((x + y) * i);
                });
            };
        })(list1)(list2);
        return equal(listAddTimesIndex.get_Head(), 0, "List.mapi2 function");
    });
});
Pit.Test.ListTest.Collect = (function() {
    return test("collect", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var collectList = Pit.FSharp.Collections.ListModule.Collect((function(x) {
            return Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
                return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                    return (x * i);
                }))(Pit.FSharp.Core.Operators.op_Range(1)(3));
            }))));
        }))(list1);
        return equal(collectList.get_Head(), 1, "List.collect function");
    });
});
Pit.Test.ListTest.Filter = (function() {
    return test("filter", function() {
        var evenOnlyList = Pit.FSharp.Collections.ListModule.Filter((function(x) {
            return (x % 2) == 0;
        }))(Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3, 4, 5, 6]));
        return equal(Pit.FSharp.Core.Operators.op_PipeRight(evenOnlyList)((function(list) {
            return Pit.FSharp.Collections.ListModule.Length(list);
        })), 3, "List.filter function");
    });
});
Pit.Test.ListTest.Choose = (function() {
    return test("choose", function() {
        var k = Pit.FSharp.Collections.ListModule.Choose(function(elem) {
            return (function(thisObject) {
                if ((elem % 2) == 0) {
                    return new Pit.FSharp.Core.FSharpOption1.Some(Pit.FSharp.Core.Operators.ToDouble(((elem * elem) - 1)));
                } else {
                    return new Pit.FSharp.Core.FSharpOption1.None();
                }
            })(this);
        })(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))));
        return equal(k.get_Head(), 3, "List.choose function");
    });
});
Pit.Test.ListTest.Append = (function() {
    return test("append", function() {
        var list1to10 = Pit.FSharp.Collections.ListModule.Append(Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]))(Pit.FSharp.Collections.ListModule.OfArray([4, 5, 6, 7, 8, 9, 10]));
        return equal(Pit.FSharp.Core.Operators.op_PipeRight(list1to10)((function(list) {
            return Pit.FSharp.Collections.ListModule.Length(list);
        })), 10, "List.append function");
    });
});
Pit.Test.ListTest.Concat = (function() {
    return test("concat", function() {
        var listResult = Pit.FSharp.Collections.ListModule.Concat(Pit.FSharp.Collections.ListModule.OfArray([Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]), Pit.FSharp.Collections.ListModule.OfArray([4, 5, 6]), Pit.FSharp.Collections.ListModule.OfArray([7, 8, 9])]));
        return equal(Pit.FSharp.Core.Operators.op_PipeRight(listResult)((function(list) {
            return Pit.FSharp.Collections.ListModule.Length(list);
        })), 9, "List.concat function");
    });
});
Pit.Test.ListTest.reverseList = (function(list) {
    return Pit.FSharp.Collections.ListModule.Fold(function(acc) {
        return function(elem) {
            return new Pit.FSharp.Collections.FSharpList1.Cons(elem, acc);
        };
    })(new Pit.FSharp.Collections.FSharpList1.Empty())(list);
});
Pit.Test.ListTest.Fold = (function() {
    return test("fold", function() {
        var sumList = (function(list) {
            return Pit.FSharp.Collections.ListModule.Fold(function(acc) {
                return (function(elem) {
                    return (acc + elem);
                });
            })(0)(list);
        });
        return equal(sumList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(3)))), 6, "List.fold function: SumTest");
    });
});
Pit.Test.ListTest.Fold2 = (function() {
    return test("fold2", function() {
        var sumGreatest = function(list1) {
                return (function(list2) {
                    return Pit.FSharp.Collections.ListModule.Fold2(function(acc) {
                        return function(elem1) {
                            return (function(elem2) {
                                return (acc + Pit.FSharp.Core.Operators.Max(elem1)(elem2));
                            });
                        };
                    })(0)(list1)(list2);
                });
            };
        var sum = sumGreatest(Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]))(Pit.FSharp.Collections.ListModule.OfArray([3, 2, 1]));
        return equal(sum, 8, "List.fold2 function");
    });
});
Pit.Test.ListTest.Fold2_2 = function() {
    var transactionTypes = Pit.FSharp.Collections.ListModule.OfArray([new Pit.Test.ListTest.Transaction.Deposit(), new Pit.Test.ListTest.Transaction.Deposit(), new Pit.Test.ListTest.Transaction.Withdrawal()]);
    var transactionAmounts = Pit.FSharp.Collections.ListModule.OfArray([100, 1000, 95]);
    var initialBalance = 200;
    var endingBalance = Pit.FSharp.Collections.ListModule.Fold2(function(acc) {
        return function(elem1) {
            return function(elem2) {
                return (function(thisObject) {
                    if (elem1 instanceof Pit.Test.ListTest.Transaction.Withdrawal) {
                        return (acc - elem2);
                    } else {
                        return (acc + elem2);
                    }
                })(this);
            };
        };
    })(initialBalance)(transactionTypes)(transactionAmounts);
    return test("fold2_2", (function() {
        return equal(Pit.FSharp.Core.Operators.op_PipeRight(endingBalance)((function(value) {
            return Pit.FSharp.Core.Operators.ToInt(value);
        })), 1205, "List.fold2 function");
    }));
};
Pit.Test.ListTest.FoldBack = (function() {
    return test("foldback", function() {
        var sumListBack = (function(list) {
            return Pit.FSharp.Collections.ListModule.FoldBack(function(acc) {
                return (function(elem) {
                    return (acc + elem);
                });
            })(list)(0);
        });
        return equal(sumListBack(Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3])), 6, "List.foldBack function: Sum List");
    });
});
Pit.Test.ListTest.FoldBack2 = (function() {
    return test("foldback2", function() {
        var subtractArrayBack = function(array1) {
                return (function(array2) {
                    return Pit.FSharp.Collections.ListModule.FoldBack2(function(elem) {
                        return function(acc1) {
                            return (function(acc2) {
                                return (elem - (acc1 - acc2));
                            });
                        };
                    })(array1)(array2)(0);
                });
            };
        var a1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var a2 = Pit.FSharp.Collections.ListModule.OfArray([4, 5, 6]);
        var res = subtractArrayBack(a1)(a2);
        return equal(res, -9, "List.fold2 function:");
    });
});
Pit.Test.ListTest.Reduce = (function() {
    return test("reduce", function() {
        var sumAList = function(list) {
                return (function(thisObject) {
                    try {
                        return Pit.FSharp.Collections.ListModule.Reduce(function(acc) {
                            return (function(elem) {
                                return (acc + elem);
                            });
                        })(list);
                    } catch (matchValue) {
                        (function(thisObject) {
                            if (matchValue instanceof Pit.ArgumentException) {
                                var exc = matchValue;
                                return 0;
                            } else {
                                return Pit.FSharp.Core.Operators.Reraise();
                            }
                        })(thisObject)
                    }
                })(this);
            };
        var resultSum = sumAList(Pit.FSharp.Collections.ListModule.OfArray([2, 4, 10]));
        return equal(resultSum, 16, "List.reduce function:");
    });
});
Pit.Test.ListTest.run = function() {
    Pit.Test.ListTest.Declare1();
    Pit.Test.ListTest.Declare2();
    Pit.Test.ListTest.Declare3();
    Pit.Test.ListTest.AttachElements();
    Pit.Test.ListTest.ConcatenateElements();
    Pit.Test.ListTest.Properties();
    Pit.Test.ListTest.Recursion1();
    Pit.Test.ListTest.Recursion2();
    Pit.Test.ListTest.BooleanOperation();
    Pit.Test.ListTest.Exists2();
    Pit.Test.ListTest.ForAll();
    Pit.Test.ListTest.ForAll2();
    Pit.Test.ListTest.Sort();
    Pit.Test.ListTest.SortBy();
    Pit.Test.ListTest.Find();
    Pit.Test.ListTest.Pick();
    Pit.Test.ListTest.TryFind();
    Pit.Test.ListTest.ArithemeticOperations();
    Pit.Test.ListTest.Zip();
    Pit.Test.ListTest.Zip3();
    Pit.Test.ListTest.UnZip();
    Pit.Test.ListTest.UnZip3();
    Pit.Test.ListTest.Map();
    Pit.Test.ListTest.Map2();
    Pit.Test.ListTest.Map3();
    Pit.Test.ListTest.Mapi();
    Pit.Test.ListTest.Mapi2();
    Pit.Test.ListTest.Collect();
    Pit.Test.ListTest.Filter();
    Pit.Test.ListTest.Choose();
    Pit.Test.ListTest.Append();
    Pit.Test.ListTest.Concat();
    Pit.Test.ListTest.Fold();
    Pit.Test.ListTest.Fold2();
    Pit.Test.ListTest.Fold2_2();
    Pit.Test.ListTest.FoldBack();
    Pit.Test.ListTest.FoldBack2();
    return Pit.Test.ListTest.Reduce();
};
Pit.Test.SeqTest.Declare = (function() {
    return test("declare", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var i = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(5)(source);
        }));
        return equal(6, i, "Seq Declare");
    });
});
Pit.Test.SeqTest.Initialize = (function() {
    return test("initialize", function() {
        var s = Pit.FSharp.Collections.SeqModule.Initialize(5)(function(i) {
            return i;
        });
        var i = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(2)(source);
        }));
        return equal(2, i, "Seq Init");
    });
});
Pit.Test.SeqTest.InitializeInfinite = (function() {
    return test("initialize infinite", function() {
        var s = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SeqModule.InitializeInfinite((function(i) {
            return (i + 1);
        })))((function(source) {
            return Pit.FSharp.Collections.SeqModule.Take(10)(source);
        }));
        var len = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        }));
        return equal(10, len, "Seq Infinite");
    });
});
Pit.Test.SeqTest.OfArray = (function() {
    return test("ofarray", function() {
        var array = [1, 2, 3];
        var s = Pit.FSharp.Collections.SeqModule.OfArray(array);
        var i = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(0)(source);
        }));
        return equal(1, i, "Seq OfArray");
    });
});
Pit.Test.SeqTest.Iterate = (function() {
    return test("iterate", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(2));
        var idx = 1;
        return Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Iterate(function(i) {
                equal(i, idx, "Seq Iterate");
                return idx = (idx + 1);
            })(source);
        }));
    });
});
Pit.Test.SeqTest.IterateIndexed = (function() {
    return test("iterate indexed", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(2));
        var r = 1;
        return Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.IterateIndexed(function(idx) {
                return function(i) {
                    equal(i, r, "Seq IterateIndexed");
                    return r = (r + 1);
                };
            })(source);
        }));
    });
});
Pit.Test.SeqTest.Exists = (function() {
    return test("exists", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(3));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Exists((function(i) {
                return i == 2;
            }))(source);
        }));
        return equal(true, r, "Seq Exists");
    });
});
Pit.Test.SeqTest.ForAll = (function() {
    return test("forall", function() {
        var predicate = (function(elem) {
            return elem >= 0;
        });
        var allPositive = (function(source) {
            return Pit.FSharp.Collections.SeqModule.ForAll(predicate)(source);
        });
        var r = allPositive([0, 1, 2, 3]);
        return equal(true, r, "Seq ForAll");
    });
});
Pit.Test.SeqTest.Iterate2 = (function() {
    return test("iterate2", function() {
        var s1 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(2));
        var s2 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(2));
        var r = 1;
        return Pit.FSharp.Collections.SeqModule.Iterate2(function(i1) {
            return function(i2) {
                equal(i1, r, "Seq Iterate2");
                equal(i2, r, "Seq Iterate2");
                return r = (r + 1);
            };
        })(s1)(s2);
    });
});
Pit.Test.SeqTest.Filter = (function() {
    return test("filter", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Filter((function(i) {
                return i < 5;
            }))(source);
        }));
        return equal(4, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        })), "Seq Filter");
    });
});
Pit.Test.SeqTest.Map = (function() {
    return test("map", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return (i + i);
            }))(source);
        }));
        return equal(10, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(4)(source);
        })), "Seq Map");
    });
});
Pit.Test.SeqTest.MapIndexed = (function() {
    return test("map indexed", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.MapIndexed(function(idx) {
                return (function(i) {
                    return (idx + i);
                });
            })(source);
        }));
        return equal(9, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(4)(source);
        })), "Seq MapIndexed");
    });
});
Pit.Test.SeqTest.Map2 = (function() {
    return test("map2", function() {
        var s1 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        var s2 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(6)(10));
        var r = Pit.FSharp.Collections.SeqModule.Map2(function(i1) {
            return (function(i2) {
                return (i1 + i2);
            });
        })(s1)(s2);
        return equal(11, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(2)(source);
        })), "Seq Map2");
    });
});
Pit.Test.SeqTest.Choose = (function() {
    return test("choose", function() {
        var numbers = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var evens = Pit.FSharp.Collections.SeqModule.Choose(function(x) {
            return (function() {
                return (function(thisObject) {
                    var x1 = x;
                    if ((x1 % 2) == 0) {
                        var x1 = x;
                        return new Pit.FSharp.Core.FSharpOption1.Some(x1);
                    } else {
                        return new Pit.FSharp.Core.FSharpOption1.None();
                    };
                })(this);
            })();
        })(numbers);
        return equal(4, Pit.FSharp.Core.Operators.op_PipeRight(evens)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(1)(source);
        })), "Seq Choose");
    });
});
Pit.Test.SeqTest.Zip = (function() {
    return test("zip", function() {
        var s1 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(2));
        var s2 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(3)(4));
        var r = Pit.FSharp.Collections.SeqModule.Zip(s1)(s2);
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(0)(source);
        }));
        var i2 = patternInput.Item2;
        var i1 = patternInput.Item1;
        equal(1, i1, "Seq Zip");
        return equal(3, i2, "Seq Zip");
    });
});
Pit.Test.SeqTest.Zip3 = (function() {
    return test("zip3", function() {
        var s1 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(2));
        var s2 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(3)(4));
        var s3 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(5)(6));
        var r = Pit.FSharp.Collections.SeqModule.Zip3(s1)(s2)(s3);
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(0)(source);
        }));
        var i3 = patternInput.Item3;
        var i2 = patternInput.Item2;
        var i1 = patternInput.Item1;
        equal(1, i1, "Seq Zip");
        equal(3, i2, "Seq Zip");
        return equal(5, i3, "Seq Zip");
    });
});
Pit.Test.SeqTest.TryPick = (function() {
    return test("try pick", function() {
        var values = [{
            Item1: "a",
            Item2: 1
        }, {
            Item1: "b",
            Item2: 2
        }, {
            Item1: "c",
            Item2: 3
        }];
        var resultPick = Pit.FSharp.Collections.SeqModule.TryPick(function(elem) {
            return (function(thisObject) {
                if (elem.Item2 == 2) {
                    var value = elem.Item1;
                    return new Pit.FSharp.Core.FSharpOption1.Some(value);
                } else {
                    return new Pit.FSharp.Core.FSharpOption1.None();
                }
            })(this);
        })(values);
        return (function(thisObject) {
            if (resultPick instanceof Pit.FSharp.Core.FSharpOption1.None) {
                throw "Seq TryPick Failure"
            } else {
                var r = resultPick.get_Value();
                return equal("b", r, "Seq TryPick");
            }
        })(this);
    });
});
Pit.Test.SeqTest.Pick = (function() {
    return test("pick", function() {
        var values = [{
            Item1: "a",
            Item2: 1
        }, {
            Item1: "b",
            Item2: 2
        }, {
            Item1: "c",
            Item2: 3
        }];
        var resultPick = Pit.FSharp.Collections.SeqModule.Pick(function(elem) {
            return (function(thisObject) {
                if (elem.Item2 == 2) {
                    var value = elem.Item1;
                    return new Pit.FSharp.Core.FSharpOption1.Some(value);
                } else {
                    return new Pit.FSharp.Core.FSharpOption1.None();
                }
            })(this);
        })(values);
        return equal("b", resultPick, "Seq Pick");
    });
});
Pit.Test.SeqTest.TryFind = (function() {
    return test("tryFind", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        var matchValue = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.TryFind((function(i) {
                return i == 2;
            }))(source);
        }));
        return (function(thisObject) {
            if (matchValue instanceof Pit.FSharp.Core.FSharpOption1.None) {
                throw "Seq TryFind Failure"
            } else {
                var t = matchValue.get_Value();
                return equal(2, t, "Seq TryFind");
            }
        })(this);
    });
});
Pit.Test.SeqTest.Find = (function() {
    return test("find", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Find((function(i) {
                return i == 3;
            }))(source);
        }));
        return equal(3, r, "Seq Find");
    });
});
Pit.Test.SeqTest.Concat = (function() {
    return test("concat", function() {
        var s = Pit.FSharp.Collections.SeqModule.Concat([
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        ]);
        return equal(9, Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        })), "Seq Concat");
    });
});
Pit.Test.SeqTest.Length = (function() {
    return test("length", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        return equal(5, Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        })), "Seq Length");
    });
});
Pit.Test.SeqTest.Fold = (function() {
    return test("fold", function() {
        var sumSeq = (function(sequence1) {
            return Pit.FSharp.Collections.SeqModule.Fold(function(acc) {
                return (function(elem) {
                    return (acc + elem);
                });
            })(0)(sequence1);
        });
        var sum = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SeqModule.Initialize(10)((function(index) {
            return (index * index);
        })))(sumSeq);
        return equal(285, sum, "Seq Sum");
    });
});
Pit.Test.SeqTest.Reduce = (function() {
    return test("reduce", function() {
        var names = ["A", "man", "landed", "on", "the", "moon"];
        var sentence = Pit.FSharp.Core.Operators.op_PipeRight(names)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Reduce(function(acc) {
                return (function(item) {
                    return ((acc + " ") + item);
                });
            })(source);
        }));
        return equal(sentence, "A man landed on the moon", "Seq Reduce");
    });
});
Pit.Test.SeqTest.Append = (function() {
    return test("append", function() {
        var s1 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        var s2 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(6)(10));
        var r = Pit.FSharp.Collections.SeqModule.Append(s1)(s2);
        return equal(10, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        })), "Seq Append");
    });
});
Pit.Test.SeqTest.Collect = (function() {
    return test("collect", function() {
        var k = Pit.FSharp.Collections.SeqModule.Collect((function(elem) {
            return Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(0)(elem)));
        }))([1, 5, 10]);
        return equal(19, Pit.FSharp.Core.Operators.op_PipeRight(k)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        })), "Seq Collect");
    });
});
Pit.Test.SeqTest.CompareWith = (function() {
    return test("compare with", function() {
        var s1 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var s2 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_RangeStep(10)(-1)(1));
        var comparer = function(elem1) {
                return function(elem2) {
                    return (function(thisObject) {
                        if (elem1 > elem2) {
                            return 1;
                        } else if (elem1 < elem2) {
                            return -1;
                        } else {
                            return 0;
                        }
                    })(this);
                };
            };
        var compareSequences = function(source1) {
                return (function(source2) {
                    return Pit.FSharp.Collections.SeqModule.CompareWith(comparer)(source1)(source2);
                });
            };
        var compareResult1 = compareSequences(s1)(s2);
        var res = (function(thisObject) {
            if (compareResult1 == -1) {
                return "Sequence1 is less than sequence2.";
            } else if (compareResult1 == 0) {
                return "Sequence1 is equal to sequence2.";
            } else if (compareResult1 == 1) {
                return "Sequence1 is greater than sequence2.";
            } else {
                throw "Invalid comparison result."
            }
        })(this);
        return equal("Sequence1 is less than sequence2.", res, "Seq CompareWith");
    });
});
Pit.Test.SeqTest.Singleton = (function() {
    return test("singleton", function() {
        var res1 = Pit.FSharp.Collections.SeqModule.Singleton(10);
        var i1 = Pit.FSharp.Core.Operators.op_PipeRight(res1)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(0)(source);
        }));
        var i2 = Pit.FSharp.Core.Operators.op_PipeRight(res1)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(0)(source);
        }));
        return equal(i1, i2, "Seq Singleton");
    });
});
Pit.Test.SeqTest.Truncate = (function() {
    return test("truncate", function() {
        var mySeq = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return (i * i);
            }))(Pit.FSharp.Core.Operators.op_Range(1)(10));
        })));
        var truncatedSeq = Pit.FSharp.Collections.SeqModule.Truncate(5)(mySeq);
        return equal(1, Pit.FSharp.Core.Operators.op_PipeRight(truncatedSeq)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(0)(source);
        })), "Seq Truncate");
    });
});
Pit.Test.SeqTest.Take = (function() {
    return test("take", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Take(5)(source);
        }));
        return equal(5, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(4)(source);
        })), "Seq Take");
    });
});
Pit.Test.SeqTest.TakeWhile = (function() {
    return test("take while", function() {
        var mySeq = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return (i * i);
            }))(Pit.FSharp.Core.Operators.op_Range(1)(10));
        })));
        var res = Pit.FSharp.Collections.SeqModule.TakeWhile((function(elem) {
            return elem < 10;
        }))(mySeq);
        return equal(9, Pit.FSharp.Core.Operators.op_PipeRight(res)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(2)(source);
        })), "Seq TakeWhile");
    });
});
Pit.Test.SeqTest.Skip = (function() {
    return test("skip", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Skip(4)(source);
        }));
        return equal(7, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(2)(source);
        })), "Seq Skip");
    });
});
Pit.Test.SeqTest.SkipWhile = (function() {
    return test("skip while", function() {
        var mySeq = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return (i * i);
            }))(Pit.FSharp.Core.Operators.op_Range(1)(10));
        })));
        var res = Pit.FSharp.Core.Operators.op_PipeRight(mySeq)((function(source) {
            return Pit.FSharp.Collections.SeqModule.SkipWhile((function(el) {
                return el < 10;
            }))(source);
        }));
        return equal(36, Pit.FSharp.Core.Operators.op_PipeRight(res)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(2)(source);
        })), "Seq SkipWhile");
    });
});
Pit.Test.SeqTest.PairWise = (function() {
    return test("pair wise", function() {
        var s = Pit.FSharp.Collections.SeqModule.Pairwise(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return (i * i);
            }))(Pit.FSharp.Core.Operators.op_Range(1)(10));
        }))));
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(2)(source);
        }));
        var i2 = patternInput.Item2;
        var i1 = patternInput.Item1;
        equal(i1, 9, "Seq PairWise");
        return equal(i2, 16, "Seq PairWise");
    });
});
Pit.Test.SeqTest.Scan = (function() {
    return test("scan", function() {
        var sumSeq = (function(sequence1) {
            return Pit.FSharp.Collections.SeqModule.Scan(function(acc) {
                return (function(elem) {
                    return (acc + elem);
                });
            })(0)(sequence1);
        });
        var sum = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SeqModule.Initialize(10)((function(index) {
            return (index * index);
        })))(sumSeq);
        return equal(14, Pit.FSharp.Core.Operators.op_PipeRight(sum)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(4)(source);
        })), "Seq Scan");
    });
});
Pit.Test.SeqTest.FindIndex = (function() {
    return test("find index", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var f = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.FindIndex((function(i) {
                return i == 5;
            }))(source);
        }));
        return equal(4, f, "Seq FindIndex");
    });
});
Pit.Test.SeqTest.TryFindIndex = (function() {
    return test("tryfind index", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var matchValue = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.TryFindIndex((function(i) {
                return i == 5;
            }))(source);
        }));
        return (function(thisObject) {
            if (matchValue instanceof Pit.FSharp.Core.FSharpOption1.None) {
                throw "Seq TryFindIndex Failure"
            } else {
                var t = matchValue.get_Value();
                return equal(4, t, "Seq TryFindIndex");
            }
        })(this);
    });
});
Pit.Test.SeqTest.ToList = (function() {
    return test("tolist", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.ToList(source);
        }));
        return equal(5, Pit.FSharp.Collections.ListModule.Get(r)(4), "Seq ToList");
    });
});
Pit.Test.SeqTest.OfList = (function() {
    return test("oflist", function() {
        var l = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10)));
        var s = Pit.FSharp.Core.Operators.op_PipeRight(l)((function(source) {
            return Pit.FSharp.Collections.SeqModule.OfList(source);
        }));
        return equal(2, Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(1)(source);
        })), "Seq OfList");
    });
});
Pit.Test.SeqTest.ToArray = (function() {
    return test("toarray", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var a = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.ToArray(source);
        }));
        return equal(2, a[1], "Seq ToArray");
    });
});
Pit.Test.SeqTest.Sum = (function() {
    return test("sum", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Sum(source);
        }));
        return equal(55, r, "Seq Sum");
    });
});
Pit.Test.SeqTest.SumBy = (function() {
    return test("sumby", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.SumBy((function(x) {
                return (x * x);
            }))(source);
        }));
        return equal(385, r, "Seq SumBy");
    });
});
Pit.Test.SeqTest.Average = (function() {
    return test("average", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Average(source);
        }));
        return equal(5.5, r, "Seq Average");
    });
});
Pit.Test.SeqTest.AverageBy = (function() {
    return test("averageby", function() {
        var avg2 = Pit.FSharp.Collections.SeqModule.AverageBy((function(el) {
            return Pit.FSharp.Core.Operators.ToDouble(el);
        }))(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10)));
        return equal(5.5, avg2, "Seq Average");
    });
});
Pit.Test.SeqTest.Min = (function() {
    return test("min", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Min(source);
        }));
        return equal(1, r, "Seq Min");
    });
});
Pit.Test.SeqTest.MinBy = (function() {
    return test("minby", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(-10)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.MinBy((function(x) {
                return ((x * x) - 1);
            }))(source);
        }));
        return equal(0, r, "Seq MinBy");
    });
});
Pit.Test.SeqTest.Max = (function() {
    return test("max", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Max(source);
        }));
        return equal(10, r, "Seq Max");
    });
});
Pit.Test.SeqTest.MaxBy = (function() {
    return test("maxby", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(-10)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.MaxBy((function(x) {
                return ((x * x) - 1);
            }))(source);
        }));
        return equal(-10, r, "Seq MaxBy");
    });
});
Pit.Test.SeqTest.ForAll2 = (function() {
    return test("forall2", function() {
        var predicate = function(elem1) {
                return (function(elem2) {
                    return elem1 == elem2;
                });
            };
        var allEqual = function(source1) {
                return (function(source2) {
                    return Pit.FSharp.Collections.SeqModule.ForAll2(predicate)(source1)(source2);
                });
            };
        var r1 = allEqual([1, 2])([1, 2]);
        var r2 = allEqual([2, 1])([1, 2]);
        equal(true, r1, "Seq ForAll2");
        return equal(false, r2, "Seq ForAll2");
    });
});
Pit.Test.SeqTest.Exists2 = (function() {
    return test("exists2", function() {
        var s1 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        var s2 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_RangeStep(5)(-1)(1));
        var r = Pit.FSharp.Collections.SeqModule.Exists2(function(i1) {
            return (function(i2) {
                return i1 == i2;
            });
        })(s1)(s2);
        return equal(true, r, "Seq Exists");
    });
});
Pit.Test.SeqTest.Head = (function() {
    return test("head", function() {
        var s1 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s1)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Head(source);
        }));
        return equal(1, r, "Seq Head");
    });
});
Pit.Test.SeqTest.GroupBy = (function() {
    return test("groupby", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var g = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.GroupBy((function(i) {
                return (i % 2) == 0;
            }))(source);
        }));
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(g)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(0)(source);
        }));
        var r1 = patternInput.Item1;
        var i1 = patternInput.Item2;
        var patternInput1 = Pit.FSharp.Core.Operators.op_PipeRight(g)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(1)(source);
        }));
        var r2 = patternInput1.Item1;
        var i2 = patternInput1.Item2;
        return equal(Pit.FSharp.Core.Operators.op_PipeRight(i1)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        })), Pit.FSharp.Core.Operators.op_PipeRight(i2)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        })), "Seq GroupBy");
    });
});
Pit.Test.SeqTest.CountBy = (function() {
    return test("countby", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var g = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.CountBy((function(i) {
                return (i % 2) == 0;
            }))(source);
        }));
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(g)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(0)(source);
        }));
        var r1 = patternInput.Item1;
        var i1 = patternInput.Item2;
        var patternInput1 = Pit.FSharp.Core.Operators.op_PipeRight(g)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(1)(source);
        }));
        var r2 = patternInput1.Item1;
        var i2 = patternInput1.Item2;
        return equal(i1, i2, "Seq CountBy");
    });
});
Pit.Test.SeqTest.Distinct = (function() {
    return test("distinct", function() {
        var s = [1, 1, 2, 2];
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Distinct(source);
        }));
        return equal(2, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        })), "Seq Distinct");
    });
});
Pit.Test.SeqTest.DistinctBy = (function() {
    return test("distinctby", function() {
        var s = Pit.FSharp.Core.Operators.op_Range(-5)(10);
        var r = Pit.FSharp.Collections.SeqModule.DistinctBy((function(elem) {
            return Pit.FSharp.Core.Operators.Abs(elem);
        }))(s);
        return equal(0, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(5)(source);
        })), "Seq DistinctBy");
    });
});
Pit.Test.SeqTest.Sort = (function() {
    return test("sort", function() {
        var s = [10, -2, 4, 9];
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Sort(source);
        }));
        return equal(-2, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(0)(source);
        })), "Seq Sort");
    });
});
Pit.Test.SeqTest.SortBy = (function() {
    return test("sortby", function() {
        var s = [10, -2, 4, 9];
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.SortBy((function(i) {
                return (i % 2) == 0;
            }))(source);
        }));
        return equal(-2, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Get(2)(source);
        })), "Seq SortBy");
    });
});
Pit.Test.SeqTest.Windowed = (function() {
    return test("windowed", function() {
        var s = Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(9)));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Windowed(3)(source);
        }));
        return equal(7, Pit.FSharp.Core.Operators.op_PipeRight(r)((function(source) {
            return Pit.FSharp.Collections.SeqModule.Length(source);
        })), "Seq Windowed");
    });
});
Pit.Test.SeqTest.ReadOnly = (function() {
    return test("readonly", function() {
        var s = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10));
        var r = Pit.FSharp.Core.Operators.op_PipeRight(s)((function(source) {
            return Pit.FSharp.Collections.SeqModule.ReadOnly(source);
        }));
        var e = r.IEnumerable1_GetEnumerator();
        return (function(thisObject) {
            try {
                var m = e.IEnumerator_MoveNext();
                return equal(true, m, "Seq ReadOnly");
            } finally {
                (function(thisObject) {
                    if (Pit.JsCommon.containsInterface(e, "__getIDisposable")) {
                        return e.IDisposable_Dispose();
                    } else {
                        return null;
                    }
                })(thisObject)
            }
        })(this);
    });
});
Pit.Test.SeqTest.run = function() {
    module("Seq Tests");
    Pit.Test.SeqTest.Declare();
    Pit.Test.SeqTest.Initialize();
    Pit.Test.SeqTest.InitializeInfinite();
    Pit.Test.SeqTest.OfArray();
    Pit.Test.SeqTest.Iterate();
    Pit.Test.SeqTest.IterateIndexed();
    Pit.Test.SeqTest.Exists();
    Pit.Test.SeqTest.ForAll();
    Pit.Test.SeqTest.Iterate2();
    Pit.Test.SeqTest.Filter();
    Pit.Test.SeqTest.Map();
    Pit.Test.SeqTest.MapIndexed();
    Pit.Test.SeqTest.Map2();
    Pit.Test.SeqTest.Choose();
    Pit.Test.SeqTest.Zip();
    Pit.Test.SeqTest.Zip3();
    Pit.Test.SeqTest.TryPick();
    Pit.Test.SeqTest.Pick();
    Pit.Test.SeqTest.TryFind();
    Pit.Test.SeqTest.Find();
    Pit.Test.SeqTest.Concat();
    Pit.Test.SeqTest.Length();
    Pit.Test.SeqTest.Fold();
    Pit.Test.SeqTest.Reduce();
    Pit.Test.SeqTest.Append();
    Pit.Test.SeqTest.Collect();
    Pit.Test.SeqTest.CompareWith();
    Pit.Test.SeqTest.Singleton();
    Pit.Test.SeqTest.Truncate();
    Pit.Test.SeqTest.Take();
    Pit.Test.SeqTest.TakeWhile();
    Pit.Test.SeqTest.Skip();
    Pit.Test.SeqTest.SkipWhile();
    Pit.Test.SeqTest.PairWise();
    Pit.Test.SeqTest.Scan();
    Pit.Test.SeqTest.FindIndex();
    Pit.Test.SeqTest.TryFindIndex();
    Pit.Test.SeqTest.ToList();
    Pit.Test.SeqTest.OfList();
    Pit.Test.SeqTest.ToArray();
    Pit.Test.SeqTest.Sum();
    Pit.Test.SeqTest.SumBy();
    Pit.Test.SeqTest.Average();
    Pit.Test.SeqTest.AverageBy();
    Pit.Test.SeqTest.Min();
    Pit.Test.SeqTest.MinBy();
    Pit.Test.SeqTest.Max();
    Pit.Test.SeqTest.MaxBy();
    Pit.Test.SeqTest.ForAll2();
    Pit.Test.SeqTest.Exists2();
    Pit.Test.SeqTest.Head();
    Pit.Test.SeqTest.GroupBy();
    Pit.Test.SeqTest.CountBy();
    Pit.Test.SeqTest.Distinct();
    Pit.Test.SeqTest.DistinctBy();
    Pit.Test.SeqTest.Sort();
    Pit.Test.SeqTest.SortBy();
    Pit.Test.SeqTest.Windowed();
    return Pit.Test.SeqTest.ReadOnly();
};
Pit.Test.ArrayTest.Declare = (function() {
    return test("declare", function() {
        var arr1 = [1, 2, 3];
        return equal(arr1[0], 1, "Declare Array");
    });
});
Pit.Test.ArrayTest.Length = (function() {
    return test("length", function() {
        var array = [1, 2, 3, 4, 5];
        var len = Pit.FSharp.Collections.ArrayModule.Length(array);
        return equal(len, 5, "Array Length");
    });
});
Pit.Test.ArrayTest.DeclareRange = (function() {
    return test("declare range", function() {
        var array = Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return (i * i);
            }))(Pit.FSharp.Core.Operators.op_Range(1)(10));
        }))));
        return equal(array[4], 25, "Declare Array Range");
    });
});
Pit.Test.ArrayTest.ZeroCreate = (function() {
    return test("zero create", function() {
        var array = Pit.FSharp.Collections.ArrayModule.ZeroCreate(10);
        return equal(array[0], 0, "Array Zero Create");
    });
});
Pit.Test.ArrayTest.CreateGetSet = (function() {
    return test("create get set", function() {
        var array1 = Pit.FSharp.Collections.ArrayModule.Create(5)('');
        for (var i = 0; i <= (array1.get_Length() - 1); i++) {
            (function(thisObject, i) {
                Pit.FSharp.Collections.ArrayModule.Set(array1)(i)(i.toString())
            })(this, i);
        };
        return equal(array1[0], Pit.FSharp.Collections.ArrayModule.Get(array1)(0), "Array Create/Get/Set");
    });
});
Pit.Test.ArrayTest.Init = (function() {
    return test("init", function() {
        var array = Pit.FSharp.Collections.ArrayModule.Initialize(5)((function(index) {
            return (index * index);
        }));
        return equal(array[4], 16, "Array Init");
    });
});
Pit.Test.ArrayTest.Copy = (function() {
    return test("copy", function() {
        var array1 = Pit.FSharp.Collections.ArrayModule.Initialize(5)((function(index) {
            return (index * index);
        }));
        var array2 = Pit.FSharp.Collections.ArrayModule.Copy(array1);
        return equal(array1[0], array2[0], "Array Copy");
    });
});
Pit.Test.ArrayTest.Sub = (function() {
    return test("sub", function() {
        var a1 = Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10)));
        var a2 = Pit.FSharp.Collections.ArrayModule.GetSubArray(a1)(2)(6);
        return equal(6, a2.get_Length(), "Array Sub");
    });
});
Pit.Test.ArrayTest.Append = (function() {
    return test("append", function() {
        var m = Pit.FSharp.Collections.ArrayModule.Append([1, 2, 3])([4, 5, 6]);
        return equal(6, m.get_Length(), "Array append");
    });
});
Pit.Test.ArrayTest.Choose = (function() {
    return test("choose", function() {
        var k = Pit.FSharp.Collections.ArrayModule.Choose(function(elem) {
            return (function(thisObject) {
                if ((elem % 2) == 0) {
                    return new Pit.FSharp.Core.FSharpOption1.Some(Pit.FSharp.Core.Operators.ToDouble(((elem * elem) - 1)));
                } else {
                    return new Pit.FSharp.Core.FSharpOption1.None();
                }
            })(this);
        })(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))));
        return equal(k[0], 3, "Array Choose");
    });
});
Pit.Test.ArrayTest.Collect = (function() {
    return test("collect", function() {
        var k = Pit.FSharp.Collections.ArrayModule.Collect((function(elem) {
            return Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(0)(elem)));
        }))([1, 5, 10]);
        return equal(19, k.get_Length(), "Array Collect");
    });
});
Pit.Test.ArrayTest.Concat = (function() {
    return test("concat", function() {
        var multiplicationTable = (function(max) {
            return Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
                return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                    return Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
                        return Pit.FSharp.Collections.SeqModule.Map(function(j) {
                            return {
                                Item1: i,
                                Item2: j,
                                Item3: (i * j)
                            };
                        })(Pit.FSharp.Core.Operators.op_Range(1)(max));
                    }))));
                }))(Pit.FSharp.Core.Operators.op_Range(1)(max));
            })));
        });
        var array = Pit.FSharp.Collections.ArrayModule.Concat(multiplicationTable(3));
        var patternInput = array[3];
        var k = patternInput.Item3;
        var j = patternInput.Item2;
        var i = patternInput.Item1;
        equal(i, 2, "Array Concat - i");
        equal(j, 1, "Array Concat - j");
        return equal(k, 2, "Array Concat - k");
    });
});
Pit.Test.ArrayTest.Filter = (function() {
    return test("filter", function() {
        var k = Pit.FSharp.Collections.ArrayModule.Filter((function(elem) {
            return (elem % 2) == 0;
        }))(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))));
        return equal(k[0], 2, "Array Filter");
    });
});
Pit.Test.ArrayTest.Rev = (function() {
    return test("rev", function() {
        var a = Pit.FSharp.Collections.ArrayModule.Reverse([3, 2, 1]);
        return equal(a[0], 1, "Array Reverse");
    });
});
Pit.Test.ArrayTest.FilterChooseRev = (function() {
    return test("filter choose", function() {
        var a = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))))((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Filter((function(elem) {
                return (elem % 2) == 0;
            }))(array);
        })))((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Choose(function(elem) {
                return (function(thisObject) {
                    if (elem != 8) {
                        return new Pit.FSharp.Core.FSharpOption1.Some((elem * elem));
                    } else {
                        return new Pit.FSharp.Core.FSharpOption1.None();
                    }
                })(this);
            })(array);
        })))((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Reverse(array);
        }));
        return equal(a[0], 100, "Array Filter Choose Reverse");
    });
});
Pit.Test.ArrayTest.Exists1 = (function() {
    return test("exist1", function() {
        var allNegative = Pit.FSharp.Core.Operators.op_ComposeRight((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Exists((function(elem) {
                return Pit.FSharp.Core.Operators.Abs(elem) == elem;
            }))(array);
        }))((function(value) {
            return !value;
        }));
        var res = allNegative([-1, -2, -3]);
        return equal(res, true, "Array Exists Equal");
    });
});
Pit.Test.ArrayTest.Exists2 = (function() {
    return test("exists2", function() {
        var allNegative = Pit.FSharp.Core.Operators.op_ComposeRight((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Exists((function(elem) {
                return Pit.FSharp.Core.Operators.Abs(elem) == elem;
            }))(array);
        }))((function(value) {
            return !value;
        }));
        var res = allNegative([-1, 2, -3]);
        return equal(res, false, "Array Exists Not Equal");
    });
});
Pit.Test.ArrayTest.Exists2Function = (function() {
    return test("exsits2fun", function() {
        var predicate = function(elem1) {
                return (function(elem2) {
                    return elem1 == elem2;
                });
            };
        var haveEqualElement = function(array1) {
                return (function(array2) {
                    return Pit.FSharp.Collections.ArrayModule.Exists2(predicate)(array1)(array2);
                });
            };
        var res = haveEqualElement([1, 2, 3])([3, 2, 1]);
        return equal(res, true, "Array Exists2");
    });
});
Pit.Test.ArrayTest.ForAll = (function() {
    return test("forall", function() {
        var predicate = (function(elem) {
            return elem >= 0;
        });
        var allPositive = (function(array) {
            return Pit.FSharp.Collections.ArrayModule.ForAll(predicate)(array);
        });
        var res = allPositive([0, 1, 2, 3]);
        return equal(res, true, "Array For All");
    });
});
Pit.Test.ArrayTest.ForAll2 = (function() {
    return test("forall2", function() {
        var predicate = function(elem1) {
                return (function(elem2) {
                    return elem1 == elem2;
                });
            };
        var allEqual = function(array1) {
                return (function(array2) {
                    return Pit.FSharp.Collections.ArrayModule.ForAll2(predicate)(array1)(array2);
                });
            };
        var res = allEqual([1, 2])([1, 2]);
        return equal(res, true, "Array ForAll2");
    });
});
Pit.Test.ArrayTest.FindAndFindIndex = (function() {
    return test("findindex", function() {
        var a1 = Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10)));
        var i = Pit.FSharp.Core.Operators.op_PipeRight(a1)((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Find((function(a) {
                return a == 5;
            }))(array);
        }));
        equal(5, i, "Array Find");
        var i2 = Pit.FSharp.Core.Operators.op_PipeRight(a1)((function(array) {
            return Pit.FSharp.Collections.ArrayModule.FindIndex((function(a) {
                return a == 5;
            }))(array);
        }));
        return equal(4, i2, "Array Find");
    });
});
Pit.Test.ArrayTest.TryFind = (function() {
    return test("tryfind", function() {
        var array = Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10)));
        var item = Pit.FSharp.Core.Operators.op_PipeRight(array)((function(array1) {
            return Pit.FSharp.Collections.ArrayModule.TryFind((function(i) {
                return i == 2;
            }))(array1);
        }));
        return (function(thisObject) {
            if (item instanceof Pit.FSharp.Core.FSharpOption1.None) {
                throw "Item Not Found"
            } else {
                var i = item.get_Value();
                return equal(i, 2, "Array Try Find");
            }
        })(this);
    });
});
Pit.Test.ArrayTest.Fill = (function() {
    return test("fill", function() {
        var arrayFill1 = Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10)));
        Pit.FSharp.Collections.ArrayModule.Fill(arrayFill1)(3)(5)(0);
        return equal(arrayFill1[3], 0, "Array Fill");
    });
});
Pit.Test.ArrayTest.Iterate = (function() {
    return test("iterate", function() {
        var array = [1];
        return Pit.FSharp.Core.Operators.op_PipeRight(array)((function(array1) {
            return Pit.FSharp.Collections.ArrayModule.Iterate((function(i) {
                return equal(i, 1, "Array Iterate");
            }))(array1);
        }));
    });
});
Pit.Test.ArrayTest.IterateIndexed = (function() {
    return test("Iterate Indexed", function() {
        var array = [1, 2];
        var array2 = [1, 2];
        return Pit.FSharp.Core.Operators.op_PipeRight(array)((function(array1) {
            return Pit.FSharp.Collections.ArrayModule.IterateIndexed(function(idx) {
                return (function(i) {
                    return equal(i, array2[idx], "Array Iterate Indexed");
                });
            })(array1);
        }));
    });
});
Pit.Test.ArrayTest.IterateIndexed2 = (function() {
    return test("Iterate Indexed2", function() {
        var array = [1];
        var array2 = [3];
        return Pit.FSharp.Core.Operators.op_PipeRight(array2)((function(array21) {
            return Pit.FSharp.Collections.ArrayModule.IterateIndexed2(function(idx) {
                return function(i1) {
                    return function(i2) {
                        equal(i1, 1, "Array Iterate Indexed2");
                        return equal(i2, 3, "Array Iterate Indexed2");
                    };
                };
            })(array)(array21);
        }));
    });
});
Pit.Test.ArrayTest.Map = (function() {
    return test("Map", function() {
        var array = [1, 2];
        var array2 = Pit.FSharp.Core.Operators.op_PipeRight(array)((function(array1) {
            return Pit.FSharp.Collections.ArrayModule.Map((function(i) {
                return (i + i);
            }))(array1);
        }));
        return equal(array2[1], 4, "Array Map");
    });
});
Pit.Test.ArrayTest.MapIndexed = (function() {
    return test("MapIndexed", function() {
        var array = [1, 2];
        var array2 = Pit.FSharp.Core.Operators.op_PipeRight(array)((function(array1) {
            return Pit.FSharp.Collections.ArrayModule.MapIndexed(function(idx) {
                return (function(i) {
                    return (idx + i);
                });
            })(array1);
        }));
        return equal(array2[1], 3, "Array MapIndexed");
    });
});
Pit.Test.ArrayTest.Map2 = (function() {
    return test("map2", function() {
        var array = [1, 2];
        var array2 = [3, 4];
        var resultArray = Pit.FSharp.Core.Operators.op_PipeRight(array2)((function(array21) {
            return Pit.FSharp.Collections.ArrayModule.Map2(function(i1) {
                return (function(i2) {
                    return (i1 + i2);
                });
            })(array)(array21);
        }));
        return equal(resultArray[1], 6, "Array Map2");
    });
});
Pit.Test.ArrayTest.MapIndexed2 = (function() {
    return test("map indexed2", function() {
        var array = [1, 2];
        var array2 = [3, 4];
        var resultArray = Pit.FSharp.Core.Operators.op_PipeRight(array2)((function(array21) {
            return Pit.FSharp.Collections.ArrayModule.MapIndexed2(function(idx) {
                return function(i1) {
                    return (function(i2) {
                        return ((idx + i1) + i2);
                    });
                };
            })(array)(array21);
        }));
        return equal(resultArray[1], 7, "Array MapIndexed2");
    });
});
Pit.Test.ArrayTest.Pick = (function() {
    return test("pick", function() {
        var values = [{
            Item1: "a",
            Item2: 1
        }, {
            Item1: "b",
            Item2: 2
        }, {
            Item1: "c",
            Item2: 3
        }];
        var resultPick = Pit.FSharp.Collections.ArrayModule.Pick(function(elem) {
            return (function(thisObject) {
                if (elem.Item2 == 2) {
                    var value = elem.Item1;
                    return new Pit.FSharp.Core.FSharpOption1.Some(value);
                } else {
                    return new Pit.FSharp.Core.FSharpOption1.None();
                }
            })(this);
        })(values);
        return equal("b", resultPick, "Array Pick");
    });
});
Pit.Test.ArrayTest.TryPick = (function() {
    return test("try pick", function() {
        var values = [{
            Item1: "a",
            Item2: 1
        }, {
            Item1: "b",
            Item2: 2
        }, {
            Item1: "c",
            Item2: 3
        }];
        var resultPick = Pit.FSharp.Collections.ArrayModule.TryPick(function(elem) {
            return (function(thisObject) {
                if (elem.Item2 == 2) {
                    var value = elem.Item1;
                    return new Pit.FSharp.Core.FSharpOption1.Some(value);
                } else {
                    return new Pit.FSharp.Core.FSharpOption1.None();
                }
            })(this);
        })(values);
        return (function(thisObject) {
            if (resultPick instanceof Pit.FSharp.Core.FSharpOption1.None) {
                throw "TryPick failed"
            } else {
                var t = resultPick.get_Value();
                return equal("b", t, "Array TryPick");
            }
        })(this);
    });
});
Pit.Test.ArrayTest.Partition = (function() {
    return test("partition", function() {
        var array = [-2, -1, 1, 2];
        var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(array)((function(array1) {
            return Pit.FSharp.Collections.ArrayModule.Partition((function(t) {
                return t < 0;
            }))(array1);
        }));
        var p = patternInput.Item2;
        var n = patternInput.Item1;
        return equal(2, n.get_Length(), "Array Partition");
    });
});
Pit.Test.ArrayTest.Zip = (function() {
    return test("zip", function() {
        var array1 = [1, 2, 3];
        var array2 = [-1, -2, -3];
        var arrayZip = Pit.FSharp.Collections.ArrayModule.Zip(array1)(array2);
        var patternInput = Pit.FSharp.Collections.ArrayModule.Get(arrayZip)(1);
        var item2 = patternInput.Item2;
        var item1 = patternInput.Item1;
        equal(2, item1, "Array Zip");
        return equal(-2, item2, "Array Zip");
    });
});
Pit.Test.ArrayTest.Zip3 = (function() {
    return test("zip3", function() {
        var array1 = [1, 2, 3];
        var array2 = [-1, -2, -3];
        var array3 = [-1, -2, -3];
        var arrayZip = Pit.FSharp.Collections.ArrayModule.Zip3(array1)(array2)(array3);
        var patternInput = Pit.FSharp.Collections.ArrayModule.Get(arrayZip)(1);
        var item3 = patternInput.Item3;
        var item2 = patternInput.Item2;
        var item1 = patternInput.Item1;
        equal(2, item1, "Array Zip3");
        equal(-2, item2, "Array Zip3");
        return equal(-2, item3, "Array Zip3");
    });
});
Pit.Test.ArrayTest.Unzip = (function() {
    return test("unzip", function() {
        var patternInput = Pit.FSharp.Collections.ArrayModule.Unzip([{
            Item1: 1,
            Item2: 2
        }, {
            Item1: 3,
            Item2: 4
        }]);
        var array2 = patternInput.Item2;
        var array1 = patternInput.Item1;
        equal(2, array1.get_Length(), "Array Unzip");
        return equal(2, array2.get_Length(), "Array Unzip");
    });
});
Pit.Test.ArrayTest.Unzip3 = (function() {
    return test("unzip3", function() {
        var patternInput = Pit.FSharp.Collections.ArrayModule.Unzip3([{
            Item1: 1,
            Item2: 2,
            Item3: 3
        }, {
            Item1: 3,
            Item2: 4,
            Item3: 3
        }]);
        var array3 = patternInput.Item3;
        var array2 = patternInput.Item2;
        var array1 = patternInput.Item1;
        equal(2, array1.get_Length(), "Array Unzip3");
        equal(2, array2.get_Length(), "Array Unzip3");
        return equal(2, array3.get_Length(), "Array Unzip3");
    });
});
Pit.Test.ArrayTest.Fold = (function() {
    return test("fold", function() {
        var sumArray = (function(array) {
            return Pit.FSharp.Collections.ArrayModule.Fold(function(acc) {
                return (function(elem) {
                    return (acc + elem);
                });
            })(0)(array);
        });
        var a = [1, 2, 3];
        var res = sumArray(a);
        return equal(6, res, "Array Fold");
    });
});
Pit.Test.ArrayTest.FoldBack = (function() {
    return test("foldback", function() {
        var subtractArrayBack = (function(array1) {
            return Pit.FSharp.Collections.ArrayModule.FoldBack(function(elem) {
                return (function(acc) {
                    return (elem - acc);
                });
            })(array1)(0);
        });
        var a = [1, 2, 3];
        var res = subtractArrayBack(a);
        return equal(2, res, "Array FoldBack");
    });
});
Pit.Test.ArrayTest.Fold2 = (function() {
    return test("fold2", function() {
        var sumGreatest = function(array1) {
                return (function(array2) {
                    return Pit.FSharp.Collections.ArrayModule.Fold2(function(acc) {
                        return function(elem1) {
                            return (function(elem2) {
                                return (acc + Pit.FSharp.Core.Operators.Max(elem1)(elem2));
                            });
                        };
                    })(0)(array1)(array2);
                });
            };
        var sum = sumGreatest([1, 2, 3])([3, 2, 1]);
        return equal(8, sum, "Array Fold2");
    });
});
Pit.Test.ArrayTest.FoldBack2 = (function() {
    return test("fold back2", function() {
        var subtractArrayBack = function(array1) {
                return (function(array2) {
                    return Pit.FSharp.Collections.ArrayModule.FoldBack2(function(elem) {
                        return function(acc1) {
                            return (function(acc2) {
                                return (elem - (acc1 - acc2));
                            });
                        };
                    })(array1)(array2)(0);
                });
            };
        var a1 = [1, 2, 3];
        var a2 = [4, 5, 6];
        var res = subtractArrayBack(a1)(a2);
        return equal(-9, res, "Array FoldBack2");
    });
});
Pit.Test.ArrayTest.Scan = (function() {
    return test("scan", function() {
        var initialBalance = 1122.73;
        var transactions = [-100, 450.34, -62.34, -127, -13.5, -12.92];
        var balances = Pit.FSharp.Collections.ArrayModule.Scan(function(balance) {
            return (function(transactionAmount) {
                return (balance + transactionAmount);
            });
        })(initialBalance)(transactions);
        return equal(1022.73, balances[1], "Array Scan");
    });
});
Pit.Test.ArrayTest.ScanBack = (function() {
    return test("scan back", function() {
        var subtractArrayBack = (function(array1) {
            return Pit.FSharp.Collections.ArrayModule.ScanBack(function(elem) {
                return (function(acc) {
                    return (elem - acc);
                });
            })(array1)(0);
        });
        var a = [1, 2, 3];
        var res = subtractArrayBack(a);
        return equal(2, res[0], "Array ScanBack");
    });
});
Pit.Test.ArrayTest.Reduce = (function() {
    return test("reduce", function() {
        var names = ["A", "man", "landed", "on", "the", "moon"];
        var sentence = Pit.FSharp.Core.Operators.op_PipeRight(names)((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Reduce(function(acc) {
                return (function(item) {
                    return ((acc + " ") + item);
                });
            })(array);
        }));
        return equal(sentence, "A man landed on the moon", "Array Reduce");
    });
});
Pit.Test.ArrayTest.ReduceBack = (function() {
    return test("reduce back", function() {
        var res = Pit.FSharp.Collections.ArrayModule.ReduceBack(function(elem) {
            return (function(acc) {
                return (elem - acc);
            });
        })([1, 2, 3, 4]);
        return equal(res, -2, "Array Reduce Back");
    });
});
Pit.Test.ArrayTest.SortInPlace = (function() {
    return test("sort in place", function() {
        var array = [10, 2, 4, 1];
        Pit.FSharp.Collections.ArrayModule.SortInPlace(array);
        return equal(1, array[0], "Array SortInPlace");
    });
});
Pit.Test.ArrayTest.SortInPlaceBy = (function() {
    return test("sort in place by", function() {
        var array1 = [1, 4, 8, -2, 5];
        Pit.FSharp.Collections.ArrayModule.SortInPlaceBy((function(elem) {
            return Pit.FSharp.Core.Operators.Abs(elem);
        }))(array1);
        return equal(1, array1[0], "Array SortInPlaceBy");
    });
});
Pit.Test.ArrayTest.SortInPlaceWith = (function() {
    return test("sort in place with", function() {
        var array1 = [1, 4, 8, -2, 5];
        Pit.FSharp.Collections.ArrayModule.SortInPlaceWith(function(e1) {
            return (function(e2) {
                return (e1 - e2);
            });
        })(array1);
        return equal(-2, array1[0], "Array SortInPlaceWith");
    });
});
Pit.Test.ArrayTest.SortWith = (function() {
    return test("sort with", function() {
        var array1 = [1, 4, 8, -2, 5];
        var array2 = Pit.FSharp.Collections.ArrayModule.SortWith(function(e1) {
            return (function(e2) {
                return (e1 - e2);
            });
        })(array1);
        return equal(-2, array2[0], "Array SortWith");
    });
});
Pit.Test.ArrayTest.Sort = (function() {
    return test("sort", function() {
        var array1 = [1, 4, 8, -2, 5];
        var array2 = Pit.FSharp.Collections.ArrayModule.Sort(array1);
        return equal(-2, array2[0], "Array Sort");
    });
});
Pit.Test.ArrayTest.Sort2 = (function() {
    return test("sort2", function() {
        var array1 = ["Womciw", "Beosudo", "Guyx", "Rouh", "Iibow", "Tae", "Ebiucly", "Gonumaf", "Hiowvivb"];
        var array2 = ["Pye", "Gyhsy", "Lhfi", "Ouqilfo", "Ymukoed", "Nhap", "Aguccet", "Hahd", "Debcok"];
        var names = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.ArrayModule.Zip(array1)(array2))((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Map(function(tupledArg) {
                var f = tupledArg.Item1;
                var s = tupledArg.Item2;
                return ((f + " ") + s);
            })(array);
        })))((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Sort(array);
        }));
        return equal("Iibow Ymukoed", names[5], "Array Sort2");
    });
});
Pit.Test.ArrayTest.Permute = (function() {
    return test("permute", function() {
        var array1 = [1, 2, 3, 4, 5];
        var n = array1.get_Length();
        var permute = Pit.FSharp.Collections.ArrayModule.Permute((function(idx) {
            return (idx % n);
        }))(array1);
        return equal(1, permute[0], "Array Permute");
    });
});
Pit.Test.ArrayTest.Sum = (function() {
    return test("sum", function() {
        var a = [1, 2, 3, 4, 5];
        var s = Pit.FSharp.Collections.ArrayModule.Sum(a);
        return equal(s, 15, "Array Sum");
    });
});
Pit.Test.ArrayTest.SumBy = (function() {
    return test("sumby", function() {
        var s = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))))((function(array) {
            return Pit.FSharp.Collections.ArrayModule.SumBy((function(x) {
                return (x * x);
            }))(array);
        }));
        return equal(385, s, "Array Sumby");
    });
});
Pit.Test.ArrayTest.Min = (function() {
    return test("min", function() {
        var a = [1, 2, 3, 4];
        var s = Pit.FSharp.Collections.ArrayModule.Min(a);
        return equal(1, s, "Array Min");
    });
});
Pit.Test.ArrayTest.Max = (function() {
    return test("max", function() {
        var a = [1, 2, 3, 4];
        var s = Pit.FSharp.Collections.ArrayModule.Max(a);
        return equal(4, s, "Array Max");
    });
});
Pit.Test.ArrayTest.MinBy = (function() {
    return test("minby", function() {
        var r = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(-10)(10))))((function(array) {
            return Pit.FSharp.Collections.ArrayModule.MinBy((function(x) {
                return ((x * x) - 1);
            }))(array);
        }));
        return equal(0, r, "Array MinBy");
    });
});
Pit.Test.ArrayTest.MaxBy = (function() {
    return test("maxby", function() {
        var r = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(-10)(10))))((function(array) {
            return Pit.FSharp.Collections.ArrayModule.MaxBy((function(x) {
                return ((x * x) - 1);
            }))(array);
        }));
        return equal(-10, r, "Array MaxBy");
    });
});
Pit.Test.ArrayTest.Average = (function() {
    return test("average", function() {
        var r = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))))((function(array) {
            return Pit.FSharp.Collections.ArrayModule.Average(array);
        }));
        return equal(5.5, r, "Array Average");
    });
});
Pit.Test.ArrayTest.AverageBy = (function() {
    return test("avgby", function() {
        var avg2 = Pit.FSharp.Collections.ArrayModule.AverageBy((function(elem) {
            return Pit.FSharp.Core.Operators.ToDouble(elem);
        }))(Pit.FSharp.Collections.SeqModule.ToArray(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(10))));
        return equal(5.5, avg2, "Array AverageBy");
    });
});
Pit.Test.ArrayTest.ToList = (function() {
    return test("tolist", function() {
        var array = [1, 2, 3];
        var list = Pit.FSharp.Collections.ArrayModule.ToList(array);
        return equal(1, list.get_Head(), "Array ToList");
    });
});
Pit.Test.ArrayTest.OfList = (function() {
    return test("oflist", function() {
        var list = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3]);
        var a = Pit.FSharp.Collections.ArrayModule.OfList(list);
        return equal(1, a[0], "Array OfList");
    });
});
Pit.Test.ArrayTest.ToSeq = (function() {
    return test("toseq", function() {
        var a = [1, 2, 3];
        var sequence = Pit.FSharp.Collections.ArrayModule.ToSeq(a);
        var e = sequence.IEnumerable1_GetEnumerator();
        return (function(thisObject) {
            try {
                Pit.FSharp.Core.Operators.op_PipeRight(e.IEnumerator_MoveNext())((function(value) {
                    return Pit.FSharp.Core.Operators.Ignore(value);
                }));
                return equal(1, e.IEnumerator1_get_Current(), "Array ToSeq");
            } finally {
                (function(thisObject) {
                    if (Pit.JsCommon.containsInterface(e, "__getIDisposable")) {
                        return e.IDisposable_Dispose();
                    } else {
                        return null;
                    }
                })(thisObject)
            }
        })(this);
    });
});
Pit.Test.ArrayTest.OfSeq = (function() {
    return test("ofseq", function() {
        var sequence = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5));
        var array = Pit.FSharp.Collections.ArrayModule.OfSeq(sequence);
        return equal(1, array[0], "Array OfSeq");
    });
});
Pit.Test.ArrayTest.run = function() {
    module("Array tests");
    Pit.Test.ArrayTest.Declare();
    Pit.Test.ArrayTest.Length();
    Pit.Test.ArrayTest.DeclareRange();
    Pit.Test.ArrayTest.ZeroCreate();
    Pit.Test.ArrayTest.CreateGetSet();
    Pit.Test.ArrayTest.Init();
    Pit.Test.ArrayTest.Copy();
    Pit.Test.ArrayTest.Sub();
    Pit.Test.ArrayTest.Append();
    Pit.Test.ArrayTest.Choose();
    Pit.Test.ArrayTest.Collect();
    Pit.Test.ArrayTest.Concat();
    Pit.Test.ArrayTest.Filter();
    Pit.Test.ArrayTest.Rev();
    Pit.Test.ArrayTest.FilterChooseRev();
    Pit.Test.ArrayTest.Exists1();
    Pit.Test.ArrayTest.Exists2();
    Pit.Test.ArrayTest.Exists2Function();
    Pit.Test.ArrayTest.ForAll();
    Pit.Test.ArrayTest.ForAll2();
    Pit.Test.ArrayTest.FindAndFindIndex();
    Pit.Test.ArrayTest.TryFind();
    Pit.Test.ArrayTest.Fill();
    Pit.Test.ArrayTest.Iterate();
    Pit.Test.ArrayTest.IterateIndexed();
    Pit.Test.ArrayTest.IterateIndexed2();
    Pit.Test.ArrayTest.Map();
    Pit.Test.ArrayTest.MapIndexed();
    Pit.Test.ArrayTest.Map2();
    Pit.Test.ArrayTest.MapIndexed2();
    Pit.Test.ArrayTest.Pick();
    Pit.Test.ArrayTest.TryPick();
    Pit.Test.ArrayTest.Partition();
    Pit.Test.ArrayTest.Zip();
    Pit.Test.ArrayTest.Zip3();
    Pit.Test.ArrayTest.Unzip();
    Pit.Test.ArrayTest.Unzip3();
    Pit.Test.ArrayTest.Fold();
    Pit.Test.ArrayTest.FoldBack();
    Pit.Test.ArrayTest.Fold2();
    Pit.Test.ArrayTest.FoldBack2();
    Pit.Test.ArrayTest.Scan();
    Pit.Test.ArrayTest.ScanBack();
    Pit.Test.ArrayTest.Reduce();
    Pit.Test.ArrayTest.ReduceBack();
    Pit.Test.ArrayTest.SortInPlace();
    Pit.Test.ArrayTest.SortInPlaceBy();
    Pit.Test.ArrayTest.SortInPlaceWith();
    Pit.Test.ArrayTest.SortWith();
    Pit.Test.ArrayTest.Sort();
    Pit.Test.ArrayTest.Sort2();
    Pit.Test.ArrayTest.Permute();
    Pit.Test.ArrayTest.Sum();
    Pit.Test.ArrayTest.SumBy();
    Pit.Test.ArrayTest.Min();
    Pit.Test.ArrayTest.Max();
    Pit.Test.ArrayTest.MinBy();
    Pit.Test.ArrayTest.MaxBy();
    Pit.Test.ArrayTest.Average();
    Pit.Test.ArrayTest.AverageBy();
    Pit.Test.ArrayTest.ToList();
    Pit.Test.ArrayTest.OfList();
    Pit.Test.ArrayTest.ToSeq();
    return Pit.Test.ArrayTest.OfSeq();
};
Pit.Test.Array2DTest.Init = function() {
    var arr = Pit.FSharp.Collections.Array2DModule.Initialize(2)(2)(function(i) {
        return (function(j) {
            return (i + j);
        });
    });
    var r = Pit.FSharp.Collections.Array2DModule.Get(arr)(1)(1);
    return equal(r, 2, "Array2D Init");
};
Pit.Test.Array2DTest.Length1 = function() {
    var arr = Pit.FSharp.Collections.Array2DModule.Initialize(2)(2)(function(i) {
        return (function(j) {
            return (i + j);
        });
    });
    var len1 = Pit.FSharp.Core.Operators.op_PipeRight(arr)((function(array) {
        return Pit.FSharp.Collections.Array2DModule.Length1(array);
    }));
    return equal(len1, 2, "Array2D Length1");
};
Pit.Test.Array2DTest.Length2 = function() {
    var arr = Pit.FSharp.Collections.Array2DModule.Initialize(2)(2)(function(i) {
        return (function(j) {
            return (i + j);
        });
    });
    var len1 = Pit.FSharp.Core.Operators.op_PipeRight(arr)((function(array) {
        return Pit.FSharp.Collections.Array2DModule.Length2(array);
    }));
    return equal(len1, 2, "Array2D Length2");
};
Pit.Test.Array2DTest.GetSet = function() {
    var arr = Pit.FSharp.Collections.Array2DModule.Initialize(2)(2)(function(i) {
        return (function(j) {
            return (i + j);
        });
    });
    Pit.FSharp.Collections.Array2DModule.Set(arr)(1)(0)(3);
    var r = Pit.FSharp.Collections.Array2DModule.Get(arr)(1)(0);
    return equal(r, 3, "Array2D GetSet");
};
Pit.Test.Array2DTest.ZeroCreate = function() {
    var arr = Pit.FSharp.Collections.Array2DModule.ZeroCreate(2)(2);
    var r = Pit.FSharp.Collections.Array2DModule.Get(arr)(1)(1);
    return equal(r, 0, "Array2D ZeroCreate");
};
Pit.Test.Array2DTest.Iter = function() {
    var arr = Pit.FSharp.Collections.Array2DModule.ZeroCreate(2)(2);
    var r = Pit.FSharp.Collections.Array2DModule.Length1(arr);
    equal(r, 2, "Array2D Iter");
    return Pit.FSharp.Core.Operators.op_PipeRight(arr)((function(array) {
        return Pit.FSharp.Collections.Array2DModule.Iterate((function(i) {
            return equal(i, 0, "Array2D Iter");
        }))(array);
    }));
};
Pit.Test.Array2DTest.IterateIndex = function() {
    var arr = Pit.FSharp.Collections.Array2DModule.Initialize(2)(2)(function(i) {
        return (function(j) {
            return (i + j);
        });
    });
    return Pit.FSharp.Core.Operators.op_PipeRight(arr)((function(array) {
        return Pit.FSharp.Collections.Array2DModule.IterateIndexed(function(i) {
            return function(j) {
                return (function(x) {
                    return equal((i + j), x, "Array2D IterateIndex");
                });
            };
        })(array);
    }));
};
Pit.Test.Array2DTest.Map = function() {
    var arr = Pit.FSharp.Collections.Array2DModule.ZeroCreate(2)(2);
    return Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(arr)((function(array) {
        return Pit.FSharp.Collections.Array2DModule.Map(function(i) {
            return 1;
        })(array);
    })))((function(array) {
        return Pit.FSharp.Collections.Array2DModule.Iterate((function(i) {
            return equal(i, 1, "Array2D Iter");
        }))(array);
    }));
};
Pit.Test.Array2DTest.MapIndexed = function() {
    var arr = Pit.FSharp.Collections.Array2DModule.ZeroCreate(2)(2);
    return Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(arr)((function(array) {
        return Pit.FSharp.Collections.Array2DModule.MapIndexed(function(i) {
            return function(j) {
                return (function(x) {
                    return (i + j);
                });
            };
        })(array);
    })))((function(array) {
        return Pit.FSharp.Collections.Array2DModule.IterateIndexed(function(i) {
            return function(j) {
                return (function(x) {
                    return equal((i + j), x, "Array2D IterateIndex");
                });
            };
        })(array);
    }));
};
Pit.Test.Array2DTest.run = function() {
    module("Array2D");
    Pit.Test.Array2DTest.Init();
    Pit.Test.Array2DTest.Length1();
    Pit.Test.Array2DTest.Length2();
    Pit.Test.Array2DTest.GetSet();
    Pit.Test.Array2DTest.ZeroCreate();
    Pit.Test.Array2DTest.Iter();
    Pit.Test.Array2DTest.IterateIndex();
    Pit.Test.Array2DTest.Map();
    return Pit.Test.Array2DTest.MapIndexed();
};
