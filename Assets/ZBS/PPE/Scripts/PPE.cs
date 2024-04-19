using UnityEngine;
using System.Collections.Generic;
using ZBS.PPEHelpers;
using System;

namespace ZBS
{
	public static class PPE
	{
		/// <summary>
		/// The version of PPE [Player Prefs Extension]
		/// </summary>
		static public string version = "1.1.0";

		// TODO: Implement Dictionary

		#region Default
		/// <summary>
		/// Check a key in prefs.
		/// </summary>
		/// <returns><c>true</c>, if key is exist, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		public static bool HasKey(string key)
		{
			return PPEHelper.Instance.HasKey(key);
		}

		/// <summary>
		/// Save Player Prefs.
		/// </summary>
		public static void Save()
		{
			PPEHelper.Instance.Save();
		}

		/// <summary>
		/// Delete the key from Player Prefs.
		/// </summary>
		/// <param name="key">Key.</param>
		public static void DeleteKey(string key)
		{
			PPEHelper.Instance.DeleteKey(key);
		}

		/// <summary>
		/// Delete all keys.
		/// </summary>
		public static void DeleteAll()
		{
			PPEHelper.Instance.DeleteAll();
		}
		#endregion

		#region Crypto
		/// <summary>
		/// Init the crypto engine
		/// </summary>
		/// <param name="key">Crypto key.</param>
		public static void InitCrypto(string key)
		{
			PPEHelper.Instance.InitCrypto(key);
		}
		#endregion

		#region bool
		/// <summary>
		/// Call this function to save a bool to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetBool("abc", false);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if bool was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetBool(string key, bool value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.boolHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a bool from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetBool("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The bool.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">false</param>
		public static bool GetBool(string key, bool defaultValue = false)
		{
			return PPEHelper.Instance.boolHelper.Get(key, defaultValue);
		}
		#endregion

		#region bool[]
		/// <summary>
		/// Call this function to save array of bool to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	bool[] array = { true, false, true };
		///     PPE.SetBoolArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if bool array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetBoolArray(string key, bool[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.boolHelper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of bool to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<bool> list = new List<bool> { true, false, true };
		///     PPE.SetBoolList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if bool list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetBoolList(string key, List<bool> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.boolHelper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of bool from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetBoolArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The bool array.</returns>
		/// <param name="key">Key.</param>
		public static bool[] GetBoolArray(string key)
		{
			return PPEHelper.Instance.boolHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of bool from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetBoolList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The bool list.</returns>
		/// <param name="key">Key.</param>
		public static List<bool> GetBoolList(string key)
		{
			return PPEHelper.Instance.boolHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of bool from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetBoolArray("abc", true, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The bool array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default bool value.</param>
		/// <param name="defaultSize">2.</param>
		public static bool[] GetBoolArray(string key, bool defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.boolHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of bool from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetBoolList("abc", true, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The bool list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default bool value.</param>
		/// <param name="defaultSize">2.</param>
		public static List<bool> GetBoolList(string key, bool defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.boolHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region int, Int32
		/// <summary>
		/// Call this function to save a int to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetInt("abc", 123, true);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if int was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Int value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetInt(string key, int value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.intHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a int from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetInt("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The int.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">0</param>
		public static int GetInt(string key, int defaultValue = 0)
		{
			return PPEHelper.Instance.intHelper.Get(key, defaultValue);
		}
		#endregion

		#region int[]
		/// <summary>
		/// Call this function to save array of int to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	int[] array = { 1, 234234, -789 };
		///     PPE.SetIntArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if int array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Int array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetIntArray(string key, int[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.intHelper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of int to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<int> list = new List<int> { 1, 2, 3 };
		///     PPE.SetIntList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if int list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">Int list.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetIntList(string key, List<int> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.intHelper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of int from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetIntArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The int array.</returns>
		/// <param name="key">Key.</param>
		public static int[] GetIntArray(string key)
		{
			return PPEHelper.Instance.intHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of int from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetIntList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The int list.</returns>
		/// <param name="key">Key.</param>
		public static List<int> GetIntList(string key)
		{
			return PPEHelper.Instance.intHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of int from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetIntArray("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The int array.</returns>
		/// <param name="key">Key</param>
		/// <param name="defaultValue">Default int value</param>
		/// <param name="defaultSize">2</param>
		public static int[] GetIntArray(string key, int defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.intHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of int from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetIntList("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The int list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default int value.</param>
		/// <param name="defaultSize">2</param>
		public static List<int> GetIntList(string key, int defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.intHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region long, Int64
		/// <summary>
		/// Call this function to save a long to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetLong("abc", 122342342343, true);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if long was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetLong(string key, long value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.longHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a long from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetLong("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The long.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">0</param>
		public static long GetLong(string key, long defaultValue = 0)
		{
			return PPEHelper.Instance.longHelper.Get(key, defaultValue);
		}
		#endregion

		#region long[]
		/// <summary>
		/// Call this function to save array of long to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	int[] array = { 234234231, 234232342344, -789 };
		///     PPE.SetLongArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if long array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetLongArray(string key, long[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.longHelper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of long to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<long> list = new List<long> { 1345345345345, 2, 3 };
		///     PPE.SetLongList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if long list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetLongList(string key, List<long> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.longHelper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of long from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetLongArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The long array.</returns>
		/// <param name="key">Key.</param>
		public static long[] GetLongArray(string key)
		{
			return PPEHelper.Instance.longHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of long from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetLongList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The long list.</returns>
		/// <param name="key">Key.</param>
		public static List<long> GetLongList(string key)
		{
			return PPEHelper.Instance.longHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of long from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetLongArray("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The long array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default long value.</param>
		/// <param name="defaultSize">2</param>
		public static long[] GetLongArray(string key, long defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.longHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of long from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetLongList("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The long list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default long value.</param>
		/// <param name="defaultSize">2</param>
		public static List<long> GetLongList(string key, long defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.longHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region float
		/// <summary>
		/// Call this function to save a float to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetFloat("abc", 123.0f);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if float was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetFloat(string key, float value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.floatHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a float from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetFloat("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The float.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">0.0f</param>
		public static float GetFloat(string key, float defaultValue = 0.0f)
		{
			return PPEHelper.Instance.floatHelper.Get(key, defaultValue);
		}
		#endregion

		#region float[]
		/// <summary>
		/// Call this function to save array of float to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	float[] array = { 23423.0f, 234232342344.0f, -789.0345f };
		///     PPE.SetFloatArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if float array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetFloatArray(string key, float[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.floatHelper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of float to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<float> list = new List<float> { 1345345.0f, 2.0f, 3.0f };
		///     PPE.SetFloatList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if float list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetFloatList(string key, List<float> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.floatHelper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of float from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetFloatArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The float array.</returns>
		/// <param name="key">Key.</param>
		public static float[] GetFloatArray(string key)
		{
			return PPEHelper.Instance.floatHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of float from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetFloatList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The float list.</returns>
		/// <param name="key">Key.</param>
		public static List<float> GetFloatList(string key)
		{
			return PPEHelper.Instance.floatHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of float from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetFloatArray("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The float array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default float value.</param>
		/// <param name="defaultSize">2</param>
		public static float[] GetFloatArray(string key, float defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.floatHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of float from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetFloatList("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The float list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default float value.</param>
		/// <param name="defaultSize">2</param>
		public static List<float> GetFloatList(string key, float defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.floatHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region double
		/// <summary>
		/// Call this function to save a double to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetDouble("abc", 12334546756.0);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if double was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetDouble(string key, double value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.doubleHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a double from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetDouble("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The double.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">0</param>
		public static double GetDouble(string key, double defaultValue = 0)
		{
			return PPEHelper.Instance.doubleHelper.Get(key, defaultValue);
		}
		#endregion

		#region double[]
		/// <summary>
		/// Call this function to save array of double to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	double[] array = { 23423.0, 234232342344.0, -789.0345 };
		///     PPE.SetDoubleArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if double array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetDoubleArray(string key, double[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.doubleHelper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of double to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<double> list = new List<double> { 1345345345345.0, 2.0, 3.0 };
		///     PPE.SetDoubleList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if double list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetDoubleList(string key, List<double> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.doubleHelper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of double from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetDoubleArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The double array.</returns>
		/// <param name="key">Key.</param>
		public static double[] GetDoubleArray(string key)
		{
			return PPEHelper.Instance.doubleHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of double from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetDoubleList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The double list.</returns>
		/// <param name="key">Key.</param>
		public static List<double> GetDoubleList(string key)
		{
			return PPEHelper.Instance.doubleHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of double from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetDoubleArray("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The double array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default double value.</param>
		/// <param name="defaultSize">2</param>
		public static double[] GetDoubleArray(string key, double defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.doubleHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of double from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetDoubleList("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The double list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default double value.</param>
		/// <param name="defaultSize">2</param>
		public static List<double> GetDoubleList(string key, double defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.doubleHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region Vector2
		/// <summary>
		/// Call this function to save a Vector2 to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetVector2("abc", new Vector2(1, 2));
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if vector2 was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetVector2(string key, Vector2 value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.vector2Helper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a Vector2 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetVector2("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector2.</returns>
		/// <param name="key">Key.</param>
        /// <param name="defaultValue">Vector2(0.0f, 0.0f)</param>
		public static Vector2 GetVector2(string key, Vector2 defaultValue = default(Vector2))
		{
			return PPEHelper.Instance.vector2Helper.Get(key, defaultValue);
		}
		#endregion

		#region Vector2[]
		/// <summary>
		/// Call this function to save array of Vector2 to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	Vector2[] array = { Vector2.zero, new Vector2(1, 2) };
		///     PPE.SetVector2Array("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if Vector2 array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetVector2Array(string key, Vector2[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.vector2Helper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of Vector2 to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<Vector2> list = new List<Vector2> { Vector2.zero, new Vector2(1, 2) };
		///     PPE.SetVector2List("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if Vector2 list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetVector2List(string key, List<Vector2> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.vector2Helper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of Vector2 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetVector2Array("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector2 array.</returns>
		/// <param name="key">Key.</param>
		public static Vector2[] GetVector2Array(string key)
		{
			return PPEHelper.Instance.vector2Helper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of Vector2 from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetVector2List("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector2 list.</returns>
		/// <param name="key">Key.</param>
		public static List<Vector2> GetVector2List(string key)
		{
			return PPEHelper.Instance.vector2Helper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of Vector2 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetVector2Array("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector2 array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Vector2 value.</param>
		/// <param name="defaultSize">2</param>
		public static Vector2[] GetVector2Array(string key, Vector2 defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.vector2Helper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of Vector2 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetVector2List("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector2 list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Vector2 value.</param>
		/// <param name="defaultSize">2</param>
		public static List<Vector2> GetVector2List(string key, Vector2 defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.vector2Helper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region Vector3
		/// <summary>
		/// Call this function to save a Vector3 to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetVector3("abc", new Vector3(1, 2));
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if Vector3 was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetVector3(string key, Vector3 value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.vector3Helper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a Vector3 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetVector3("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector3.</returns>
		/// <param name="key">Key.</param>
        /// <param name="defaultValue">Vector3(0.0f, 0.0f, 0.0f)</param>
		public static Vector3 GetVector3(string key, Vector3 defaultValue = default(Vector3))
		{
			return PPEHelper.Instance.vector3Helper.Get(key, defaultValue);
		}
		#endregion

		#region Vector3[]
		/// <summary>
		/// Call this function to save array of Vector3 to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	Vector3[] array = { Vector3.zero, new Vector2(1, 2) };
		///     PPE.SetVector3Array("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if Vector3 array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetVector3Array(string key, Vector3[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.vector3Helper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of Vector3 to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<Vector3> list = new List<Vector2> { Vector3.zero, new Vector2(1, 2) };
		///     PPE.SetVector3List("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if Vector3 list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetVector3List(string key, List<Vector3> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.vector3Helper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of Vector3 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetVector3Array("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector3 array.</returns>
		/// <param name="key">Key.</param>
		public static Vector3[] GetVector3Array(string key)
		{
			return PPEHelper.Instance.vector3Helper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of Vector3 from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetVector3List("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector3 list.</returns>
		/// <param name="key">Key.</param>
		public static List<Vector3> GetVector3List(string key)
		{
			return PPEHelper.Instance.vector3Helper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of Vector3 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetVector3Array("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector3 array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Vector3 value.</param>
		/// <param name="defaultSize">2</param>
		public static Vector3[] GetVector3Array(string key, Vector3 defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.vector3Helper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of Vector3 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetVector3List("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector3 list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Vector3 value.</param>
		/// <param name="defaultSize">2</param>
		public static List<Vector3> GetVector3List(string key, Vector3 defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.vector3Helper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region Vector4
		/// <summary>
		/// Call this function to save a Vector4 to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetVector4("abc", new Vector4(1, 2));
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if Vector4 was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetVector4(string key, Vector4 value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.vector4Helper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a Vector4 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetVector4("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector4.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Vector4(0.0f, 0.0f, 0.0f, 0.0f)</param>
		public static Vector4 GetVector4(string key, Vector4 defaultValue = default(Vector4))
		{
			return PPEHelper.Instance.vector4Helper.Get(key, defaultValue);
		}
		#endregion

		#region Vector4[]
		/// <summary>
		/// Call this function to save array of Vector4 to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	Vector4[] array = { Vector4.zero, new Vector2(1, 2) };
		///     PPE.SetVector4Array("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if Vector4 array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetVector4Array(string key, Vector4[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.vector4Helper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of Vector4 to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<Vector4> list = new List<Vector2> { Vector3.zero, new Vector2(1, 2) };
		///     PPE.SetVector4List("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if Vector4 list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetVector4List(string key, List<Vector4> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.vector4Helper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of Vector4 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetVector4Array("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector4 array.</returns>
		/// <param name="key">Key.</param>
		public static Vector4[] GetVector4Array(string key)
		{
			return PPEHelper.Instance.vector4Helper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of Vector4 from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetVector4List("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector4 list.</returns>
		/// <param name="key">Key.</param>
		public static List<Vector4> GetVector4List(string key)
		{
			return PPEHelper.Instance.vector4Helper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of Vector4 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetVector4Array("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector4 array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Vector4 value.</param>
		/// <param name="defaultSize">2</param>
		public static Vector4[] GetVector4Array(string key, Vector4 defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.vector4Helper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of Vector4 from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetVector4List("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The Vector4 list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Vector4 value.</param>
		/// <param name="defaultSize">2</param>
		public static List<Vector4> GetVector4List(string key, Vector4 defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.vector4Helper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region Quaternion
		/// <summary>
		/// Call this function to save a Quaternion to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetQuaternion("abc", Quaternion.identity);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if quaternion was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetQuaternion(string key, Quaternion value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.quaternionHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a Quaternion from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetQuaternion("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The quaternion.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Quaternion(0.0f, 0.0f, 0.0f, 0.0f)</param>
		public static Quaternion GetQuaternion(string key, Quaternion defaultValue = default(Quaternion))
		{
			return PPEHelper.Instance.quaternionHelper.Get(key, defaultValue);
		}
		#endregion

		#region Quaternion[]
		/// <summary>
		/// Call this function to save array of Quaternion to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	Quaternion[] array = { Quaternion.identity, new Quaternion(1, 2, 2, 3) };
		///     PPE.SetQuaternionArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if quaternion array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetQuaternionArray(string key, Quaternion[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.quaternionHelper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of Quaternion to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<Quaternion> list = new List<Quaternion> { Quaternion.identity, Quaternion.identity };
		///     PPE.SetQuaternionList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if quaternion list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetQuaternionList(string key, List<Quaternion> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.quaternionHelper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of Quaternion from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetQuaternionArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The quaternion array.</returns>
		/// <param name="key">Key.</param>
		public static Quaternion[] GetQuaternionArray(string key)
		{
			return PPEHelper.Instance.quaternionHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of Quaternion from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetQuaternionList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The quaternion list.</returns>
		/// <param name="key">Key.</param>
		public static List<Quaternion> GetQuaternionList(string key)
		{
			return PPEHelper.Instance.quaternionHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of Quaternion from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetQuaternionArray("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The quaternion array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Quaternion value.</param>
		/// <param name="defaultSize">2</param>
		public static Quaternion[] GetQuaternionArray(string key, Quaternion defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.quaternionHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of Quaternion from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetQuaternionList("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The quaternion list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Quaternion value.</param>
		/// <param name="defaultSize">2</param>
		public static List<Quaternion> GetQuaternionList(string key, Quaternion defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.quaternionHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region Rect
		/// <summary>
		/// Call this function to save a Rect to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetRect("abc", new Rect(0, 0, 1, 10));
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if rect was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetRect(string key, Rect value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.rectHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a Rect from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetRect("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The rect.</returns>
		/// <param name="key">Key.</param>
        /// <param name="defaultValue">Rect(x:0 y:0 width:0 height:0)</param>
		public static Rect GetRect(string key, Rect defaultValue = default(Rect))
		{
			return PPEHelper.Instance.rectHelper.Get(key, defaultValue);
		}
		#endregion

		#region Rect[]
		/// <summary>
		/// Call this function to save array of Rect to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	Rect[] array = { new Rect(0, 0, 1, 10), new Rect(0, 0, 1, 10) };
		///     PPE.SetRectArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if rect array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetRectArray(string key, Rect[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.rectHelper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of Rect to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<Rect> list = new List<Rect> { new Rect(0, 0, 1, 10), new Rect(0, 0, 1, 10) };
		///     PPE.SetRectList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if rect list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetRectList(string key, List<Rect> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.rectHelper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of Rect from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetRectArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The rect array.</returns>
		/// <param name="key">Key.</param>
		public static Rect[] GetRectArray(string key)
		{
			return PPEHelper.Instance.rectHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of Rect from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetRectList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The rect list.</returns>
		/// <param name="key">Key.</param>
		public static List<Rect> GetRectList(string key)
		{
			return PPEHelper.Instance.rectHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of Rect from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetRectArray("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The rect array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Rect value.</param>
		/// <param name="defaultSize">2</param>
		public static Rect[] GetRectArray(string key, Rect defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.rectHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of Rect from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetRectList("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The rect list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Rect value.</param>
		/// <param name="defaultSize">2</param>
		public static List<Rect> GetRectList(string key, Rect defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.rectHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region Color
		/// <summary>
		/// Call this function to save a Color to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetColor("abc", new Color(0, 0, 1, 0.5f));
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if color was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetColor(string key, Color value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.colorHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a Color from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetColor("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The color.</returns>
		/// <param name="key">Key.</param>
        /// <param name="defaultValue">Color(r:0.0f g:0.0f b:0.0f a:0.0f)</param>
		public static Color GetColor(string key, Color defaultValue = default(Color))
		{
			return PPEHelper.Instance.colorHelper.Get(key, defaultValue);
		}
		#endregion

		#region Color[]
		/// <summary>
		/// Call this function to save array of Color to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	Color[] array = { new Color(0, 0, 1, 1), new Color(0, 0, 1, 1) };
		///     PPE.SetColorArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if color array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetColorArray(string key, Color[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.colorHelper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of Color to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<Color> list = new List<Color> { new Color(0, 0, 1, 1), new Color(0, 0, 1, 1) };
		///     PPE.SetColorList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if color list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetColorList(string key, List<Color> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.colorHelper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of Color from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetColorArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The color array.</returns>
		/// <param name="key">Key.</param>
		public static Color[] GetColorArray(string key)
		{
			return PPEHelper.Instance.colorHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of Color from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetColorList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The color list.</returns>
		/// <param name="key">Key.</param>
		public static List<Color> GetColorList(string key)
		{
			return PPEHelper.Instance.colorHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of Color from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetColorArray("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The color array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Color value.</param>
		/// <param name="defaultSize">2</param>
		public static Color[] GetColorArray(string key, Color defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.colorHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of Color from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetColorList("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The color list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default Color value.</param>
		/// <param name="defaultSize">2</param>
		public static List<Color> GetColorList(string key, Color defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.colorHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region DateTime
		/// <summary>
		/// Call this function to save a DateTime to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetDateTime("abc", DateTime.Now);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if date time was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetDateTime(string key, DateTime value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.dateTimeHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a DateTime from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetDateTime("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The date time.</returns>
		/// <param name="key">Key.</param>
        /// <param name="defaultValue">DateTime(1/1/0001 12:00:00 AM)</param>
		public static DateTime GetDateTime(string key, DateTime defaultValue = default(DateTime))
		{
			return PPEHelper.Instance.dateTimeHelper.Get(key, defaultValue);
		}
		#endregion

		#region DateTime[]
		/// <summary>
		/// Call this function to save array of DateTime to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	DateTime[] array = { DateTime.Now, DateTime.Now };
		///     PPE.SetDateTimeArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if date time array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="array">Array.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetDateTimeArray(string key, DateTime[] array, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.dateTimeHelper.SetArray(key, array, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of DateTime to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<DateTime> list = new List<DateTime> { DateTime.Now, DateTime.Now };
		///     PPE.SetDateTimeList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if date time list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="list">List.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetDateTimeList(string key, List<DateTime> list, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.dateTimeHelper.SetList(key, list, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of DateTime from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetDateTimeArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The date time array.</returns>
		/// <param name="key">Key.</param>
		public static DateTime[] GetDateTimeArray(string key)
		{
			return PPEHelper.Instance.dateTimeHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of DateTime from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetDateTimeList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The date time list.</returns>
		/// <param name="key">Key.</param>
		public static List<DateTime> GetDateTimeList(string key)
		{
			return PPEHelper.Instance.dateTimeHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of DateTime from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetDateTimeArray("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The double array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default DateTime value.</param>
		/// <param name="defaultSize">2</param>
		public static DateTime[] GetDateTimeArray(string key, DateTime defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.dateTimeHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of DateTime from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetDateTimeList("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The double list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default DateTime value.</param>
		/// <param name="defaultSize">2</param>
		public static List<DateTime> GetDateTimeList(string key, DateTime defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.dateTimeHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region string
		/// <summary>
		/// Call this function to save a string to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetString("abc", "bla bla");
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if string was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetString(string key, string value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.stringHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a string from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetString("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The string.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">null</param>
        public static string GetString(string key, string defaultValue = default(string))
		{
			return PPEHelper.Instance.stringHelper.Get(key, defaultValue);
		}
		#endregion

		#region string[]
		/// <summary>
		/// Call this function to save array of string to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	string[] array = { "a", "b" };
		///     PPE.SetStringArray("abc", array);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if string array was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetStringArray(string key, string[] value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.stringHelper.SetArray(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to save list of string to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		/// 	List<string> list = new List<string> { "a", "b", "c" };
		///     PPE.SetStringList("abc", list);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if string list was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetStringList(string key, List<string> value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.stringHelper.SetList(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load array of string from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetStringArray("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The string array.</returns>
		/// <param name="key">Key.</param>
		public static string[] GetStringArray(string key)
		{
			return PPEHelper.Instance.stringHelper.GetArray(key);
		}

		/// <summary>
		/// Call this function to load list of string from Player Prefs.
		/// </summary>
		/// <example>
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetStringList("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The string list.</returns>
		/// <param name="key">Key.</param>
		public static List<string> GetStringList(string key)
		{
			return PPEHelper.Instance.stringHelper.GetList(key);
		}

		/// <summary>
		/// Call this function to load array of string from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var array = PPE.GetStringArray("abc", 1, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The string array.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default string value.</param>
		/// <param name="defaultSize">2</param>
		public static string[] GetStringArray(string key, string defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.stringHelper.GetArray(key, defaultValue, defaultSize);
		}

		/// <summary>
		/// Call this function to load list of string from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var list = PPE.GetStringList("abc", 2, 3);
		/// }
		/// </code>
		/// </example>
		/// <returns>The string list.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">Default string value.</param>
		/// <param name="defaultSize">2</param>
		public static List<string> GetStringList(string key, string defaultValue, int defaultSize = 2)
		{
			return PPEHelper.Instance.stringHelper.GetList(key, defaultValue, defaultSize);
		}
		#endregion

		#region Texture2D
		/// <summary>
		/// Call this function to save a Texture2D to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     PPE.SetTexture2D("abc", GUI.skin.box.normal.background);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if Texture2D was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetTexture2D(string key, Texture2D value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.texture2DHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load a Texture2D from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetTexture2D("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The Texture2D.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">null</param>
		public static Texture2D GetTexture2D(string key, Texture2D defaultValue = default(Texture2D))
		{
			return PPEHelper.Instance.texture2DHelper.Get(key, defaultValue);
		}
		#endregion

		#region object
		/// <summary>
		/// Call this function to save an object to Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// [Serializable]
		/// public class Foo
		/// {
		/// 	public int a;
		/// }
		/// 
		/// // ...
		/// 
		/// void Start()
		/// {
		/// 	var foo = new Foo();
		///     PPE.SetObject("abc", foo);
		/// }
		/// </code>
		/// </example>
		/// <returns><c>true</c>, if object was set, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <param name="isNeedCrypto">Whether to use encryption or not. Default is false. Can be left away on that case.</param>
		public static bool SetObject(string key, object value, bool isNeedCrypto = false)
		{
			return PPEHelper.Instance.objectHelper.Set(key, value, isNeedCrypto);
		}

		/// <summary>
		/// Call this function to load an object from Player Prefs.
		/// </summary>
		/// <example> 
		/// <code>
		/// void Start()
		/// {
		///     var a = PPE.GetObject("abc");
		/// }
		/// </code>
		/// </example>
		/// <returns>The object.</returns>
		/// <param name="key">Key.</param>
		/// <param name="defaultValue">null</param>
		public static object GetObject(string key, object defaultValue = null)
		{
			return PPEHelper.Instance.objectHelper.Get(key, defaultValue);
		}
		#endregion
	}
}
