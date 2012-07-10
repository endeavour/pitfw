registerNamespace("Pit.Test.ActivePatternsTest");
registerNamespace("Pit.Test.RangeEnumeratorTests");
registerNamespace("Pit.Test.UOMTest");
registerNamespace("Pit.Test.OperatorOverloadTests");
registerNamespace("Pit.Test.OverloadedCtorsTests");
registerNamespace("Pit.Test.TryWithTests");
registerNamespace("Pit.Test.WhileTests");
registerNamespace("Pit.Test.UnionTests");
registerNamespace("Pit.Test.TupleTests");
registerNamespace("Pit.Test.RecordsTests");
registerNamespace("Pit.Test.PatternTests");
registerNamespace("Pit.Test.LetTests");
registerNamespace("Pit.Test.ForTests");
registerNamespace("Pit.Test.DelegateTests");
Pit.Test.ActivePatternsTest.EvenOdd = function(input) {
    return (function(thisObject) {
        if ((input % 2) == 0) {
            return new Pit.FSharp.Core.FSharpChoice2.Choice1Of2(null);
        } else {
            return new Pit.FSharp.Core.FSharpChoice2.Choice2Of2(null);
        }
    })(this);
};
Pit.Test.ActivePatternsTest.isEven = function(input) {
    var activePatternResult = Pit.Test.ActivePatternsTest.EvenOdd(input);
    return (function(thisObject) {
        if (activePatternResult instanceof Pit.FSharp.Core.FSharpChoice2.Choice2Of2) {
            return false;
        } else {
            return true;
        }
    })(this);
};
Pit.Test.ActivePatternsTest.ActivePatterns = (function() {
    return test("active patterns", function() {
        var res = Pit.Test.ActivePatternsTest.isEven(2);
        return equal(true, res, "Active Pattern");
    });
});
Pit.Test.ActivePatternsTest.get_err = 1E-10;
Pit.Test.ActivePatternsTest.floatequal = function(x) {
    return (function(y) {
        return Pit.FSharp.Core.Operators.Abs((x - y)) < Pit.Test.ActivePatternsTest.get_err;
    });
};
Pit.Test.ActivePatternsTest.Square_ = function(x) {
    return (function(thisObject) {
        if (Pit.Test.ActivePatternsTest.floatequal(Pit.FSharp.Core.Operators.Sqrt(Pit.FSharp.Core.Operators.ToDouble(x)))(Pit.FSharp.Core.Operators.Round(Pit.FSharp.Core.Operators.Sqrt(Pit.FSharp.Core.Operators.ToDouble(x))))) {
            return new Pit.FSharp.Core.FSharpOption1.Some(x);
        } else {
            return new Pit.FSharp.Core.FSharpOption1.None();
        }
    })(this);
};
Pit.Test.ActivePatternsTest.Cube_ = function(x) {
    return (function(thisObject) {
        if (Pit.Test.ActivePatternsTest.floatequal(Pit.FSharp.Core.Operators.op_Exponentiation(Pit.FSharp.Core.Operators.ToDouble(x))((1 / 3)))(Pit.FSharp.Core.Operators.Round(Pit.FSharp.Core.Operators.op_Exponentiation(Pit.FSharp.Core.Operators.ToDouble(x))((1 / 3))))) {
            return new Pit.FSharp.Core.FSharpOption1.Some(x);
        } else {
            return new Pit.FSharp.Core.FSharpOption1.None();
        }
    })(this);
};
Pit.Test.ActivePatternsTest.findSquareCubes = function(x) {
    return (function() {
        if ((function() {
            return (function(thisObject) {
                var activePatternResult = Pit.Test.ActivePatternsTest.Cube_(x);
                if ((function(thisObject) {
                    if (activePatternResult instanceof Pit.FSharp.Core.FSharpOption1.Some) {
                        var x1 = activePatternResult.get_Value();
                        return true;
                    } else {
                        return false;
                    }
                })(this)) {
                    var activePatternResult = Pit.Test.ActivePatternsTest.Square_(x);
                    return (function(thisObject) {
                        if (activePatternResult instanceof Pit.FSharp.Core.FSharpOption1.Some) {
                            var x1 = activePatternResult.get_Value();
                            return true;
                        } else {
                            return false;
                        }
                    })(this);
                } else {
                    return false;
                };
            })(this);
        })()) {
            return equal(64, x, "Partial Active Patterns");
        } else {
            return null;
        };
    })();
};
Pit.Test.ActivePatternsTest.PartialActivePatterns = (function() {
    return test("partial active patterns", (function() {
        return Pit.Test.ActivePatternsTest.findSquareCubes(64);
    }));
});
Pit.Test.ActivePatternsTest.run = function() {
    Pit.Test.ActivePatternsTest.ActivePatterns();
    return Pit.Test.ActivePatternsTest.PartialActivePatterns();
};
Pit.Test.RangeEnumeratorTests.Increment = (function() {
    return test("increment", function() {
        var s = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_Range(1)(5)))((function(source) {
            return Pit.FSharp.Collections.ArrayModule.OfSeq(source);
        }));
        return equal(5, s[4], "Range Increment");
    });
});
Pit.Test.RangeEnumeratorTests.Decrement = (function() {
    return test("decrement", function() {
        var s = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_RangeStep(5)(-1)(1)))((function(source) {
            return Pit.FSharp.Collections.ArrayModule.OfSeq(source);
        }));
        return equal(1, s[4], "Range Decrement");
    });
});
Pit.Test.RangeEnumeratorTests.IncrementTwoWay = (function() {
    return test("increment two way", function() {
        var s = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_RangeStep(2)(2)(5)))((function(source) {
            return Pit.FSharp.Collections.ArrayModule.OfSeq(source);
        }));
        return equal(4, s[1], "Range Increment 2 Way");
    });
});
Pit.Test.RangeEnumeratorTests.NestedRanges = (function() {
    return test("nested ranges", function() {
        var s = Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(i) {
                return Pit.FSharp.Collections.ArrayModule.OfList(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Core.Operators.op_RangeStep(i)(i)(5))));
            }))(Pit.FSharp.Core.Operators.op_Range(2)(5));
        }))))((function(source) {
            return Pit.FSharp.Collections.SeqModule.ToArray(source);
        }));
        var len = s.get_Length();
        equal(4, len, "Range Nested Length");
        return equal(5, s[3][0], "Range Nested Value");
    });
});
Pit.Test.RangeEnumeratorTests.run = function() {
    module("Range Enumerator Tests");
    Pit.Test.RangeEnumeratorTests.Increment();
    Pit.Test.RangeEnumeratorTests.Decrement();
    Pit.Test.RangeEnumeratorTests.IncrementTwoWay();
    return Pit.Test.RangeEnumeratorTests.NestedRanges();
};
registerNamespace("Pit.Test");
Pit.Test.UOMTest.C = (function() {
    function C() {}
    return C;
})();
Pit.Test.UOMTest.F = (function() {
    function F() {}
    return F;
})();
Pit.Test.UOMTest.m = (function() {
    function m() {}
    return m;
})();
Pit.Test.UOMTest.kg = (function() {
    function kg() {}
    return kg;
})();
Pit.Test.UOMTest.to_farenheit = (function(x) {
    return ((x * (9 / 5)) + 32);
});
Pit.Test.UOMTest.to_celsius = (function(x) {
    return ((x - 32) * (5 / 9));
});
Pit.Test.UOMTest.UOMeasure1 = (function() {
    return test("UOM 1", function() {
        var f = Pit.Test.UOMTest.to_farenheit(20);
        return equal(68, f, "Units Of Measure To Farenheit");
    });
});
Pit.Test.UOMTest.get_vanillaFloats = Pit.FSharp.Collections.ListModule.OfArray([10, 15.5, 17]);
Pit.Test.UOMTest.get_lengths = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
    return Pit.FSharp.Collections.SeqModule.Map((function(a) {
        return (a * 1);
    }))(Pit.FSharp.Collections.ListModule.OfArray([2, 7, 14, 5]));
}))));
Pit.Test.UOMTest.get_masses = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
    return Pit.FSharp.Collections.SeqModule.Map((function(a) {
        return (a * 1);
    }))(Pit.FSharp.Collections.ListModule.OfArray([155.54, 179.01, 135.9]));
}))));
Pit.Test.UOMTest.get_densities = Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
    return Pit.FSharp.Collections.SeqModule.Map((function(a) {
        return (a * 1);
    }))(Pit.FSharp.Collections.ListModule.OfArray([0.54, 1, 1.1, 0.25, 0.7]));
}))));
Pit.Test.UOMTest.average = function(l) {
    var patternInput = Pit.FSharp.Core.Operators.op_PipeRight(l)((function(list) {
        return Pit.FSharp.Collections.ListModule.Fold(function(tupledArg) {
            var sum = tupledArg.Item1;
            var count = tupledArg.Item2;
            return function(x) {
                return {
                    Item1: (sum + x),
                    Item2: (count + 1)
                };
            };
        })({
            Item1: 0,
            Item2: 0
        })(list);
    }));
    var sum = patternInput.Item1;
    var count = patternInput.Item2;
    return (sum / count);
};
Pit.Test.UOMTest.UOMeasure2 = (function() {
    return test("UOM 2", function() {
        var patternInput = {
            Item1: Pit.Test.UOMTest.average(Pit.Test.UOMTest.get_vanillaFloats),
            Item2: Pit.Test.UOMTest.average(Pit.Test.UOMTest.get_lengths),
            Item3: Pit.Test.UOMTest.average(Pit.Test.UOMTest.get_masses),
            Item4: Pit.Test.UOMTest.average(Pit.Test.UOMTest.get_densities)
        };
        var m = patternInput.Item3;
        var l = patternInput.Item2;
        var f = patternInput.Item1;
        var d = patternInput.Item4;
        equal(Pit.FSharp.Core.Operators.op_PipeRight(f)((function(v) {
            return parseInt(v);
        })), 14, "UOM Floats");
        equal(l, 7, "UOM Lengths");
        equal(Pit.FSharp.Core.Operators.op_PipeRight(m)((function(v) {
            return parseInt(v);
        })), 156, "UOM Masses");
        return equal(d, 0.718, "UOM Densities");
    });
});
Pit.Test.UOMTest.run = function() {
    module("Units of Measure");
    Pit.Test.UOMTest.UOMeasure1();
    return Pit.Test.UOMTest.UOMeasure2();
};
registerNamespace("Pit.Test");
registerNamespace("Pit.Test.OperatorOverloadTests.Expression");
Pit.Test.OperatorOverloadTests.t = (function() {
    function t(x, y) {
        this.x = x;
        this.y = y;
    }
    t.prototype.get_x = function() {
        return this.x;
    };
    t.prototype.get_y = function() {
        return this.y;
    };
    return t;
})();
Pit.Test.OperatorOverloadTests.t.op_Addition = function(tupledArg) {
    var t1 = tupledArg.Item1;
    var t2 = tupledArg.Item2;
    return new Pit.Test.OperatorOverloadTests.t((t1.get_x() + t2.get_x()), (t1.get_y() + t2.get_y()));
};
Pit.Test.OperatorOverloadTests.t.op_Subtraction = function(tupledArg) {
    var t1 = tupledArg.Item1;
    var t2 = tupledArg.Item2;
    return new Pit.Test.OperatorOverloadTests.t((t1.get_x() - t2.get_x()), (t1.get_y() - t2.get_y()));
};
Pit.Test.OperatorOverloadTests.t.op_Multiply = function(tupledArg) {
    var t1 = tupledArg.Item1;
    var v = tupledArg.Item2;
    return new Pit.Test.OperatorOverloadTests.t((t1.get_x() * v), (t1.get_y() * v));
};
Pit.Test.OperatorOverloadTests.Expression = function() {
    this.Tag = 0;
    this.IsConstant = false;
    this.IsAdd = false;
};
Pit.Test.OperatorOverloadTests.Expression.Add = function(item1, item2) {
    this.Item1 = item1;
    this.Item2 = item2;
};
Pit.Test.OperatorOverloadTests.Expression.Add.prototype = new Pit.Test.OperatorOverloadTests.Expression();
Pit.Test.OperatorOverloadTests.Expression.Add.prototype.equality = function(compareTo) {
    var result = true;
    result = result && this.get_Item1() == compareTo.get_Item1();
    result = result && this.get_Item2() == compareTo.get_Item2();
    return result;
};
Pit.Test.OperatorOverloadTests.Expression.Add.prototype.get_Item1 = function() {
    return this.Item1;
};
Pit.Test.OperatorOverloadTests.Expression.Add.prototype.get_Item2 = function() {
    return this.Item2;
};
Pit.Test.OperatorOverloadTests.Expression.Constant = function(item) {
    this.Item = item;
};
Pit.Test.OperatorOverloadTests.Expression.Constant.prototype = new Pit.Test.OperatorOverloadTests.Expression();
Pit.Test.OperatorOverloadTests.Expression.Constant.prototype.equality = function(compareTo) {
    var result = true;
    result = result && this.get_Item() == compareTo.get_Item();
    return result;
};
Pit.Test.OperatorOverloadTests.Expression.Constant.prototype.get_Item = function() {
    return this.Item;
};
Pit.Test.OperatorOverloadTests.Expression.prototype.get_Tag = function() {
    return this.Tag;
};
Pit.Test.OperatorOverloadTests.Expression.prototype.get_IsConstant = function() {
    return this instanceof Pit.Test.OperatorOverloadTests.Expression.Constant;
};
Pit.Test.OperatorOverloadTests.Expression.prototype.get_IsAdd = function() {
    return this instanceof Pit.Test.OperatorOverloadTests.Expression.Add;
};
Pit.Test.OperatorOverloadTests.Expression.op_Addition = function(tupledArg) {
    var x = tupledArg.Item1;
    var y = tupledArg.Item2;
    return new Pit.Test.OperatorOverloadTests.Expression.Add(x, y);
};
Pit.Test.OperatorOverloadTests.OpOverload1 = function() {
    var t1 = new Pit.Test.OperatorOverloadTests.t(10, 10);
    var t2 = new Pit.Test.OperatorOverloadTests.t(20, 20);
    var t3 = Pit.Test.OperatorOverloadTests.t.op_Addition({
        Item1: t1,
        Item2: t2
    });
    var t4 = Pit.Test.OperatorOverloadTests.t.op_Subtraction({
        Item1: t1,
        Item2: t2
    });
    var t5 = Pit.Test.OperatorOverloadTests.t.op_Multiply({
        Item1: t1,
        Item2: 10
    });
    return test("Op overload1", function() {
        equal(t3.get_x(), 30, "Op Overload 1");
        equal(t4.get_x(), -10, "Op Overload 2");
        return equal(t5.get_x(), 100, "Op Overload 3");
    });
};
Pit.Test.OperatorOverloadTests.OpOverload2 = (function() {
    return test("OpOverload2", function() {
        var a = new Pit.Test.OperatorOverloadTests.Expression.Constant(10);
        var b = new Pit.Test.OperatorOverloadTests.Expression.Constant(20);
        var c = Pit.Test.OperatorOverloadTests.Expression.op_Addition({
            Item1: a,
            Item2: b
        });
        var res = (function(thisObject) {
            if (c instanceof Pit.Test.OperatorOverloadTests.Expression.Add) {
                return true;
            } else {
                return false;
            }
        })(this);
        return equal(true, res, "Union case overload");
    });
});
Pit.Test.OperatorOverloadTests.run = function() {
    module("Operator Overload");
    Pit.Test.OperatorOverloadTests.OpOverload1();
    return Pit.Test.OperatorOverloadTests.OpOverload2();
};
registerNamespace("Pit.Test");
Pit.Test.OverloadedCtorsTests.t = (function() {
    function t() {
        this.x = 0;
        this.msg = '';
    }
    t.prototype.get_x = function() {
        return this.x;
    };
    t.prototype.get_msg = function() {
        return this.msg;
    };
    return t;
})();
Pit.Test.OverloadedCtorsTests.t.__init__ = function(idx, lambda) {
    if (typeof this['ctors'] == 'undefined') {
        this['ctors'] = [];
    }
    var ctors = this['ctors'];
    ctors[idx] = lambda;
};
Pit.Test.OverloadedCtorsTests.t.__init__(0, function(x) {
    var t = new Pit.Test.OverloadedCtorsTests.t();
    t.x = x;
    t.msg = '';
    return t;
});
Pit.Test.OverloadedCtorsTests.t.__init__(1, function(x, msg) {
    var t = new Pit.Test.OverloadedCtorsTests.t();
    t.x = x;
    t.msg = msg;
    return t;
});
Pit.Test.OverloadedCtorsTests.t1 = (function() {
    function t1(x, msg) {
        var thisObject = this;
        thisObject.xval = x;
        thisObject.msgval = msg;
    }
    t1.prototype.get_XVal = function() {
        return this.xval;
    };
    t1.prototype.get_MsgVal = function() {
        return this.msgval;
    };
    return t1;
})();
Pit.Test.OverloadedCtorsTests.t1.__init__ = function(idx, lambda) {
    if (typeof this['ctors'] == 'undefined') {
        this['ctors'] = [];
    }
    var ctors = this['ctors'];
    ctors[idx] = lambda;
};
Pit.Test.OverloadedCtorsTests.t1.__init__(0, function() {
    return new Pit.Test.OverloadedCtorsTests.t1(0, '');
});
Pit.Test.OverloadedCtorsTests.TestRecordLikeCtor = (function() {
    return test("Record like ctor", function() {
        var v = new Pit.Test.OverloadedCtorsTests.t();
        equal(v.get_x(), 0, "Record Like Ctor Exp1");
        var v1 = Pit.Test.OverloadedCtorsTests.t.ctors[0](10);
        equal(v1.get_x(), 10, "Record Like Ctor Exp2");
        var v2 = Pit.Test.OverloadedCtorsTests.t.ctors[1](20, "Hello World");
        equal(v2.get_x(), 20, "Record Like Ctor Exp3");
        return equal(v2.get_msg(), "Hello World", "Record Like Ctor Exp3");
    });
});
Pit.Test.OverloadedCtorsTests.TestNormalTypes = (function() {
    return test("Normal type ctor", function() {
        var v = new Pit.Test.OverloadedCtorsTests.t1(10, "Hello World");
        equal(v.get_XVal(), 10, "Normal Type Ctor Exp1");
        equal(v.get_MsgVal(), "Hello World", "Normal Type Ctor Exp1");
        var v1 = (Pit.Test.OverloadedCtorsTests.t1.ctors[0])();
        return equal(v1.get_XVal(), 0, "Normal Type Ctor Exp2");
    });
});
Pit.Test.OverloadedCtorsTests.run = function() {
    module("Overloaded ctors");
    Pit.Test.OverloadedCtorsTests.TestRecordLikeCtor();
    return Pit.Test.OverloadedCtorsTests.TestNormalTypes();
};
registerNamespace("Pit.Test");
Pit.Test.TryWithTests.Error1 = (function() {
    __extends(Error1, Pit.Exception);

    function Error1(data0) {
        Error1.__super__.constructor.apply(this, arguments);
        this.Data0 = data0;
    }
    Error1.prototype.get_Data0 = function() {
        return this.Data0;
    };
    return Error1;
})();
Pit.Test.TryWithTests.Error1.__init__ = function(idx, lambda) {
    if (typeof this['ctors'] == 'undefined') {
        this['ctors'] = [];
    }
    var ctors = this['ctors'];
    ctors[idx] = lambda;
};
Pit.Test.TryWithTests.Error2 = (function() {
    __extends(Error2, Pit.Exception);

    function Error2(data0, data1) {
        Error2.__super__.constructor.apply(this, arguments);
        this.Data0 = data0;
        this.Data1 = data1;
    }
    Error2.prototype.get_Data0 = function() {
        return this.Data0;
    };
    Error2.prototype.get_Data1 = function() {
        return this.Data1;
    };
    return Error2;
})();
Pit.Test.TryWithTests.Error2.__init__ = function(idx, lambda) {
    if (typeof this['ctors'] == 'undefined') {
        this['ctors'] = [];
    }
    var ctors = this['ctors'];
    ctors[idx] = lambda;
};
Pit.Test.TryWithTests.TryWith1 = (function() {
    return test("Try With", function() {
        var function1 = function(x) {
                return function(y) {
                    return (function(thisObject) {
                        try {
                            return (function(thisObject) {
                                if (x == y) {
                                    throw new Pit.Test.TryWithTests.Error1("x")
                                } else {
                                    throw new Pit.Test.TryWithTests.Error2("x", 10)
                                }
                            })(thisObject);
                        } catch (matchValue) {
                            (function(thisObject) {
                                if (matchValue instanceof Pit.Test.TryWithTests.Error1) {
                                    var str = matchValue.get_Data0();
                                    return equal("x", str, "TryWith Error1");
                                } else if (matchValue instanceof Pit.Test.TryWithTests.Error2) {
                                    var i = matchValue.get_Data1();
                                    var str = matchValue.get_Data0();
                                    return equal(10, i, "TryWith Error2");
                                } else {
                                    return Pit.FSharp.Core.Operators.Reraise();
                                }
                            })(thisObject)
                        }
                    })(this);
                };
            };
        function1(10)(10);
        return function1(10)(20);
    });
});
Pit.Test.TryWithTests.run = function() {
    module("Try With");
    return Pit.Test.TryWithTests.TryWith1();
};
Pit.Test.WhileTests.WhileDeclare = (function() {
    return test("While loop", function() {
        var lookForValue = function(value) {
                return function(maxValue) {
                    var continueLooping = true;
                    var acc = 0;
                    while (continueLooping) {
                        acc = (acc + 1);
                        (function(thisObject) {
                            if (acc < maxValue) {
                                return (function(thisObject) {
                                    if (acc == value) {
                                        continueLooping = false;
                                        return equal(acc == value, true, "While Loop");
                                    } else {
                                        return null;
                                    }
                                })(thisObject);
                            } else {
                                return continueLooping = false;
                            }
                        })(this);
                    };
                };
            };
        lookForValue(10)(20);
        return lookForValue(22)(20);
    });
});
Pit.Test.WhileTests.run = function() {
    module("While loop");
    return Pit.Test.WhileTests.WhileDeclare();
};
registerNamespace("Pit.Test.UnionTests.Shape");
Pit.Test.UnionTests.Shape = function() {
    this.Tag = 0;
    this.IsRectangle = false;
    this.IsSquare = false;
    this.IsEquilateralTriangle = false;
    this.IsCircle = false;
};
Pit.Test.UnionTests.Shape.Circle = function(item) {
    this.Item = item;
};
Pit.Test.UnionTests.Shape.Circle.prototype = new Pit.Test.UnionTests.Shape();
Pit.Test.UnionTests.Shape.Circle.prototype.equality = function(compareTo) {
    var result = true;
    result = result && this.get_Item() == compareTo.get_Item();
    return result;
};
Pit.Test.UnionTests.Shape.Circle.prototype.get_Item = function() {
    return this.Item;
};
Pit.Test.UnionTests.Shape.EquilateralTriangle = function(item) {
    this.Item = item;
};
Pit.Test.UnionTests.Shape.EquilateralTriangle.prototype = new Pit.Test.UnionTests.Shape();
Pit.Test.UnionTests.Shape.EquilateralTriangle.prototype.equality = function(compareTo) {
    var result = true;
    result = result && this.get_Item() == compareTo.get_Item();
    return result;
};
Pit.Test.UnionTests.Shape.EquilateralTriangle.prototype.get_Item = function() {
    return this.Item;
};
Pit.Test.UnionTests.Shape.Square = function(item) {
    this.Item = item;
};
Pit.Test.UnionTests.Shape.Square.prototype = new Pit.Test.UnionTests.Shape();
Pit.Test.UnionTests.Shape.Square.prototype.equality = function(compareTo) {
    var result = true;
    result = result && this.get_Item() == compareTo.get_Item();
    return result;
};
Pit.Test.UnionTests.Shape.Square.prototype.get_Item = function() {
    return this.Item;
};
Pit.Test.UnionTests.Shape.Rectangle = function(item1, item2) {
    this.Item1 = item1;
    this.Item2 = item2;
};
Pit.Test.UnionTests.Shape.Rectangle.prototype = new Pit.Test.UnionTests.Shape();
Pit.Test.UnionTests.Shape.Rectangle.prototype.equality = function(compareTo) {
    var result = true;
    result = result && this.get_Item1() == compareTo.get_Item1();
    result = result && this.get_Item2() == compareTo.get_Item2();
    return result;
};
Pit.Test.UnionTests.Shape.Rectangle.prototype.get_Item1 = function() {
    return this.Item1;
};
Pit.Test.UnionTests.Shape.Rectangle.prototype.get_Item2 = function() {
    return this.Item2;
};
Pit.Test.UnionTests.Shape.prototype.get_Tag = function() {
    return this.Tag;
};
Pit.Test.UnionTests.Shape.prototype.get_IsRectangle = function() {
    return this instanceof Pit.Test.UnionTests.Shape.Rectangle;
};
Pit.Test.UnionTests.Shape.prototype.get_IsSquare = function() {
    return this instanceof Pit.Test.UnionTests.Shape.Square;
};
Pit.Test.UnionTests.Shape.prototype.get_IsEquilateralTriangle = function() {
    return this instanceof Pit.Test.UnionTests.Shape.EquilateralTriangle;
};
Pit.Test.UnionTests.Shape.prototype.get_IsCircle = function() {
    return this instanceof Pit.Test.UnionTests.Shape.Circle;
};
Pit.Test.UnionTests.UnionDeclare = function() {
    var pi = 3.141592654;
    var area = function(myShape) {
            return (function(thisObject) {
                if (myShape instanceof Pit.Test.UnionTests.Shape.EquilateralTriangle) {
                    var s = myShape.get_Item();
                    return (((Pit.FSharp.Core.Operators.Sqrt(3) / 4) * s) * s);
                } else if (myShape instanceof Pit.Test.UnionTests.Shape.Square) {
                    var s = myShape.get_Item();
                    return (s * s);
                } else if (myShape instanceof Pit.Test.UnionTests.Shape.Rectangle) {
                    var w = myShape.get_Item2();
                    var h = myShape.get_Item1();
                    return (h * w);
                } else {
                    var radius = myShape.get_Item();
                    return ((pi * radius) * radius);
                }
            })(this);
        };
    return test("Union Declare", function() {
        var radius = 15;
        var myCircle = new Pit.Test.UnionTests.Shape.Circle(radius);
        equal(Pit.FSharp.Core.Operators.op_PipeRight(area(myCircle))((function(value) {
            return Pit.FSharp.Core.Operators.ToInt(value);
        })), 706, "Union Declare");
        var squareSide = 10;
        var mySquare = new Pit.Test.UnionTests.Shape.Square(squareSide);
        equal(area(mySquare), 100, "Union Declare");
        var patternInput = {
            Item1: 5,
            Item2: 10
        };
        var width = patternInput.Item2;
        var height = patternInput.Item1;
        var myRectangle = new Pit.Test.UnionTests.Shape.Rectangle(height, width);
        return equal(area(myRectangle), 50, "Union Declare");
    });
};
Pit.Test.UnionTests.run = function() {
    module("Union cases");
    return Pit.Test.UnionTests.UnionDeclare();
};
registerNamespace("Pit.Test");
Pit.Test.TupleTests.tRec = (function() {
    function tRec(p1, p2) {
        this.p1 = p1;
        this.p2 = p2;
    }
    tRec.prototype.get_p1 = function() {
        return this.p1;
    };
    tRec.prototype.get_p2 = function() {
        return this.p2;
    };
    return tRec;
})();
Pit.Test.TupleTests.TupleIgnore = (function() {
    function TupleIgnore() {}
    TupleIgnore.prototype.CallTuple2 = function(s1, s2) {
        var thisObject = this;
        return (s1 + s2);
    };
    return TupleIgnore;
})();
Pit.Test.TupleTests.TupleDeclare = (function() {
    return test("Tuple Declare", function() {
        var patternInput = {
            Item1: 1,
            Item2: 2,
            Item3: 3
        };
        var c = patternInput.Item3;
        var b = patternInput.Item2;
        var a = patternInput.Item1;
        return equal(a, 1, "Tuple Decalre");
    });
});
Pit.Test.TupleTests.TupleFst = (function() {
    return test("Tuple Fst", function() {
        var r = Pit.FSharp.Core.Operators.Fst({
            Item1: 1,
            Item2: 2
        });
        return equal(r, 1, "Tuple First(fst)");
    });
});
Pit.Test.TupleTests.TupleSnd = (function() {
    return test("Tuple Snd", function() {
        var r = Pit.FSharp.Core.Operators.Snd({
            Item1: 1,
            Item2: 2
        });
        return equal(r, 2, "Tuple Second(fst)");
    });
});
Pit.Test.TupleTests.MixedTuple = (function() {
    return test("Mixed Tuple", function() {
        var mixedTuple = {
            Item1: 1,
            Item2: "two",
            Item3: 3.3
        };
        var r = mixedTuple.Item2;
        return equal(r, "two", "Mixed Tuple");
    });
});
Pit.Test.TupleTests.TupleFunctions = (function() {
    return test("Tuple Functions", function() {
        var avg = function(tupledArg) {
                var a = tupledArg.Item1;
                var b = tupledArg.Item2;
                return ((a + b) / 2);
            };
        var r = avg({
            Item1: 5,
            Item2: 5
        });
        return equal(r, 5, "Functions with Tuple arguements");
    });
});
Pit.Test.TupleTests.TupleFunctions2 = (function() {
    return test("Tuple Functions2", function() {
        var scalarMultiply = function(s) {
                return function(tupledArg) {
                    var a = tupledArg.Item1;
                    var b = tupledArg.Item2;
                    return {
                        Item1: (a * s),
                        Item2: (b * s)
                    };
                };
            };
        var r = Pit.FSharp.Core.Operators.Fst(scalarMultiply(5)({
            Item1: 1,
            Item2: 2
        }));
        return equal(r, 5, "Functions with Tuple arguements 2");
    });
});
Pit.Test.TupleTests.t1 = function(x) {
    return {
        Item1: x,
        Item2: (function(x1) {
            return (x1 + 1);
        })
    };
};
Pit.Test.TupleTests.TupleFunctions3 = (function() {
    return test("Tuple Functions3", function() {
        var r = Pit.FSharp.Core.Operators.Snd(Pit.Test.TupleTests.t1(3))(3);
        return equal(r, 4, "Tuple with Functions arguements 2");
    });
});
Pit.Test.TupleTests.TupleArrays = (function() {
    return test("Tuple Arrays", function() {
        var a = {
            Item1: [1, 2, 3],
            Item2: [4, 5, 6]
        };
        return equal(Pit.FSharp.Core.Operators.Fst(a)[0], 1, "Tuple of Arrays");
    });
});
Pit.Test.TupleTests.TupleRecords = (function() {
    return test("Tuple with Records", function() {
        var j = new Pit.Test.TupleTests.tRec(5, 5);
        var k = new Pit.Test.TupleTests.tRec(5, 5);
        var tupRec = function(tupledArg) {
                var a = tupledArg.Item1;
                var b = tupledArg.Item2;
                return (((a.get_p1() + a.get_p2()) + b.get_p1()) + b.get_p2());
            };
        var r = tupRec({
            Item1: j,
            Item2: k
        });
        return equal(r, 20, "Tuple with records");
    });
});
Pit.Test.TupleTests.TupleCallAsNormalFunction = (function() {
    return test("Tuple call as normal function", function() {
        var a = new Pit.Test.TupleTests.TupleIgnore();
        var s = a.CallTuple2(1, 1);
        return equal(2, s, "Tuple Call as Normal Function IgnoreTuple=true");
    });
});
Pit.Test.TupleTests.run = function() {
    Pit.Test.TupleTests.TupleDeclare();
    Pit.Test.TupleTests.TupleFst();
    Pit.Test.TupleTests.TupleSnd();
    Pit.Test.TupleTests.MixedTuple();
    Pit.Test.TupleTests.TupleFunctions();
    Pit.Test.TupleTests.TupleFunctions2();
    Pit.Test.TupleTests.TupleFunctions3();
    Pit.Test.TupleTests.TupleArrays();
    Pit.Test.TupleTests.TupleRecords();
    return Pit.Test.TupleTests.TupleCallAsNormalFunction();
};
registerNamespace("Pit.Test");
registerNamespace("Pit.Test.RecordsTests.State");
registerNamespace("Pit.Test.RecordsTests.SomeObject");
Pit.Test.RecordsTests.MyRecord = (function() {
    function MyRecord(x, y, z) {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }
    MyRecord.prototype.get_X = function() {
        return this.X;
    };
    MyRecord.prototype.get_Y = function() {
        return this.Y;
    };
    MyRecord.prototype.get_Z = function() {
        return this.Z;
    };
    return MyRecord;
})();
Pit.Test.RecordsTests.Car = (function() {
    function Car(make, model, odometer) {
        this.Make = make;
        this.Model = model;
        this.Odometer = odometer;
    }
    Car.prototype.set_Odometer = function(x) {
        this.Odometer = x;
    };
    Car.prototype.get_Make = function() {
        return this.Make;
    };
    Car.prototype.get_Model = function() {
        return this.Model;
    };
    Car.prototype.get_Odometer = function() {
        return this.Odometer;
    };
    return Car;
})();
Pit.Test.RecordsTests.Point3D = (function() {
    function Point3D(x, y, z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    Point3D.prototype.get_x = function() {
        return this.x;
    };
    Point3D.prototype.get_y = function() {
        return this.y;
    };
    Point3D.prototype.get_z = function() {
        return this.z;
    };
    return Point3D;
})();
Pit.Test.RecordsTests.Address1 = (function() {
    function Address1(street, pincode) {
        this.street = street;
        this.pincode = pincode;
    }
    Address1.prototype.get_street = function() {
        return this.street;
    };
    Address1.prototype.get_pincode = function() {
        return this.pincode;
    };
    return Address1;
})();
Pit.Test.RecordsTests.Employee2 = (function() {
    function Employee2(id, name, address) {
        this.id = id;
        this.name = name;
        this.address = address;
    }
    Employee2.prototype.get_id = function() {
        return this.id;
    };
    Employee2.prototype.get_name = function() {
        return this.name;
    };
    Employee2.prototype.get_address = function() {
        return this.address;
    };
    return Employee2;
})();
Pit.Test.RecordsTests.CustomPoint = (function() {
    function CustomPoint(x, y) {
        this.x = x;
        this.y = y;
    }
    CustomPoint.prototype.get_x = function() {
        return this.x;
    };
    CustomPoint.prototype.get_y = function() {
        return this.y;
    };
    CustomPoint.prototype.get_xy = (function() {
        return (this.get_x() * this.get_y());
    });
    return CustomPoint;
})();
registerNamespace("Pit.Test");
Pit.Test.RecordsTests.SomeObject.t = (function() {
    function t(connected) {
        this.connected = connected;
    }
    t.prototype.get_connected = function() {
        return this.connected;
    };
    return t;
})();
Pit.Test.RecordsTests.RecordDeclare = (function() {
    return test("Record Declare", function() {
        var myRecord1 = new Pit.Test.RecordsTests.MyRecord(1, 2, 3);
        equal(myRecord1.get_X(), 1, "Record Declare 1");
        return equal(myRecord1.get_Y(), 2, "Record Declare 1");
    });
});
Pit.Test.RecordsTests.RecordDeclare2 = (function() {
    return test("Record Declare2", function() {
        var myRecord2 = new Pit.Test.RecordsTests.MyRecord(1, 2, 3);
        return equal(myRecord2.get_Y(), 2, "Record Declare 2");
    });
});
Pit.Test.RecordsTests.RecordDeclare3 = (function() {
    return test("Record Declare3", function() {
        var myRecord2 = new Pit.Test.RecordsTests.MyRecord(1, 2, 3);
        var myRecord3 = new Pit.Test.RecordsTests.MyRecord(myRecord2.get_X(), 100, 2);
        return equal(myRecord3.get_Y(), 100, "Record Declare 3");
    });
});
Pit.Test.RecordsTests.RecordDeclare4 = (function() {
    return test("Record Declare 4", function() {
        var myCar = new Pit.Test.RecordsTests.Car("Fabrikam", "Coupe", 108112);
        myCar.set_Odometer((myCar.get_Odometer() + 21));
        return equal(myCar.get_Odometer(), (108112 + 21), "Record Declare 4");
    });
});
Pit.Test.RecordsTests.RecordPatternMatching = function() {
    var evaluatePoint = function(point) {
            return (function(thisObject) {
                if (point.get_x() == 0) {
                    return (function(thisObject) {
                        if (point.get_y() == 0) {
                            return (function(thisObject) {
                                if (point.get_z() == 0) {
                                    return "Point is at the origin.";
                                } else {
                                    return "Point at other location";
                                }
                            })(thisObject);
                        } else {
                            return "Point at other location";
                        }
                    })(thisObject);
                } else {
                    return "Point at other location";
                }
            })(this);
        };
    return test("Record Pattern Matching", function() {
        var r = evaluatePoint(new Pit.Test.RecordsTests.Point3D(0, 0, 0));
        equal(r, "Point is at the origin.", "Record Pattern Matching");
        var r1 = evaluatePoint(new Pit.Test.RecordsTests.Point3D(10, 0, -1));
        return equal(r1, "Point at other location", "Record Pattern Matching");
    });
};
Pit.Test.RecordsTests.RecordJsObjectTest = (function() {
    return test("Record JS Object", function() {
        var emp = {
            id: 0,
            name: "Robert"
        };
        equal(0, emp.id, "RecordJsObject Test");
        return equal("Robert", emp.name, "RecordJsObject Test");
    });
});
Pit.Test.RecordsTests.RecordJsObjectEqualityTest = (function() {
    return test("Record JS Object Equality", function() {
        var emp = {
            id: 1,
            name: "Robert"
        };
        var isEqual = (function(thisObject) {
            if (emp.id == 1) {
                return (function(thisObject) {
                    if (emp.name == "Robert") {
                        return true;
                    } else {
                        return false;
                    }
                })(thisObject);
            } else {
                return false;
            }
        })(this);
        return equal(true, isEqual, "Record Equality Test");
    });
});
Pit.Test.RecordsTests.RecordJsObjectEqualityTest2 = (function() {
    return test("Record JS Object Equality2", function() {
        var emp1 = {
            id: 1,
            name: "Robert"
        };
        var emp2 = {
            id: 1,
            name: "Robert"
        };
        var res = Pit.JsCommon.equality(emp1, emp2);
        return equal(true, res, "Record Equality Test2");
    });
});
Pit.Test.RecordsTests.NestedRecord = (function() {
    return test("Nested record", function() {
        var man = {
            employee: {
                id: 0,
                name: "Robert",
                address: {
                    street: "Green street",
                    pincode: 420
                }
            },
            division: "HR"
        };
        var man1 = {
            employee: {
                id: man.employee.id,
                name: man.employee.name,
                address: {
                    street: "Red street",
                    pincode: 428
                }
            },
            division: man.division
        };
        var man2 = {
            employee: {
                id: 1,
                name: "Dilbert",
                address: man.employee.address
            },
            division: man1.division
        };
        equal(man1.employee.name, "Robert", "Manager1 name");
        equal(man1.employee.address.street, "Red street", "Manager1 address");
        equal(man2.employee.name, "Dilbert", "Manager2 name");
        return equal(man2.employee.address.street, "Green street", "Manager2 address");
    });
});
Pit.Test.RecordsTests.NestedRecordEquality = (function() {
    return test("Nested record equality", function() {
        var man1 = {
            employee: {
                id: 0,
                name: "Robert",
                address: {
                    street: "Green street",
                    pincode: 420
                }
            },
            division: "HR"
        };
        var man2 = {
            employee: {
                id: 0,
                name: "Robert",
                address: {
                    street: "Green street",
                    pincode: 420
                }
            },
            division: "HR"
        };
        var res = Pit.JsCommon.equality(man1, man2);
        return equal(true, res, "Nested Record Equality");
    });
});
Pit.Test.RecordsTests.NestedRecord2 = (function() {
    return test("Nested record 2", function() {
        var man = {
            employee: new Pit.Test.RecordsTests.Employee2(0, "Robert", new Pit.Test.RecordsTests.Address1("Green street", 420)),
            division: "HR"
        };
        var man1 = {
            employee: new Pit.Test.RecordsTests.Employee2(man.employee.get_id(), man.employee.get_name(), new Pit.Test.RecordsTests.Address1("Red street", 428)),
            division: man.division
        };
        var man2 = {
            employee: new Pit.Test.RecordsTests.Employee2(1, "Dilbert", man.employee.get_address()),
            division: man1.division
        };
        equal(man1.employee.get_name(), "Robert", "Manager1 name");
        equal(man1.employee.get_address().get_street(), "Red street", "Manager1 address");
        equal(man2.employee.get_name(), "Dilbert", "Manager2 name");
        return equal(man2.employee.get_address().get_street(), "Green street", "Manager2 address");
    });
});
Pit.Test.RecordsTests.RecordExtendedTypeTest = (function() {
    return test("Record Extended Type", function() {
        var p = new Pit.Test.RecordsTests.CustomPoint(10, 20);
        var xy = p.get_xy();
        return equal(xy, 200, "Record Member XY");
    });
});
Pit.Test.RecordsTests.handle = function(t) {
    var matchValue = t.current;
    return (function(thisObject) {
        if (matchValue instanceof Pit.FSharp.Core.FSharpOption1.None) {
            return t;
        } else {
            var current = matchValue.get_Value();
            var t1 = {
                current: new Pit.FSharp.Core.FSharpOption1.Some({
                    current: current.current,
                    last: new Pit.FSharp.Core.FSharpOption1.Some(current.current)
                })
            };
            return t1;
        }
    })(this);
};
Pit.Test.RecordsTests.RecordWithSomeNone = (function() {
    return test("Record with Option", function() {
        var t = {
            current: new Pit.FSharp.Core.FSharpOption1.Some({
                current: new Pit.Test.RecordsTests.SomeObject.t(false),
                last: new Pit.FSharp.Core.FSharpOption1.None()
            })
        };
        var t1 = Pit.Test.RecordsTests.handle(t);
        return equal(t1.current.get_Value().current.get_connected(), false, "Record With Option and Match");
    });
});
Pit.Test.RecordsTests.run = function() {
    module("Record Tests");
    Pit.Test.RecordsTests.RecordDeclare();
    Pit.Test.RecordsTests.RecordDeclare2();
    Pit.Test.RecordsTests.RecordDeclare3();
    Pit.Test.RecordsTests.RecordDeclare4();
    Pit.Test.RecordsTests.RecordPatternMatching();
    Pit.Test.RecordsTests.RecordJsObjectTest();
    Pit.Test.RecordsTests.RecordJsObjectEqualityTest();
    Pit.Test.RecordsTests.RecordJsObjectEqualityTest2();
    Pit.Test.RecordsTests.NestedRecord();
    Pit.Test.RecordsTests.NestedRecordEquality();
    Pit.Test.RecordsTests.NestedRecord2();
    Pit.Test.RecordsTests.RecordExtendedTypeTest();
    return Pit.Test.RecordsTests.RecordWithSomeNone();
};
registerNamespace("Pit.Test");
registerNamespace("Pit.Test.PatternTests.PersonName");
Pit.Test.PatternTests.Color = {
    Red: {},
    Green: {},
    Blue: {}
};
Pit.Test.PatternTests.PersonName = function() {
    this.Tag = 0;
    this.IsFirstLast = false;
    this.IsLastOnly = false;
    this.IsFirstOnly = false;
};
Pit.Test.PatternTests.PersonName.FirstOnly = function(item) {
    this.Item = item;
};
Pit.Test.PatternTests.PersonName.FirstOnly.prototype = new Pit.Test.PatternTests.PersonName();
Pit.Test.PatternTests.PersonName.FirstOnly.prototype.equality = function(compareTo) {
    var result = true;
    result = result && this.get_Item() == compareTo.get_Item();
    return result;
};
Pit.Test.PatternTests.PersonName.FirstOnly.prototype.get_Item = function() {
    return this.Item;
};
Pit.Test.PatternTests.PersonName.LastOnly = function(item) {
    this.Item = item;
};
Pit.Test.PatternTests.PersonName.LastOnly.prototype = new Pit.Test.PatternTests.PersonName();
Pit.Test.PatternTests.PersonName.LastOnly.prototype.equality = function(compareTo) {
    var result = true;
    result = result && this.get_Item() == compareTo.get_Item();
    return result;
};
Pit.Test.PatternTests.PersonName.LastOnly.prototype.get_Item = function() {
    return this.Item;
};
Pit.Test.PatternTests.PersonName.FirstLast = function(item1, item2) {
    this.Item1 = item1;
    this.Item2 = item2;
};
Pit.Test.PatternTests.PersonName.FirstLast.prototype = new Pit.Test.PatternTests.PersonName();
Pit.Test.PatternTests.PersonName.FirstLast.prototype.equality = function(compareTo) {
    var result = true;
    result = result && this.get_Item1() == compareTo.get_Item1();
    result = result && this.get_Item2() == compareTo.get_Item2();
    return result;
};
Pit.Test.PatternTests.PersonName.FirstLast.prototype.get_Item1 = function() {
    return this.Item1;
};
Pit.Test.PatternTests.PersonName.FirstLast.prototype.get_Item2 = function() {
    return this.Item2;
};
Pit.Test.PatternTests.PersonName.prototype.get_Tag = function() {
    return this.Tag;
};
Pit.Test.PatternTests.PersonName.prototype.get_IsFirstLast = function() {
    return this instanceof Pit.Test.PatternTests.PersonName.FirstLast;
};
Pit.Test.PatternTests.PersonName.prototype.get_IsLastOnly = function() {
    return this instanceof Pit.Test.PatternTests.PersonName.LastOnly;
};
Pit.Test.PatternTests.PersonName.prototype.get_IsFirstOnly = function() {
    return this instanceof Pit.Test.PatternTests.PersonName.FirstOnly;
};
Pit.Test.PatternTests.ConstantMatchTest = (function() {
    return test("constant match", function() {
        var filter123 = function(x) {
                return (function(thisObject) {
                    if (x == 1) {
                        return equal(true, (function(thisObject) {
                            if (x < 4) {
                                return x > 0;
                            } else {
                                return false;
                            }
                        })(thisObject), "Constant Match Test");
                    } else if (x == 2) {
                        return equal(true, (function(thisObject) {
                            if (x < 4) {
                                return x > 0;
                            } else {
                                return false;
                            }
                        })(thisObject), "Constant Match Test");
                    } else if (x == 3) {
                        return equal(true, (function(thisObject) {
                            if (x < 4) {
                                return x > 0;
                            } else {
                                return false;
                            }
                        })(thisObject), "Constant Match Test");
                    } else {
                        return null;
                    }
                })(this);
            };
        for (var x = 1; x <= 10; x++) {
            (function(thisObject, x) {
                filter123(x)
            })(this, x);
        };
    });
});
Pit.Test.PatternTests.ConstantMatchTest2 = (function() {
    return test("constant match 2", function() {
        var printColorName = function(color) {
                return (function(thisObject) {
                    if (color == Pit.Test.PatternTests.Color.Red) {
                        return equal(color, Pit.Test.PatternTests.Color.Red, "Constant Match Test 2");
                    } else if (color == Pit.Test.PatternTests.Color.Green) {
                        return equal(color, Pit.Test.PatternTests.Color.Green, "Constant Match Test 2");
                    } else if (color == Pit.Test.PatternTests.Color.Blue) {
                        return equal(color, Pit.Test.PatternTests.Color.Blue, "Constant Match Test 2");
                    } else {
                        return null;
                    }
                })(this);
            };
        printColorName(Pit.Test.PatternTests.Color.Red);
        printColorName(Pit.Test.PatternTests.Color.Green);
        return printColorName(Pit.Test.PatternTests.Color.Blue);
    });
});
Pit.Test.PatternTests.IdentifierPatternTest = (function() {
    return test("Identifier Pattern", function() {
        var constructQuery = function(personName) {
                return (function(thisObject) {
                    if (personName instanceof Pit.Test.PatternTests.PersonName.LastOnly) {
                        var lastName = personName.get_Item();
                        return "last";
                    } else if (personName instanceof Pit.Test.PatternTests.PersonName.FirstLast) {
                        var lastName = personName.get_Item2();
                        var firstName = personName.get_Item1();
                        return "firstlast";
                    } else {
                        var firstName = personName.get_Item();
                        return "first";
                    }
                })(this);
            };
        var r = constructQuery(new Pit.Test.PatternTests.PersonName.FirstOnly("Steve"));
        equal(r, "first", "Identifier Pattern Test");
        var r1 = constructQuery(new Pit.Test.PatternTests.PersonName.LastOnly("Jobs"));
        equal(r1, "last", "Identifier Pattern Test");
        var r2 = constructQuery(new Pit.Test.PatternTests.PersonName.FirstLast("John", "Jobs"));
        return equal(r2, "firstlast", "Identifier Pattern Test");
    });
});
Pit.Test.PatternTests.function1 = function(x) {
    return (function() {
        return (function(thisObject) {
            var var1 = x.Item1;
            var var2 = x.Item2;
            if (var1 > var2) {
                var var2 = x.Item2;
                var var1 = x.Item1;
                return var2;
            } else {
                return (function() {
                    return (function(thisObject) {
                        var var1 = x.Item1;
                        var var2 = x.Item2;
                        if (var1 < var2) {
                            var var2 = x.Item2;
                            var var1 = x.Item1;
                            return var2;
                        } else {
                            var var2 = x.Item2;
                            var var1 = x.Item1;
                            return var1;
                        };
                    })(thisObject);
                })();
            };
        })(this);
    })();
};
Pit.Test.PatternTests.VariablePatternTest = (function() {
    return test("Variable Pattern", function() {
        var r1 = Pit.Test.PatternTests.function1({
            Item1: 1,
            Item2: 2
        });
        equal(r1, 2, "Variable Pattern Test");
        var r2 = Pit.Test.PatternTests.function1({
            Item1: 2,
            Item2: 1
        });
        equal(r2, 1, "Identifier Pattern Test");
        var r3 = Pit.Test.PatternTests.function1({
            Item1: 0,
            Item2: 0
        });
        return equal(r3, 0, "Identifier Pattern Test");
    });
});
Pit.Test.PatternTests.VariablePatternTest2 = (function() {
    return test("Variable Pattern2", function() {
        var sliceMiddle = 0.4;
        return (function() {
            return (function(thisObject) {
                var x = sliceMiddle;
                if (x <= 0.25) {
                    var x = sliceMiddle;
                    return null;
                } else {
                    return (function() {
                        return (function(thisObject) {
                            var x = sliceMiddle;
                            if ((function(thisObject) {
                                if (x > 0.25) {
                                    return x <= 0.5;
                                } else {
                                    return false;
                                }
                            })(thisObject)) {
                                var x = sliceMiddle;
                                return equal(0.4, sliceMiddle, "SliceMiddle");
                            } else {
                                return null;
                            };
                        })(thisObject);
                    })();
                };
            })(this);
        })();
    });
});
Pit.Test.PatternTests.AsPatternTest = (function() {
    return test("As Pattern", function() {
        var tuple1 = {
            Item1: 1,
            Item2: 2
        };
        var var2 = tuple1.Item2;
        var var1 = tuple1.Item1;
        equal(var1, 1, "As Pattern Test");
        return equal(var2, 2, "As Pattern Test");
    });
});
Pit.Test.PatternTests.OrPatternTest = function() {
    var detectZeroOR = function(point) {
            return (function(thisObject) {
                if (point.Item1 == 0) {
                    return (function(thisObject) {
                        if (point.Item2 == 0) {
                            return "Zero found.";
                        } else {
                            return "Zero found.";
                        }
                    })(thisObject);
                } else if (point.Item2 == 0) {
                    return "Zero found.";
                } else {
                    return "Both nonzero.";
                }
            })(this);
        };
    return test("Or Pattern", function() {
        var r1 = detectZeroOR({
            Item1: 0,
            Item2: 0
        });
        equal(r1, "Zero found.", "Or Pattern Test");
        var r2 = detectZeroOR({
            Item1: 1,
            Item2: 0
        });
        equal(r2, "Zero found.", "Or Pattern Test");
        var r3 = detectZeroOR({
            Item1: 0,
            Item2: 10
        });
        equal(r3, "Zero found.", "Or Pattern Test");
        var r4 = detectZeroOR({
            Item1: 10,
            Item2: 15
        });
        return equal(r4, "Both nonzero.", "Or Pattern Test");
    });
};
Pit.Test.PatternTests.AndPatternTest = function() {
    var detectZeroAND = function(point) {
            return (function(thisObject) {
                if (point.Item1 == 0) {
                    return (function(thisObject) {
                        if (point.Item2 == 0) {
                            return "Both values zero.";
                        } else if (point.Item1 == 0) {
                            var var1 = point.Item1;
                            var var2 = point.Item2;
                            return ("nonzero " + var2.toString());
                        } else if (point.Item2 == 0) {
                            var var1 = point.Item1;
                            var var2 = point.Item2;
                            return ("nonzero " + var1.toString());
                        } else {
                            return "Both nonzero.";
                        }
                    })(thisObject);
                } else if (point.Item1 == 0) {
                    var var1 = point.Item1;
                    var var2 = point.Item2;
                    return ("nonzero " + var2.toString());
                } else if (point.Item2 == 0) {
                    var var1 = point.Item1;
                    var var2 = point.Item2;
                    return ("nonzero " + var1.toString());
                } else {
                    return "Both nonzero.";
                }
            })(this);
        };
    return test("And Pattern", function() {
        var r1 = detectZeroAND({
            Item1: 0,
            Item2: 0
        });
        equal(r1, "Both values zero.", "And Pattern Test");
        var r2 = detectZeroAND({
            Item1: 1,
            Item2: 0
        });
        equal(r2, "nonzero 1", "And Pattern Test");
        var r3 = detectZeroAND({
            Item1: 0,
            Item2: 10
        });
        equal(r3, "nonzero 10", "And Pattern Test");
        var r4 = detectZeroAND({
            Item1: 10,
            Item2: 15
        });
        return equal(r4, "Both nonzero.", "And Pattern Test");
    });
};
Pit.Test.PatternTests.ConsPatternTest = (function() {
    return test("Cons pattern", function() {
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 2, 3, 4]);
        var printList = function(l) {
                return (function(thisObject) {
                    if (l instanceof Pit.FSharp.Collections.FSharpList1.Empty) {
                        return null;
                    } else {
                        var tail = l.get_Tail();
                        var head = l.get_Head();
                        equal(true, head <= 4, "Cons Pattern test");
                        return printList(tail);
                    }
                })(this);
            };
        return printList(list1);
    });
});
Pit.Test.PatternTests.listLength = function(list) {
    return (function(thisObject) {
        if (list instanceof Pit.FSharp.Collections.FSharpList1.Cons) {
            return (function(thisObject) {
                if (list.get_Tail() instanceof Pit.FSharp.Collections.FSharpList1.Cons) {
                    return (function(thisObject) {
                        if (list.get_Tail().get_Tail() instanceof Pit.FSharp.Collections.FSharpList1.Cons) {
                            return (function(thisObject) {
                                if (list.get_Tail().get_Tail().get_Tail() instanceof Pit.FSharp.Collections.FSharpList1.Empty) {
                                    return 3;
                                } else {
                                    return Pit.FSharp.Collections.ListModule.Length(list);
                                }
                            })(thisObject);
                        } else {
                            return 2;
                        }
                    })(thisObject);
                } else {
                    return 1;
                }
            })(thisObject);
        } else {
            return 0;
        }
    })(this);
};
Pit.Test.PatternTests.ListPatternTest = (function() {
    return test("List Pattern", function() {
        equal(Pit.Test.PatternTests.listLength(Pit.FSharp.Collections.ListModule.OfArray([1])), 1, "List Pattern test 1");
        equal(Pit.Test.PatternTests.listLength(Pit.FSharp.Collections.ListModule.OfArray([1, 1])), 2, "List Pattern test 2");
        return equal(Pit.Test.PatternTests.listLength(new Pit.FSharp.Collections.FSharpList1.Empty()), 0, "List Pattern test 3");
    });
});
Pit.Test.PatternTests.countValues = function(list) {
    return function(value) {
        var checkList = function(list1) {
                return function(acc) {
                    return (function(thisObject) {
                        if (list1 instanceof Pit.FSharp.Collections.FSharpList1.Cons) {
                            return (function() {
                                return (function(thisObject) {
                                    var elem1 = list1.get_Head();
                                    var head = list1.get_Head();
                                    var tail = list1.get_Tail();
                                    if (elem1 == value) {
                                        var elem1 = list1.get_Head();
                                        var head = list1.get_Head();
                                        var tail = list1.get_Tail();
                                        return checkList(tail)((acc + 1));
                                    } else if (list1 instanceof Pit.FSharp.Collections.FSharpList1.Empty) {
                                        return acc;
                                    } else {
                                        var tail = list1.get_Tail();
                                        var head = list1.get_Head();
                                        return checkList(tail)(acc);
                                    };
                                })(thisObject);
                            })();
                        } else if (list1 instanceof Pit.FSharp.Collections.FSharpList1.Empty) {
                            return acc;
                        } else {
                            var tail = list1.get_Tail();
                            var head = list1.get_Head();
                            return checkList(tail)(acc);
                        }
                    })(this);
                };
            };
        return checkList(list)(0);
    };
};
Pit.Test.PatternTests.ParanthesizedPatternTest = (function() {
    return test("Paranthesized Test", function() {
        var result = Pit.Test.PatternTests.countValues(Pit.FSharp.Collections.SeqModule.ToList(Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map((function(x) {
                return ((x * x) - 4);
            }))(Pit.FSharp.Core.Operators.op_Range(-10)(10));
        })))))(0);
        return equal(result, 2, "Array Pattern test");
    });
});
Pit.Test.PatternTests.TuplePatternTest = function() {
    var detectZeroTuple = function(point) {
            return (function(thisObject) {
                if (point.Item1 == 0) {
                    return (function(thisObject) {
                        if (point.Item2 == 0) {
                            return "Both values zero.";
                        } else {
                            var var2 = point.Item2;
                            return "First value zero";
                        }
                    })(thisObject);
                } else if (point.Item2 == 0) {
                    var var1 = point.Item1;
                    return "Second value zero";
                } else {
                    return "Both nonzero.";
                }
            })(this);
        };
    return test("Tuple Pattern", function() {
        var r1 = detectZeroTuple({
            Item1: 0,
            Item2: 0
        });
        equal(r1, "Both values zero.", "Tuple Pattern test");
        var r2 = detectZeroTuple({
            Item1: 1,
            Item2: 0
        });
        equal(r2, "Second value zero", "Tuple Pattern test");
        var r3 = detectZeroTuple({
            Item1: 0,
            Item2: 10
        });
        equal(r3, "First value zero", "Tuple Pattern test");
        var r4 = detectZeroTuple({
            Item1: 10,
            Item2: 15
        });
        return equal(r4, "Both nonzero.", "Tuple Pattern test");
    });
};
Pit.Test.PatternTests.WildCardPatternTest = function() {
    var detect1 = function(x) {
            return (function(thisObject) {
                if (x == 1) {
                    return "Found";
                } else {
                    var var1 = x;
                    return "NotFound";
                }
            })(this);
        };
    return test("Wild Card Pattern", function() {
        var r1 = detect1(0);
        equal(r1, "NotFound", "WildCard Pattern test");
        var r2 = detect1(1);
        return equal(r2, "Found", "WildCard Pattern test");
    });
};
Pit.Test.PatternTests.MultiplePatternTest = function() {
    var function1 = function(x) {
            return function(y) {
                return (function() {
                    return (function(thisObject) {
                        var var1 = x.Item1;
                        var var2 = x.Item2;
                        if (var1 > var2) {
                            var var2 = x.Item2;
                            var var1 = x.Item1;
                            return (function() {
                                return (function(thisObject) {
                                    var var12 = y.Item1;
                                    var var21 = y.Item2;
                                    if (var12 < var21) {
                                        var var21 = y.Item2;
                                        var var12 = y.Item1;
                                        return true;
                                    } else {
                                        return false;
                                    };
                                })(this);
                            })();
                        } else {
                            return false;
                        };
                    })(this);
                })();
            };
        };
    return test("Multiple pattern", function() {
        var r = function1({
            Item1: 3,
            Item2: 2
        })({
            Item1: 3,
            Item2: 5
        });
        return equal(true, r, "Multiple Patterns Test");
    });
};
Pit.Test.PatternTests.run = function() {
    module("Pattern Tests");
    Pit.Test.PatternTests.ConstantMatchTest();
    Pit.Test.PatternTests.ConstantMatchTest2();
    Pit.Test.PatternTests.IdentifierPatternTest();
    Pit.Test.PatternTests.VariablePatternTest();
    Pit.Test.PatternTests.VariablePatternTest2();
    Pit.Test.PatternTests.AsPatternTest();
    Pit.Test.PatternTests.OrPatternTest();
    Pit.Test.PatternTests.AndPatternTest();
    Pit.Test.PatternTests.ConsPatternTest();
    Pit.Test.PatternTests.ListPatternTest();
    Pit.Test.PatternTests.ParanthesizedPatternTest();
    Pit.Test.PatternTests.TuplePatternTest();
    Pit.Test.PatternTests.WildCardPatternTest();
    return Pit.Test.PatternTests.MultiplePatternTest();
};
registerNamespace("Pit.Test");
registerNamespace("Pit.Test.LetTests.Test");
Pit.Test.LetTests.t = (function() {
    function t(left) {
        this.left = left;
    }
    t.prototype.set_left = function(x) {
        this.left = x;
    };
    t.prototype.get_left = function() {
        return this.left;
    };
    return t;
})();
Pit.Test.LetTests.Test.get_v = 0;
Pit.Test.LetTests.run = function() {
    module("Let Tests");
    test("let declare", function() {
        var x = 1;
        return equal(x, 1, "Let Declare 1");
    });
    test("let declare 2", function() {
        var f = (function(x) {
            return (x + 1);
        });
        return equal(f(1), 2, "Let Declare 2");
    });
    test("let declare 3", function() {
        var cylinderVolume = function(radius) {
                return function(length) {
                    var pi = 3.14159;
                    return (((length * pi) * radius) * radius);
                };
            };
        var vol = cylinderVolume(2)(3);
        return equal(Pit.FSharp.Core.Operators.op_PipeRight(vol)((function(value) {
            return Pit.FSharp.Core.Operators.ToInt(value);
        })), 37, "Let Declare 3");
    });
    test("let recursive", function() {
        var fib = function(n) {
                return (function(thisObject) {
                    if (n < 2) {
                        return 1;
                    } else {
                        return (fib((n - 1)) + fib((n - 2)));
                    }
                })(this);
            };
        return equal(fib(10), 89, "Let Recursive 1");
    });
    test("let recursive 2", function() {
        var Even = function(x) {
                return (function(thisObject) {
                    if (x == 0) {
                        return true;
                    } else {
                        return Odd((x - 1));
                    }
                })(this);
            };
        var Odd = function(x) {
                return (function(thisObject) {
                    if (x == 1) {
                        return true;
                    } else {
                        return Even((x - 1));
                    }
                })(this);
            };
        var e = Even(2);
        equal(e, true, "Let Recursive 2");
        var o = Odd(3);
        return equal(o, true, "Let Recursive 2");
    });
    test("let function values", function() {
        var apply1 = function(transform) {
                return function(y) {
                    return transform(y);
                };
            };
        var increment = (function(x) {
            return (x + 1);
        });
        var result1 = apply1(increment)(100);
        return equal(result1, 101, "Let Function Values");
    });
    test("let lambda functions", function() {
        var apply1 = function(transform) {
                return function(y) {
                    return transform(y);
                };
            };
        var result3 = apply1((function(x) {
            return (x + 1);
        }))(100);
        return equal(result3, 101, "Let Lambda Fucntions");
    });
    test("let function composition", function() {
        var function1 = (function(x) {
            return (x + 1);
        });
        var function2 = (function(x) {
            return (x * 2);
        });
        var h = Pit.FSharp.Core.Operators.op_ComposeRight(function1)(function2);
        var result5 = h(100);
        return equal(result5, 202, "Let Function Composition");
    });
    test("let tuple", function() {
        var patternInput = {
            Item1: 1,
            Item2: 2,
            Item3: 3
        };
        var k = patternInput.Item3;
        var j = patternInput.Item2;
        var i = patternInput.Item1;
        equal(i, 1, "Let Tuple 1");
        equal(j, 2, "Let Tuple 1");
        return equal(k, 3, "Let Tuple 1");
    });
    test("let tuple2", function() {
        var function2 = function(tupledArg) {
                var a = tupledArg.Item1;
                var b = tupledArg.Item2;
                return (a + b);
            };
        var f = function2({
            Item1: 10,
            Item2: 10
        });
        return equal(f, 20, "Let Tuple 2");
    });
    test("let mutable", function() {
        var x = 0;
        equal(x, 0, "Let Mutable");
        x = (x + 1);
        return equal(x, 1, "Let Mutable");
    });
    test("let mutable setter", function() {
        var t = new Pit.Test.LetTests.t("10");
        var x = 20;
        t.set_left((function() {
            var copyOfStruct = Pit.FSharp.Core.Operators.ToDouble(x);
            return copyOfStruct.toString();
        })());
        return equal(t.get_left(), "20", "Let Mutable Setter");
    });
    return test("let mutable module", function() {
        Pit.Test.LetTests.Test.get_v = 10;
        return equal(Pit.Test.LetTests.Test.get_v, 10, "Let Mutable Setter in Module");
    });
};
Pit.Test.ForTests.run = function() {
    module("For Loop");
    test("for simple", function() {
        var acc = 0;
        for (var i = 1; i <= 3; i++) {
            (function(thisObject, i) {
                acc = (acc + 1);
            })(this, i);
        };
        return equal(acc, 3, "for simple");
    });
    test("for functions", function() {
        var beginning = function(x) {
                return (function(y) {
                    return (x - (2 * y));
                });
            };
        var ending = function(x) {
                return (function(y) {
                    return (x + (2 * y));
                });
            };
        var function3 = function(x) {
                return function(y) {
                    var acc = 1;
                    for (var i = beginning(x)(y); i <= ending(x)(y); i++) {
                        (function(thisObject, i) {
                            acc = (acc + 1);
                            equal(acc, i, "For Functions");
                        })(this, i);
                    };
                };
            };
        return function3(10)(4);
    });
    test("for in declare", function() {
        var count = 0;
        var list1 = Pit.FSharp.Collections.ListModule.OfArray([1, 5, 100, 450, 788]);
        var enumerator = list1.IEnumerable1_GetEnumerator();
        (function(thisObject) {
            try {
                while (enumerator.IEnumerator_MoveNext()) {
                    var forLoopVar = enumerator.IEnumerator1_get_Current();
                    count = (count + 1);
                }
            } finally {
                (function(thisObject) {
                    if (Pit.JsCommon.containsInterface(enumerator, "__getIDisposable")) {
                        return enumerator.IDisposable_Dispose();
                    } else {
                        return null;
                    }
                })(thisObject)
            }
        })(this);
        return equal(list1.get_Length(), count, "For In Declare 1");
    });
    return test("for in declare2", function() {
        var seq1 = Pit.FSharp.Core.Operators.CreateSequence(Pit.FSharp.Collections.SeqModule.Delay((function() {
            return Pit.FSharp.Collections.SeqModule.Map(function(i) {
                return {
                    Item1: i,
                    Item2: (i * i)
                };
            })(Pit.FSharp.Core.Operators.op_Range(1)(10));
        })));
        var enumerator = seq1.IEnumerable1_GetEnumerator();
        return (function(thisObject) {
            try {
                while (enumerator.IEnumerator_MoveNext()) {
                    var forLoopVar = enumerator.IEnumerator1_get_Current();
                    var asqr = forLoopVar.Item2;
                    var a = forLoopVar.Item1;
                    equal((a * a), asqr, "For In Declare 2");
                }
            } finally {
                (function(thisObject) {
                    if (Pit.JsCommon.containsInterface(enumerator, "__getIDisposable")) {
                        return enumerator.IDisposable_Dispose();
                    } else {
                        return null;
                    }
                })(thisObject)
            }
        })(this);
    });
};
Pit.Test.DelegateTests.run = function() {
    module("Delegate Tests");
    test("Declare1", function() {
        var f1 = function(tupledArg) {
                var a = tupledArg.Item1;
                var b = tupledArg.Item2;
                return (a + b);
            };
        var r = f1({
            Item1: 1,
            Item2: 2
        });
        return equal(r, 3, "Delegate Declare1 Test");
    });
    return test("Declare2", function() {
        var f1 = function(a, b) {
                return (a + b);
            };
        var r = f1(1, 2);
        return equal(r, 3, "Delegate Declare2 Test");
    });
};
