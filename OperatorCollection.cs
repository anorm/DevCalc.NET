using System;
using System.Collections;

namespace DevCalc.NET
{
	public class OperatorCollection : CollectionBase
	{
		public Operator this[ int index ]  
		{
			get  
			{
				return( (Operator) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}

		public int Add( Operator value )  
		{
			return( List.Add( value ) );
		}

		public int IndexOf( Operator value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, Operator value )  
		{
			List.Insert( index, value );
		}

		public void Remove( Operator value )  
		{
			List.Remove( value );
		}

		public bool Contains( Operator value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}

		public OperatorCollection()
		{
		}
	}
}
