namespace ThingsGateway.RulesEngine;

public abstract class VariableNode : TextNode
{

    public VariableNode(string id, Point? position = null) : base(id, position)
    {
    }

    [ModelValue]
    public string DeviceText { get; set; }
}
