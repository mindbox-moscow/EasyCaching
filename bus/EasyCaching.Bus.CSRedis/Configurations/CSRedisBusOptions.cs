﻿namespace EasyCaching.Bus.CSRedis
{
    using EasyCaching.Core.Bus;
    using EasyCaching.Core.Decoration;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Redis bus options.
    /// </summary>
    public class CSRedisBusOptions : IBusOptions
    {
        /// <summary>
        /// Gets or sets the node rule.
        /// </summary>
        /// <value>The node rule.</value>
        public Func<string, string> NodeRule { get; set; } = null;

        /// <summary>
        /// Gets or sets the connection strings.
        /// </summary>
        /// <value>The connection strings.</value>
        public List<string> ConnectionStrings { get; set; }

        /// <summary>
        /// Gets or sets the sentinels settings.
        /// </summary>
        /// <value>The sentinels settings.</value>
        public List<string> Sentinels { get; set; }

        /// <summary>
        /// Gets or sets the read write setting for sentinel mode.
        /// </summary>
        /// <value>The read write setting.</value>
        public bool ReadOnly { get; set; }

        public BusFactoryDecorator BusFactoryDecorator { get; set; }
        
        public void DecorateWithRetryAndPublishFallback(int retryCount)
        { 
            this.DecorateWithRetry(retryCount).DecorateWithPublishFallback();
        }
    }
}
