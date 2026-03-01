namespace IIP2;


public abstract class PipelineStep<TIn, TOut>
{
    public abstract TOut Process(TIn input);

    public PipelineStep<TIn, TNextOut> Step<TNextOut>(PipelineStep<TOut, TNextOut> nextStep)
    {
        return new WrapperStep<TIn, TOut, TNextOut>(this, nextStep);
    }
}

public class WrapperStep<TIn, TMid, TOut> : PipelineStep<TIn, TOut>
{
    private readonly PipelineStep<TIn, TMid> _first;
    private readonly PipelineStep<TMid, TOut> _second;

    public WrapperStep(PipelineStep<TIn, TMid> first, PipelineStep<TMid, TOut> second)
    {
        _first = first;
        _second = second;
    }

    public override TOut Process(TIn input)
    {
        TMid midRes = _first.Process(input); 
        return _second.Process(midRes);
    }
}