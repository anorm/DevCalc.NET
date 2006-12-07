using System;
using System.Collections;

namespace DevCalcNET
{
	public class MathNodeCollection : CollectionBase
	{
		public MathNode this[ int index ]  
		{
			get  
			{
				return( (MathNode) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}

		public int Add( MathNode value )  
		{
			return( List.Add( value ) );
		}

		public int IndexOf( MathNode value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, MathNode value )  
		{
			List.Insert( index, value );
		}

		public void Remove( MathNode value )  
		{
			List.Remove( value );
		}

		public bool Contains( MathNode value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}

		public MathNodeCollection()
		{
		}
	}
}
