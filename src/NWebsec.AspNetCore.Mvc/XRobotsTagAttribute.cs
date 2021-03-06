﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Mvc.Filters;
using NWebsec.AspNetCore.Core.HttpHeaders.Configuration;
using NWebsec.AspNetCore.Mvc.Helpers;
using NWebsec.AspNetCore.Mvc.Internals;

namespace NWebsec.AspNetCore.Mvc
{

    /// <summary>
    /// Specifies whether the X-Robots-Tag header should be set in the HTTP response.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class XRobotsTagAttribute : HttpHeaderAttributeBase
    {
        private readonly XRobotsTagConfiguration _config;
        private readonly HeaderConfigurationOverrideHelper _headerConfigurationOverrideHelper;
        private readonly HeaderOverrideHelper _headerOverrideHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="XRobotsTagAttribute"/> class
        /// </summary>
        public XRobotsTagAttribute()
        {
            _config = new XRobotsTagConfiguration { Enabled = true };
            _headerConfigurationOverrideHelper = new HeaderConfigurationOverrideHelper();
            _headerOverrideHelper = new HeaderOverrideHelper();
        }

        /// <summary>
        /// Gets or sets whether the X-Robots-Tag header should be set in the HTTP response. The default is true.
        /// </summary>
        public bool Enabled { get { return _config.Enabled; } set { _config.Enabled = value; } }

        /// <summary>
        /// Gets of sets whether search engines are instructed to not index the page. The default is false.
        /// </summary>
        public bool NoIndex { get { return _config.NoIndex; } set { _config.NoIndex = value; } }

        /// <summary>
        /// Gets of sets whether search engines are instructed to not follow links on the page. The default is false.
        /// </summary>
        public bool NoFollow { get { return _config.NoFollow; } set { _config.NoFollow = value; } }

        /// <summary>
        /// Gets of sets whether search engines are instructed to not display a snippet for the page in search results. The default is false.
        /// </summary>
        public bool NoSnippet { get { return _config.NoSnippet; } set { _config.NoSnippet = value; } }

        /// <summary>
        /// Gets of sets whether search engines are instructed to not offer a cached version of the page in search results. The default is false.
        /// </summary>
        public bool NoArchive { get { return _config.NoArchive; } set { _config.NoArchive = value; } }

        /// <summary>
        /// Gets of sets whether search engines are instructed to not use information from the Open Directory Project for the page's title or snippet. The default is false.
        /// </summary>
        public bool NoOdp { get { return _config.NoOdp; } set { _config.NoOdp = value; } }

        /// <summary>
        /// Gets of sets whether search engines are instructed to not offer translation of the page in search results (Google only). The default is false.
        /// </summary>
        public bool NoTranslate { get { return _config.NoTranslate; } set { _config.NoTranslate = value; } }

        /// <summary>
        ///  Gets of sets whether search engines are instructed to not index images on the page (Google only). The default is false.
        /// </summary>
        public bool NoImageIndex { get { return _config.NoImageIndex; } set { _config.NoImageIndex = value; } }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _headerConfigurationOverrideHelper.SetXRobotsTagHeaderOverride(filterContext.HttpContext, _config);
            base.OnActionExecuting(filterContext);
        }

        public override void SetHttpHeadersOnActionExecuted(ActionExecutedContext filterContext)
        {
            _headerOverrideHelper.SetXRobotsTagHeader(filterContext.HttpContext);
        }
    }
}
