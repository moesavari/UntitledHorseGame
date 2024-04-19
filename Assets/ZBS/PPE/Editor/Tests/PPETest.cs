#if UNITY_5_3_OR_NEWER
using NUnit.Framework;
using UnityEngine;
using ZBS.PPEHelpers;
using System;

namespace ZBS.Tests
{
	[TestFixture]
	public class PPETest
	{
		[SetUp]
		public void Init()
		{
			PPEHelper.Instance.InitCrypto("pnjiSHxJ");
		}

		[TearDown]
		public void Destroy()
		{
			PPEHelper.Instance.DestroyCrypto();
		}

		#region bool
		[Test]
		public void BoolTest()
		{
			string key = "BoolTest";
			bool boolValue = true;
			PPE.SetBool(key, boolValue);
			bool resultBoolValue = PPE.GetBool(key);

			Assert.AreEqual(boolValue, resultBoolValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void BoolCryptoTest()
		{
			string key = "BoolCryptoTest";
			bool boolValue = true;
			PPE.SetBool(key, boolValue, true);
			bool resultBoolValue = PPE.GetBool(key);

			Assert.AreEqual(boolValue, resultBoolValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void BoolArrayTest()
		{
			string key = "BoolArrayTest";
			bool[] boolArray = { true, true, false, false, true, false };
			PPE.SetBoolArray(key, boolArray);
			bool[] resultBoolArray = PPE.GetBoolArray(key);

			Assert.AreEqual(boolArray.Length, resultBoolArray.Length);

			for (int i = 0; i < boolArray.Length; i++)
			{
				Assert.AreEqual(boolArray[i], resultBoolArray[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void BoolArrayCryptoTest()
		{
			string key = "BoolArrayCryptoTest";
			bool[] boolArray = { true, true, false, false, true, false, true, false };
			PPE.SetBoolArray(key, boolArray, true);
			bool[] resultBoolArray = PPE.GetBoolArray(key);

			Assert.AreEqual(boolArray.Length, resultBoolArray.Length);

			for (int i = 0; i < boolArray.Length; i++)
			{
				Assert.AreEqual(boolArray[i], resultBoolArray[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region int
		[Test]
		public void IntTest()
		{
			string key = "IntTest";
			int intValue = 12234353;
			PPE.SetInt(key, intValue);
			int resultIntValue = PPE.GetInt(key);

			Assert.AreEqual(intValue, resultIntValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void IntCryptoTest()
		{
			string key = "IntCryptoTest";
			int intValue = 12234353;
			PPE.SetInt(key, intValue, true);
			int resultIntValue = PPE.GetInt(key);

			Assert.AreEqual(intValue, resultIntValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void IntArrayTest()
		{
			string key = "IntArrayTest";
			int[] intArray = { 3, 234, 4567, -345456456, 78, -356, 345667 };
			PPE.SetIntArray(key, intArray);
			int[] resultIntArray = PPE.GetIntArray(key);

			Assert.AreEqual(intArray.Length, resultIntArray.Length);

			for (int i = 0; i < intArray.Length; i++)
			{
				Assert.AreEqual(intArray[i], resultIntArray[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void IntArrayCryptoTest()
		{
			string key = "IntArrayCryptoTest";
			int[] intArray = { 3, 234, 4567, -345456456, 78, -356, 345667, 45, 23423 };
			PPE.SetIntArray(key, intArray, true);
			int[] resultIntArray = PPE.GetIntArray(key);

			Assert.AreEqual(intArray.Length, resultIntArray.Length);

			for (int i = 0; i < intArray.Length; i++)
			{
				Assert.AreEqual(intArray[i], resultIntArray[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region long
		[Test]
		public void LongTest()
		{
			string key = "LongTest";
			long longValue = 122343534534534533;
			PPE.SetLong(key, longValue);
			long resultLongValue = PPE.GetLong(key);

			Assert.AreEqual(longValue, resultLongValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void LongCryptoTest()
		{
			string key = "LongCryptoTest";
			long longValue = 3412234353345454533;
			PPE.SetLong(key, longValue, true);
			long resultLongValue = PPE.GetLong(key);

			Assert.AreEqual(longValue, resultLongValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void LongArrayTest()
		{
			string key = "LongArrayTest";
			long[] longArray = { 3235345656456, 234456456456, 456767868678, 345456456678, 78, 367856, 346786786785667 };
			PPE.SetLongArray(key, longArray);
			long[] resultLongArray = PPE.GetLongArray(key);

			Assert.AreEqual(longArray.Length, resultLongArray.Length);

			for (int i = 0; i < longArray.Length; i++)
			{
				Assert.AreEqual(longArray[i], resultLongArray[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void LongArrayCryptoTest()
		{
			string key = "LongArrayCryptoTest";
			long[] longArray = { 3235345656456, 234456456456, 456767868678, 345456456678, 78, 367856, 346786786785667, -12, -345354 };
			PPE.SetLongArray(key, longArray, true);
			long[] resultLongArray = PPE.GetLongArray(key);

			Assert.AreEqual(longArray.Length, resultLongArray.Length);

			for (int i = 0; i < longArray.Length; i++)
			{
				Assert.AreEqual(longArray[i], resultLongArray[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region float
		[Test]
		public void FloatTest()
		{
			string key = "FloatTest";
			float floatValue = 6786.0234f;
			PPE.SetFloat(key, floatValue);
			float resultFloatValue = PPE.GetFloat(key);

			Assert.AreEqual(floatValue, resultFloatValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void FloatCryptoTest()
		{
			string key = "FloatCryptoTest";
			float floatValue = 6786.0234f;
			PPE.SetFloat(key, floatValue, true);
			float resultFloatValue = PPE.GetFloat(key);

			Assert.AreEqual(floatValue, resultFloatValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void FloatArrayTest()
		{
			string key = "FloatArrayTest";
			float[] floatArray = { 334f, 234.0f, 4567.0f, 0, 0.2342343f, 35f, 345667f };
			PPE.SetFloatArray(key, floatArray);
			float[] resultFloatArray = PPE.GetFloatArray(key);

			Assert.AreEqual(floatArray.Length, resultFloatArray.Length);

			for (int i = 0; i < floatArray.Length; i++)
			{
				Assert.AreEqual(floatArray[i], resultFloatArray[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void FloatArrayCryptoTest()
		{
			string key = "FloatArrayCryptoTest";
			float[] floatArray = { 334f, 234.0f, 4567.0f, 0, 0.2342343f, 35f, 345667f, -13123.034f };
			PPE.SetFloatArray(key, floatArray, true);
			float[] resultFloatArray = PPE.GetFloatArray(key);

			Assert.AreEqual(floatArray.Length, resultFloatArray.Length);

			for (int i = 0; i < floatArray.Length; i++)
			{
				Assert.AreEqual(floatArray[i], resultFloatArray[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region double
		[Test]
		public void DoubleTest()
		{
			string key = "DoubleTest";
			double doubleValue = 6786.0234;
			PPE.SetDouble(key, doubleValue);
			double resultDoubleValue = PPE.GetDouble(key);

			Assert.AreEqual(doubleValue, resultDoubleValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void DoubleCryptoTest()
		{
			string key = "DoubleCryptoTest";
			double doubleValue = 6786.0234;
			PPE.SetDouble(key, doubleValue, true);
			double resultDoubleValue = PPE.GetDouble(key);

			Assert.AreEqual(doubleValue, resultDoubleValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void DoubleArrayTest()
		{
			string key = "DoubleArrayTest";
			double[] doubleArray = { 334, 234.0, 4567.0, 3, 2340.23443, 3565, 345667 };
			PPE.SetDoubleArray(key, doubleArray);
			double[] resultDoubleArray = PPE.GetDoubleArray(key);

			Assert.AreEqual(doubleArray.Length, resultDoubleArray.Length);

			for (int i = 0; i < doubleArray.Length; i++)
			{
				Assert.AreEqual(doubleArray[i], resultDoubleArray[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void DoubleArrayCryptoTest()
		{
			string key = "DoubleArrayCryptoTest";
			double[] doubleArray = { 334, 234.0, 4567.0, 3, 2340.23443, 3565, 345667, -13123131224234 };
			PPE.SetDoubleArray(key, doubleArray, true);
			double[] resultDoubleArray = PPE.GetDoubleArray(key);

			Assert.AreEqual(doubleArray.Length, resultDoubleArray.Length);

			for (int i = 0; i < doubleArray.Length; i++)
			{
				Assert.AreEqual(doubleArray[i], resultDoubleArray[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region Vector2
		[Test]
		public void Vector2Test()
		{
			string key = "Vector2Test";
			var vector2Value = new Vector2(234, 45.4f);
			PPE.SetVector2(key, vector2Value);
			var resultVector2Value = PPE.GetVector2(key);

			Assert.AreEqual(vector2Value, resultVector2Value);

			PPE.DeleteKey(key);
		}

		[Test]
		public void Vector2CryptoTest()
		{
			string key = "Vector2CryptoTest";
			var vector2Value = new Vector2(234, 45.4f);
			PPE.SetVector2(key, vector2Value, true);
			var resultVector2Value = PPE.GetVector2(key);

			Assert.AreEqual(vector2Value, resultVector2Value);

			PPE.DeleteKey(key);
		}

		[Test]
		public void Vector2ArrayTest()
		{
			string key = "Vector2ArrayTest";
			Vector2[] vector2Array = { new Vector2(0, 1), new Vector2(45, 456456), new Vector2(-234, 24234) };
			PPE.SetVector2Array(key, vector2Array);
			Vector2[] resultVector2Array = PPE.GetVector2Array(key);

			Assert.AreEqual(vector2Array.Length, resultVector2Array.Length);

			for (int i = 0; i < vector2Array.Length; i++)
			{
				Assert.AreEqual(vector2Array[i], resultVector2Array[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void Vector2ArrayCryptoTest()
		{
			string key = "Vector2ArrayCryptoTest";
			Vector2[] vector2Array = { new Vector2(0, 1), new Vector2(45, 456456), new Vector2(-234, 24234) };
			PPE.SetVector2Array(key, vector2Array, true);
			Vector2[] resultVector2Array = PPE.GetVector2Array(key);

			Assert.AreEqual(vector2Array.Length, resultVector2Array.Length);

			for (int i = 0; i < vector2Array.Length; i++)
			{
				Assert.AreEqual(vector2Array[i], resultVector2Array[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region Vector3
		[Test]
		public void Vector3Test()
		{
			string key = "Vector3Test";
			var vector3Value = new Vector3(234, 45.4f, -456456);
			PPE.SetVector3(key, vector3Value);
			var resultVector3Value = PPE.GetVector3(key);

			Assert.AreEqual(vector3Value, resultVector3Value);

			PPE.DeleteKey(key);
		}

		[Test]
		public void Vector3CryptoTest()
		{
			string key = "Vector3CryptoTest";
			var vector3Value = new Vector3(234, 45.4f, -456456);
			PPE.SetVector3(key, vector3Value, true);
			var resultVector3Value = PPE.GetVector3(key);

			Assert.AreEqual(vector3Value, resultVector3Value);

			PPE.DeleteKey(key);
		}

		[Test]
		public void Vector3ArrayTest()
		{
			string key = "Vector3ArrayTest";
			Vector3[] vector3Array = { new Vector3(-110, 2345345), new Vector3(-45, 111, -123), new Vector3(-234, 24234, 345) };
			PPE.SetVector3Array(key, vector3Array);
			Vector3[] resultVector3Array = PPE.GetVector3Array(key);

			Assert.AreEqual(vector3Array.Length, resultVector3Array.Length);

			for (int i = 0; i < vector3Array.Length; i++)
			{
				Assert.AreEqual(vector3Array[i], resultVector3Array[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void Vector3ArrayCryptoTest()
		{
			string key = "Vector3ArrayCryptoTest";
			Vector3[] vector3Array = { new Vector3(-110, 2345345), new Vector3(-45, 111, -123), new Vector3(-234, 24234, 345) };
			PPE.SetVector3Array(key, vector3Array, true);
			Vector3[] resultVector3Array = PPE.GetVector3Array(key);

			Assert.AreEqual(vector3Array.Length, resultVector3Array.Length);

			for (int i = 0; i < vector3Array.Length; i++)
			{
				Assert.AreEqual(vector3Array[i], resultVector3Array[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region Vector4
		[Test]
		public void Vector4Test()
		{
			string key = "Vector4Test";
			var vector4Value = new Vector4(234, 45.4f, -456456, 234);
			PPE.SetVector4(key, vector4Value);
			var resultVector4Value = PPE.GetVector4(key);

			Assert.AreEqual(vector4Value, resultVector4Value);

			PPE.DeleteKey(key);
		}

		[Test]
		public void Vector4CryptoTest()
		{
			string key = "Vector4CryptoTest";
			var vector4Value = new Vector4(234, 45.4f, -456456, 234);
			PPE.SetVector4(key, vector4Value, true);
			var resultVector4Value = PPE.GetVector4(key);

			Assert.AreEqual(vector4Value, resultVector4Value);

			PPE.DeleteKey(key);
		}

		[Test]
		public void Vector4ArrayTest()
		{
			string key = "Vector4ArrayTest";
			Vector4[] vector4Array = { new Vector4(-110, 2345345, 234678, 456), new Vector4(-45, 111, -78923), new Vector4(-234, 0, -345, -111111111) };
			PPE.SetVector4Array(key, vector4Array);
			Vector4[] resultVector4Array = PPE.GetVector4Array(key);

			Assert.AreEqual(vector4Array.Length, resultVector4Array.Length);

			for (int i = 0; i < vector4Array.Length; i++)
			{
				Assert.AreEqual(vector4Array[i], resultVector4Array[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void Vector4ArrayCryptoTest()
		{
			string key = "Vector4ArrayCryptoTest";
			Vector4[] vector4Array = { new Vector4(-110, 2345345, 234678, 456), new Vector4(-45, 111, -78923), new Vector4(-234, 0, -345, -111111111) };
			PPE.SetVector4Array(key, vector4Array, true);
			Vector4[] resultVector4Array = PPE.GetVector4Array(key);

			Assert.AreEqual(vector4Array.Length, resultVector4Array.Length);

			for (int i = 0; i < vector4Array.Length; i++)
			{
				Assert.AreEqual(vector4Array[i], resultVector4Array[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region Quaternion
		[Test]
		public void QuaternionTest()
		{
			string key = "QuaternionTest";
			var quaternionValue = new Quaternion(234, 45.4f, -456456, 234);
			PPE.SetQuaternion(key, quaternionValue);
			var resultQuaternionValue = PPE.GetQuaternion(key);

			Assert.AreEqual(quaternionValue, resultQuaternionValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void QuaternionCryptoTest()
		{
			string key = "QuaternionCryptoTest";
			var quaternionValue = new Quaternion(234, 45.4f, -456456, 234);
			PPE.SetQuaternion(key, quaternionValue, true);
			var resultQuaternionValue = PPE.GetQuaternion(key);

			Assert.AreEqual(quaternionValue, resultQuaternionValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void QuaternionArrayTest()
		{
			string key = "QuaternionArrayTest";
			Quaternion[] quaternionArray = { new Quaternion(-110, 2345345, 234678, 456), new Quaternion(-45, 111, -78923, 23346), new Quaternion(-234, 0, -345, -111111111) };
			PPE.SetQuaternionArray(key, quaternionArray);
			Quaternion[] resultQuaternionArray = PPE.GetQuaternionArray(key);

			Assert.AreEqual(quaternionArray.Length, resultQuaternionArray.Length);

			for (int i = 0; i < quaternionArray.Length; i++)
			{
				Assert.AreEqual(quaternionArray[i], resultQuaternionArray[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void QuaternionArrayCryptoTest()
		{
			string key = "QuaternionArrayCryptoTest";
			Quaternion[] quaternionArray = { new Quaternion(-110, 2345345, 234678, 456), new Quaternion(-45, 111, -78923, 2), new Quaternion(-234, 0, -345, -111111111) };
			PPE.SetQuaternionArray(key, quaternionArray, true);
			Quaternion[] resultQuaternionArray = PPE.GetQuaternionArray(key);

			Assert.AreEqual(quaternionArray.Length, resultQuaternionArray.Length);

			for (int i = 0; i < quaternionArray.Length; i++)
			{
				Assert.AreEqual(quaternionArray[i], resultQuaternionArray[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region Rect
		[Test]
		public void RectTest()
		{
			string key = "RectTest";
			var rectValue = new Rect(234, 45.4f, 456456, 234);
			PPE.SetRect(key, rectValue);
			var resultRectValue = PPE.GetRect(key);

			Assert.AreEqual(rectValue, resultRectValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void RectCryptoTest()
		{
			string key = "RectCryptoTest";
			var rectValue = new Rect(-234, 3445.4f, 456456, 234);
			PPE.SetRect(key, rectValue, true);
			var resultRectValue = PPE.GetRect(key);

			Assert.AreEqual(rectValue, resultRectValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void RectArrayTest()
		{
			string key = "RectArrayTest";
			Rect[] rectArray = { new Rect(-110, 2345345, 234678, 456), new Rect(-45, 111, 78923, 23346), new Rect(-234, 0, 345, 111111111) };
			PPE.SetRectArray(key, rectArray);
			Rect[] resultRectArray = PPE.GetRectArray(key);

			Assert.AreEqual(rectArray.Length, resultRectArray.Length);

			for (int i = 0; i < rectArray.Length; i++)
			{
				Assert.AreEqual(rectArray[i], resultRectArray[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void RectArrayCryptoTest()
		{
			string key = "RectArrayCryptoTest";
			Rect[] rectArray = { new Rect(-110, 2345345, 234678, 456), new Rect(-45, 111, 78923, 2), new Rect(-234, 0, 7345, 341111) };
			PPE.SetRectArray(key, rectArray, true);
			Rect[] resultRectArray = PPE.GetRectArray(key);

			Assert.AreEqual(rectArray.Length, resultRectArray.Length);

			for (int i = 0; i < rectArray.Length; i++)
			{
				Assert.AreEqual(rectArray[i], resultRectArray[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region Color
		[Test]
		public void ColorTest()
		{
			string key = "ColorTest";
			var colorValue = new Color(0.24f, 0.454f, 0.456456f, 1.0f);
			PPE.SetColor(key, colorValue);
			var resultColorValue = PPE.GetColor(key);

			Assert.AreEqual(colorValue, resultColorValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void ColorCryptoTest()
		{
			string key = "ColorCryptoTest";
			var colorValue = new Color(0.24f, 0.454f, 0.456456f, 1.0f);
			PPE.SetColor(key, colorValue, true);
			var resultColorValue = PPE.GetColor(key);

			Assert.AreEqual(colorValue, resultColorValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void ColorArrayTest()
		{
			string key = "ColorArrayTest";
			Color[] colorArray = { new Color(0.45f, 0.111f, 0.78923f, 0.2f), new Color(0.110f, 0.2345345f, 1.0f, 0f), new Color(0.24f, 0.454f, 0.456456f, 1.0f) };
			PPE.SetColorArray(key, colorArray);
			Color[] resultColorArray = PPE.GetColorArray(key);

			Assert.AreEqual(colorArray.Length, resultColorArray.Length);

			for (int i = 0; i < colorArray.Length; i++)
			{
				Assert.AreEqual(colorArray[i], resultColorArray[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void ColorArrayCryptoTest()
		{
			string key = "ColorArrayCryptoTest";
			Color[] colorArray = { new Color(0.110f, 0.2345345f, 1.0f, 0f), new Color(0.45f, 0.111f, 0.78923f, 0.2f), new Color(0.24f, 0.454f, 0.456456f, 1.0f) };
			PPE.SetColorArray(key, colorArray, true);
			Color[] resultColorArray = PPE.GetColorArray(key);

			Assert.AreEqual(colorArray.Length, resultColorArray.Length);

			for (int i = 0; i < colorArray.Length; i++)
			{
				Assert.AreEqual(colorArray[i], resultColorArray[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region DateTime
		[Test]
		public void DateTimeTest()
		{
			string key = "DateTimeTest";
			DateTime dateTimeValue = DateTime.Now;
			PPE.SetDateTime(key, dateTimeValue);
			DateTime resultDateTimeValue = PPE.GetDateTime(key);

			var doubleValue = dateTimeValue.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
			var resultDubleValue = resultDateTimeValue.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

			Assert.AreEqual(doubleValue, resultDubleValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void DateTimeCryptoTest()
		{
			string key = "DateTimeCryptoTest";
			DateTime dateTimeValue = DateTime.Now;
			PPE.SetDateTime(key, dateTimeValue, true);
			DateTime resultDateTimeValue = PPE.GetDateTime(key);

			var doubleValue = dateTimeValue.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
			var resultDubleValue = resultDateTimeValue.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

			Assert.AreEqual(doubleValue, resultDubleValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void DateTimeArrayTest()
		{
			string key = "DateTimeArrayTest";
			DateTime[] dateTimeArray = { DateTime.Now, DateTime.Now, new DateTime(2012, 1, 5) };
			PPE.SetDateTimeArray(key, dateTimeArray);
			DateTime[] resultDateTimeArray = PPE.GetDateTimeArray(key);

			Assert.AreEqual(dateTimeArray.Length, resultDateTimeArray.Length);

			for (int i = 0; i < dateTimeArray.Length; i++)
			{
				var doubleValue = dateTimeArray[i].ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
				var resultDubleValue = resultDateTimeArray[i].ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

				Assert.AreEqual(doubleValue, resultDubleValue);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void DateTimeArrayCryptoTest()
		{
			string key = "DateTimeArrayCryptoTest";
			DateTime[] dateTimeArray = { DateTime.Now, DateTime.Now, new DateTime(2012, 1, 5) };
			PPE.SetDateTimeArray(key, dateTimeArray, true);
			DateTime[] resultDateTimeArray = PPE.GetDateTimeArray(key);

			Assert.AreEqual(dateTimeArray.Length, resultDateTimeArray.Length);

			for (int i = 0; i < dateTimeArray.Length; i++)
			{
				var doubleValue = dateTimeArray[i].ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
				var resultDubleValue = resultDateTimeArray[i].ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

				Assert.AreEqual(doubleValue, resultDubleValue);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region string
		[Test]
		public void StringTest()
		{
			string key = "StringTest";
			string stringValue = "asdsdhfih iusdh fshd fihsdif h si dufh";
			PPE.SetString(key, stringValue);
			string resultStringValue = PPE.GetString(key);

			Assert.AreEqual(stringValue, resultStringValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void StringCryptoTest()
		{
			string key = "StringCryptoTest";
			string stringValue = "asdadas dqdeqwe 123 123 12 alndklajnsdjk nad";
			PPE.SetString(key, stringValue, true);
			string resultStringValue = PPE.GetString(key);

			Assert.AreEqual(stringValue, resultStringValue);

			PPE.DeleteKey(key);
		}

		[Test]
		public void StringArrayTest()
		{
			string key = "StringArrayTest";
			string[] stringArray = { "a", "asd as da ", string.Empty, " ", "", "qqqqQQQQQQ" };
			PPE.SetStringArray(key, stringArray);
			string[] resultStringArray = PPE.GetStringArray(key);

			Assert.AreEqual(stringArray.Length, resultStringArray.Length);

			for (int i = 0; i < stringArray.Length; i++)
			{
				Assert.AreEqual(stringArray[i], resultStringArray[i]);
			}

			PPE.DeleteKey(key);
		}

		[Test]
		public void StringArrayCryptoTest()
		{
			string key = "StringArrayCryptoTest";
			string[] stringArray = { "a", "asd as da ", string.Empty, " ", "", "qqqqQQQQQQ" };
			PPE.SetStringArray(key, stringArray, true);
			string[] resultStringArray = PPE.GetStringArray(key);

			Assert.AreEqual(stringArray.Length, resultStringArray.Length);

			for (int i = 0; i < stringArray.Length; i++)
			{
				Assert.AreEqual(stringArray[i], resultStringArray[i]);
			}

			PPE.DeleteKey(key);
		}
		#endregion

		#region Texture2D
		[Test]
		public void Texture2DTest()
		{
			string key = "Texture2DTest";
			Texture2D texture = GUI.skin.GetStyle("button").normal.background;
			PPE.SetTexture2D(key, texture);
			Texture2D resultTexture = PPE.GetTexture2D(key);

			Assert.AreEqual(texture.width, resultTexture.width);
			Assert.AreEqual(texture.height, resultTexture.height);
			Assert.AreEqual(texture.format, resultTexture.format);
			Assert.AreEqual(texture.mipmapCount, resultTexture.mipmapCount);

			PPE.DeleteKey(key);
		}

		[Test]
		public void Texture2DCryptoTest()
		{
			string key = "Texture2DCryptoTest";
			Texture2D texture = GUI.skin.GetStyle("button").normal.background;
			PPE.SetTexture2D(key, texture, true);
			Texture2D resultTexture = PPE.GetTexture2D(key);

			Assert.AreEqual(texture.width, resultTexture.width);
			Assert.AreEqual(texture.height, resultTexture.height);
			Assert.AreEqual(texture.format, resultTexture.format);
			Assert.AreEqual(texture.mipmapCount, resultTexture.mipmapCount);

			PPE.DeleteKey(key);
		}
		#endregion

		#region object
		[Serializable]
		public class PPETestPlayer
		{
			public string name;
			public int level;
			public bool isBot;

			public PPETestPlayer(string name, int level, bool isBot = false)
			{
				this.name = name;
				this.level = level;
				this.isBot = isBot;
			}
		}

		[Test]
		public void ObjectTest()
		{
			string key = "ObjectTest";
			var player = new PPETestPlayer("John", 105, true);
			PPE.SetObject(key, player);
			var resultPlayer = (PPETestPlayer)PPE.GetObject(key);

			Assert.AreEqual(player.name, resultPlayer.name);
			Assert.AreEqual(player.level, resultPlayer.level);
			Assert.AreEqual(player.isBot, resultPlayer.isBot);

			PPE.DeleteKey(key);
		}

		[Test]
		public void ObjectCryptoTest()
		{
			string key = "ObjectTest";
			var player = new PPETestPlayer("David", 80);
			PPE.SetObject(key, player, true);
			var resultPlayer = (PPETestPlayer)PPE.GetObject(key);

			Assert.AreEqual(player.name, resultPlayer.name);
			Assert.AreEqual(player.level, resultPlayer.level);
			Assert.AreEqual(player.isBot, resultPlayer.isBot);

			PPE.DeleteKey(key);
		}
		#endregion
	}
}
#endif