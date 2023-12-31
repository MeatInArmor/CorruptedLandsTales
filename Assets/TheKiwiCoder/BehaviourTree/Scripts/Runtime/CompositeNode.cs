using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder
{

	[System.Serializable]
	public abstract class CompositeNode : Node
	{

		[HideInInspector]
		[SerializeReference]
		public List<Node> children = new List<Node>();

		public override void Validate()
		{
			for (int i = children.Count - 1; i >= 0; i--)
			{
				var n = children[i];
				if (n == null)
				{
					children.RemoveAt(i);
					continue;
				}
				n.Validate();
			}
		}
	}
}