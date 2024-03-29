﻿using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenAuthorization.Utils
{
    public class MemoryCacheHelper
    {
        public static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.TryGetValue(key, out _);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (!Exists(key))
                throw new ArgumentNullException(nameof(key));
            return _cache.Get(key);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public static bool AddMemoryCache(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _cache.Set(key, value,
            new MemoryCacheEntryOptions()
            {
                SlidingExpiration = new TimeSpan(0, 0, 10),
                Priority = CacheItemPriority.NeverRemove,
                AbsoluteExpiration = DateTime.Now.AddMinutes(1)
            });
            return Exists(key);
        }
    }

}
