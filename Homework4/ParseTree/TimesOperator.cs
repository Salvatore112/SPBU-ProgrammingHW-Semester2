﻿namespace ParseTreeSpace;

internal class TimesOperator : Operator
{
    public override INode LeftChild { get; set; }
    public override INode RightChild { get; set; }

    public override string Print()
        => $"( * {LeftChild.Print()} {RightChild.Print()} )";

    public override double Calculate()
        => this.LeftChild.Calculate() * this.RightChild.Calculate();

    internal TimesOperator(int leftValue, int rightValue)
    {
        this.LeftChild = new Operand(leftValue);
        this.RightChild = new Operand(rightValue);
    }

    internal TimesOperator(INode leftNode, int rightValue)
    {
        this.LeftChild = leftNode;
        this.RightChild = new Operand(rightValue);
    }

    internal TimesOperator(int leftValue, INode rightNode)
    {
        this.LeftChild = new Operand(leftValue);
        this.RightChild = rightNode;
    }

    internal TimesOperator(INode leftNode, INode rightNode)
    {
        this.LeftChild = leftNode;
        this.RightChild = rightNode;
    }

    internal TimesOperator()
    {

    }
}
