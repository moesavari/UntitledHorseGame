using UnityEngine;

namespace ZBS
{
	public class PPEBaseType
	{
		public string type;
		public string shortType;
	}

	public class PPEBoolType : PPEBaseType
	{
		public PPEBoolType()
		{
			type = "bool";
			shortType = "b";
		}
	}

	public class PPEBoolArrayType : PPEBaseType
	{
		public PPEBoolArrayType()
		{
			type = "boolArray";
			shortType = "b[]";
		}
	}

	public class PPEIntType : PPEBaseType
	{
		public PPEIntType()
		{
			type = "int";
			shortType = "i";
		}
	}

	public class PPEIntArrayType : PPEBaseType
	{
		public PPEIntArrayType()
		{
			type = "intArray";
			shortType = "i[]";
		}
	}

	public class PPELongType : PPEBaseType
	{
		public PPELongType()
		{
			type = "long";
			shortType = "l";
		}
	}

	public class PPELongArrayType : PPEBaseType
	{
		public PPELongArrayType()
		{
			type = "longArray";
			shortType = "l[]";
		}
	}

	public class PPEFloatType : PPEBaseType
	{
		public PPEFloatType()
		{
			type = "float";
			shortType = "f";
		}
	}

	public class PPEFloatArrayType : PPEBaseType
	{
		public PPEFloatArrayType()
		{
			type = "floatArray";
			shortType = "f[]";
		}
	}

	public class PPEDoubleType : PPEBaseType
	{
		public PPEDoubleType()
		{
			type = "double";
			shortType = "d";
		}
	}

	public class PPEDoubleArrayType : PPEBaseType
	{
		public PPEDoubleArrayType()
		{
			type = "doubleArray";
			shortType = "d[]";
		}
	}

	public class PPEVector2Type : PPEBaseType
	{
		public PPEVector2Type()
		{
			type = "Vector2";
			shortType = "v2";
		}
	}

	public class PPEVector2ArrayType : PPEBaseType
	{
		public PPEVector2ArrayType()
		{
			type = "Vector2Array";
			shortType = "v2[]";
		}
	}

	public class PPEVector3Type : PPEBaseType
	{
		public PPEVector3Type()
		{
			type = "Vector3";
			shortType = "v3";
		}
	}

	public class PPEVector3ArrayType : PPEBaseType
	{
		public PPEVector3ArrayType()
		{
			type = "Vector3Array";
			shortType = "v3[]";
		}
	}

	public class PPEVector4Type : PPEBaseType
	{
		public PPEVector4Type()
		{
			type = "Vector4";
			shortType = "v4";
		}
	}

	public class PPEVector4ArrayType : PPEBaseType
	{
		public PPEVector4ArrayType()
		{
			type = "Vector4Array";
			shortType = "v4[]";
		}
	}

	public class PPEQuaternionType : PPEBaseType
	{
		public PPEQuaternionType()
		{
			type = "Quaternion";
			shortType = "q";
		}
	}

	public class PPEQuaternionArrayType : PPEBaseType
	{
		public PPEQuaternionArrayType()
		{
			type = "QuaternionArray";
			shortType = "q[]";
		}
	}

	public class PPERectType : PPEBaseType
	{
		public PPERectType()
		{
			type = "Rect";
			shortType = "r";
		}
	}

	public class PPERectArrayType : PPEBaseType
	{
		public PPERectArrayType()
		{
			type = "RectArray";
			shortType = "r[]";
		}
	}

	public class PPEColorType : PPEBaseType
	{
		public PPEColorType()
		{
			type = "Color";
			shortType = "c";
		}
	}

	public class PPEColorArrayType : PPEBaseType
	{
		public PPEColorArrayType()
		{
			type = "ColorArray";
			shortType = "c[]";
		}
	}

	public class PPEDateTimeType : PPEBaseType
	{
		public PPEDateTimeType()
		{
			type = "datetime";
			shortType = "dt";
		}
	}

	public class PPEDateTimeArrayType : PPEBaseType
	{
		public PPEDateTimeArrayType()
		{
			type = "datetimeArray";
			shortType = "dt[]";
		}
	}

	public class PPEStringType : PPEBaseType
	{
		public PPEStringType()
		{
			type = "string";
			shortType = "s";
		}
	}

	public class PPEStringArrayType : PPEBaseType
	{
		public PPEStringArrayType()
		{
			type = "stringArray";
			shortType = "s[]";
		}
	}

	public class PPETexture2DType : PPEBaseType
	{
		public PPETexture2DType()
		{
			type = "texture2D";
			shortType = "t";
		}
	}

	public class PPEObjectType : PPEBaseType
	{
		public PPEObjectType()
		{
			type = "Object";
			shortType = "o";
		}
	}

	#region Utils
	public static class PPETypeUtil
	{
		public static PPEBaseType GetType(string shortType)
		{
			switch (shortType)
			{
				case "b":
					return new PPEBoolType();

				case "b[]":
					return new PPEBoolArrayType();

				case "i":
					return new PPEIntType();

				case "i[]":
					return new PPEIntArrayType();

				case "l":
					return new PPELongType();

				case "l[]":
					return new PPELongArrayType();

				case "f":
					return new PPEFloatType();

				case "f[]":
					return new PPEFloatArrayType();

				case "d":
					return new PPEDoubleType();

				case "d[]":
					return new PPEDoubleArrayType();

				case "v2":
					return new PPEVector2Type();

				case "v2[]":
					return new PPEVector2ArrayType();

				case "v3":
					return new PPEVector3Type();

				case "v3[]":
					return new PPEVector3ArrayType();

				case "v4":
					return new PPEVector4Type();

				case "v4[]":
					return new PPEVector4ArrayType();

				case "q":
					return new PPEQuaternionType();

				case "q[]":
					return new PPEQuaternionArrayType();

				case "r":
					return new PPERectType();

				case "r[]":
					return new PPERectArrayType();

				case "c":
					return new PPEColorType();

				case "c[]":
					return new PPEColorArrayType();

				case "dt":
					return new PPEDateTimeType();

				case "dt[]":
					return new PPEDateTimeArrayType();

				case "s":
					return new PPEStringType();

				case "s[]":
					return new PPEStringArrayType();

				case "t":
					return new PPETexture2DType();

				case "o":
					return new PPEObjectType();

				default:
					Debug.LogError("Need to implement type for shortType: " + shortType);
					break;
			}

			return new PPEBaseType();
		}
	}
	#endregion
}