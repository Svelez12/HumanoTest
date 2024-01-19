namespace HumanoTest.Application.Models.Common;

using System;
using System.Linq.Expressions;

public class WhereIfModel<T> where T : class
{
    public WhereIfModel(bool condition, Expression<Func<T, bool>> predicate)
    {
        Condition = condition;
        Predicate = predicate;
    }

    public bool Condition { get; set; }
    public Expression<Func<T, bool>> Predicate { get; set; }
}