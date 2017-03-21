using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace BIMWebService.Util
{
    /// <summary>
    ///     缓存管理
    /// </summary>
    public static class CacheHelper
    {
        private const int SecondsFactor = 360*60;
        public static readonly int MinuteFactor = 12;
        public static readonly double SecondFactor = 0.2;
        private static readonly Cache Cache;
        private static int _factor = 1;

        /// <summary>
        ///     Static initializer should ensure we only have to look up the current cache
        ///     instance once.
        /// </summary>
        static CacheHelper()
        {
            var context = HttpContext.Current;
            Cache = context != null ? context.Cache : HttpRuntime.Cache;
        }

        public static void ReSetFactor(int cacheFactor)
        {
            _factor = cacheFactor;
        }

        /// <summary>
        ///     清空Cash对象
        /// </summary>
        public static void Clear()
        {
            var cacheEnum = Cache.GetEnumerator();
            var al = new ArrayList();
            while (cacheEnum.MoveNext())
            {
                al.Add(cacheEnum.Key);
            }
            foreach (string key in al)
            {
                Cache.Remove(key);
            }
        }

        /// <summary>
        ///     根据正则表达式的模式移除Cache
        /// </summary>
        /// <param name="pattern">模式</param>
        public static void RemoveByPattern(string pattern)
        {
            var cacheEnum = Cache.GetEnumerator();
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            while (cacheEnum.MoveNext())
            {
                if (regex.IsMatch(cacheEnum.Key.ToString()))
                    Cache.Remove(cacheEnum.Key.ToString());
            }
        }

        /// <summary>
        ///     根据键值移除Cache
        /// </summary>
        /// <param name="key">键</param>
        public static void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        ///     把对象加载到Cache
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">对象</param>
        public static void Insert(string key, object obj)
        {
            Insert(key, obj, null, SecondsFactor);
        }

        /// <summary>
        ///     把对象加载到Cache,附加缓存依赖信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">对象</param>
        /// <param name="dep">缓存依赖</param>
        public static void Insert(string key, object obj, CacheDependency dep)
        {
            Insert(key, obj, dep, MinuteFactor*3);
        }

        /// <summary>
        ///     把对象加载到Cache,附加过期时间信息
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">对象</param>
        /// <param name="seconds">缓存时间(秒)</param>
        public static void Insert(string key, object obj, int seconds)
        {
            Insert(key, obj, null, seconds);
        }

        /// <summary>
        ///     把对象加载到Cache,附加过期时间信息和优先级
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">对象</param>
        /// <param name="seconds">缓存时间(秒)</param>
        /// <param name="priority">优先级</param>
        public static void Insert(string key, object obj, int seconds, CacheItemPriority priority)
        {
            Insert(key, obj, null, seconds, priority);
        }

        /// <summary>
        ///     把对象加载到Cache,附加缓存依赖和过期时间(多少秒后过期)
        ///     (默认优先级为Normal)
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">对象</param>
        /// <param name="dep">缓存依赖</param>
        /// <param name="seconds">缓存时间(秒)</param>
        public static void Insert(string key, object obj, CacheDependency dep, int seconds)
        {
            Insert(key, obj, dep, seconds, CacheItemPriority.Normal);
        }

        /// <summary>
        ///     把对象加载到Cache,附加缓存依赖和过期时间(多少秒后过期)及优先级
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">对象</param>
        /// <param name="dep">缓存依赖</param>
        /// <param name="seconds">缓存时间(秒)</param>
        /// <param name="priority">优先级</param>
        public static void Insert(string key, object obj, CacheDependency dep, int seconds, CacheItemPriority priority)
        {
            if (obj != null)
            {
                Cache.Insert(key, obj, dep, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(seconds), priority,
                    null);
            }
        }

        /// <summary>
        ///     把对象加到缓存并忽略优先级
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">对象</param>
        /// <param name="secondFactor">时间</param>
        public static void MicroInsert(string key, object obj, int secondFactor)
        {
            if (obj != null)
            {
                Cache.Insert(key, obj, null, DateTime.Now.AddSeconds(_factor*secondFactor), TimeSpan.Zero);
            }
        }

        /// <summary>
        ///     把对象加到缓存,并把过期时间设为最大值
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">对象</param>
        public static void Max(string key, object obj)
        {
            Max(key, obj, null);
        }

        /// <summary>
        ///     把对象加到缓存,并把过期时间设为最大值,附加缓存依赖信息
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">对象</param>
        /// <param name="dep">缓存依赖</param>
        public static void Max(string key, object obj, CacheDependency dep)
        {
            if (obj != null)
            {
                Cache.Insert(key, obj, dep, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.AboveNormal, null);
            }
        }

        /// <summary>
        ///     插入持久性缓存
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">对象</param>
        public static void Permanent(string key, object obj)
        {
            Permanent(key, obj, null);
        }

        /// <summary>
        ///     插入持久性缓存,附加缓存依赖
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">对象</param>
        /// <param name="dep">缓存依赖</param>
        public static void Permanent(string key, object obj, CacheDependency dep)
        {
            if (obj != null)
            {
                Cache.Insert(key, obj, dep, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.NotRemovable, null);
            }
        }

        /// <summary>
        ///     根据键获取被缓存的对象
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return Cache[key];
        }

        /// <summary>
        ///     Return int of seconds * SecondFactor
        /// </summary>
        public static int SecondFactorCalculate(int seconds)
        {
            // Insert method below takes integer seconds, so we have to round any fractional values
            return Convert.ToInt32(Math.Round(seconds*SecondFactor));
        }
    }
}