﻿using System;
using System.ComponentModel;
using Elasticsearch.Net;
using Elasticsearch.Net.Connection.Configuration;

namespace Nest
{
	public abstract class BasePathDescriptor<TDescriptor, TParameters> : BaseRequest<TParameters>, IDescriptor
		where TDescriptor : BasePathDescriptor<TDescriptor, TParameters>
		where TParameters : FluentRequestParameters<TParameters>, new()
	{
		protected TDescriptor _requestParams(Action<TParameters> assigner)
		{
			assigner?.Invoke(this.Request.RequestParameters);
			return (TDescriptor)this;
		}

		/// <summary>
		/// Specify settings for this request alone, handy if you need a custom timeout or want to bypass sniffing, retries
		/// </summary>
		public TDescriptor RequestConfiguration(Func<RequestConfigurationDescriptor, IRequestConfiguration> configurationSelector)
		{
			configurationSelector.ThrowIfNull("configurationSelector");
			this.Request.RequestConfiguration = configurationSelector(new RequestConfigurationDescriptor());
			return (TDescriptor)this;
		}
		
		/// <summary>
		/// Hides the <see cref="Equals"/> method.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj) => base.Equals(obj);

		/// <summary>
		/// Hides the <see cref="GetHashCode"/> method.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode() => base.GetHashCode();

		/// <summary>
		/// Hides the <see cref="ToString"/> method.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString() => base.ToString();
		
	}
}