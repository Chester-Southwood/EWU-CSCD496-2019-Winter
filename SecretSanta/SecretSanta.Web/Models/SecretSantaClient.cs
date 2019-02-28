﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Web.Models
{
#pragma warning disable

        [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.0.14.0 (NJsonSchema v9.13.18.0 (Newtonsoft.Json v11.0.0.0))")]
        public partial class SecretSantaClient
        {
            private string _baseUrl = "";
            private System.Net.Http.HttpClient _httpClient;
            private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

            public SecretSantaClient(string baseUrl, System.Net.Http.HttpClient httpClient)
            {
                BaseUrl = baseUrl;
                _httpClient = httpClient;
                _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() =>
                {
                    var settings = new Newtonsoft.Json.JsonSerializerSettings();
                    UpdateJsonSerializerSettings(settings);
                    return settings;
                });
            }

            public string BaseUrl
            {
                get { return _baseUrl; }
                set { _baseUrl = value; }
            }

            protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

            partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
            partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
            partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
            partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<GiftViewModel> GetGiftAsync(int? id)
            {
                return GetGiftAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<GiftViewModel> GetGiftAsync(int? id, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Gifts?");
                if (id != null)
                {
                    urlBuilder_.Append("id=").Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(GiftViewModel);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<GiftViewModel>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ == "404")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Not Found", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<GiftViewModel> CreateGiftAsync(GiftInputViewModel viewModel)
            {
                return CreateGiftAsync(viewModel, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<GiftViewModel> CreateGiftAsync(GiftInputViewModel viewModel, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Gifts");

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(viewModel, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "201")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(GiftViewModel);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<GiftViewModel>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ == "400")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Bad Request", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<GiftViewModel>> GetGiftsForUserAsync(int userId)
            {
                return GetGiftsForUserAsync(userId, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<GiftViewModel>> GetGiftsForUserAsync(int userId, System.Threading.CancellationToken cancellationToken)
            {
                if (userId == null)
                    throw new System.ArgumentNullException("userId");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Gifts/user/{userId}");
                urlBuilder_.Replace("{userId}", System.Uri.EscapeDataString(ConvertToString(userId, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.Generic.ICollection<GiftViewModel>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.ICollection<GiftViewModel>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ == "404")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Not Found", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<GroupViewModel>> GetGroupsAsync()
            {
                return GetGroupsAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<GroupViewModel>> GetGroupsAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Groups");

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.Generic.ICollection<GroupViewModel>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.ICollection<GroupViewModel>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.Generic.ICollection<GroupViewModel>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task UpdateGroupAsync(int? id, GroupInputViewModel viewModel)
            {
                return UpdateGroupAsync(id, viewModel, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task UpdateGroupAsync(int? id, GroupInputViewModel viewModel, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Groups?");
                if (id != null)
                {
                    urlBuilder_.Append("id=").Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(viewModel, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "404")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Not Found", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            if (status_ == "400")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Bad Request", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            if (status_ == "204")
                            {
                                return;
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<GroupViewModel> CreateGroupAsync(GroupInputViewModel viewModel)
            {
                return CreateGroupAsync(viewModel, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<GroupViewModel> CreateGroupAsync(GroupInputViewModel viewModel, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Groups");

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(viewModel, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "201")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(GroupViewModel);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<GroupViewModel>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ == "400")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Bad Request", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<GroupViewModel> GetGroupAsync(int id)
            {
                return GetGroupAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<GroupViewModel> GetGroupAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Groups/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(GroupViewModel);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<GroupViewModel>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ == "404")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Not Found", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task DeleteGroupAsync(int id)
            {
                return DeleteGroupAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task DeleteGroupAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Groups/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "400")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Bad Request", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            if (status_ == "404")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Not Found", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            if (status_ == "200")
                            {
                                return;
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task AddUserToGroupAsync(int groupId, int? userId)
            {
                return AddUserToGroupAsync(groupId, userId, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task AddUserToGroupAsync(int groupId, int? userId, System.Threading.CancellationToken cancellationToken)
            {
                if (groupId == null)
                    throw new System.ArgumentNullException("groupId");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/GroupUsers/{groupId}?");
                urlBuilder_.Replace("{groupId}", System.Uri.EscapeDataString(ConvertToString(groupId, System.Globalization.CultureInfo.InvariantCulture)));
                if (userId != null)
                {
                    urlBuilder_.Append("userId=").Append(System.Uri.EscapeDataString(ConvertToString(userId, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                        request_.Method = new System.Net.Http.HttpMethod("PUT");

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                return;
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task RemoveUserFromGroupAsync(int groupId, int? userId)
            {
                return RemoveUserFromGroupAsync(groupId, userId, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task RemoveUserFromGroupAsync(int groupId, int? userId, System.Threading.CancellationToken cancellationToken)
            {
                if (groupId == null)
                    throw new System.ArgumentNullException("groupId");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/GroupUsers/{groupId}?");
                urlBuilder_.Replace("{groupId}", System.Uri.EscapeDataString(ConvertToString(groupId, System.Globalization.CultureInfo.InvariantCulture)));
                if (userId != null)
                {
                    urlBuilder_.Append("userId=").Append(System.Uri.EscapeDataString(ConvertToString(userId, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                return;
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<UserViewModel>> GetAllUsersAsync()
            {
                return GetAllUsersAsync(System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<UserViewModel>> GetAllUsersAsync(System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Users");

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(System.Collections.Generic.ICollection<UserViewModel>);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.ICollection<UserViewModel>>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ != "200" && status_ != "204")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                            }

                            return default(System.Collections.Generic.ICollection<UserViewModel>);
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task UpdateUserAsync(int? id, UserInputViewModel viewModel)
            {
                return UpdateUserAsync(id, viewModel, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task UpdateUserAsync(int? id, UserInputViewModel viewModel, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Users?");
                if (id != null)
                {
                    urlBuilder_.Append("id=").Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(viewModel, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("PUT");

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "404")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Not Found", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            if (status_ == "400")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Bad Request", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            if (status_ == "204")
                            {
                                return;
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<UserViewModel> CreateUserAsync(UserInputViewModel viewModel)
            {
                return CreateUserAsync(viewModel, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<UserViewModel> CreateUserAsync(UserInputViewModel viewModel, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Users");

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(viewModel, _settings.Value));
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "201")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(UserViewModel);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<UserViewModel>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ == "400")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Bad Request", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task<UserViewModel> GetUserAsync(int id)
            {
                return GetUserAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task<UserViewModel> GetUserAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Users/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "200")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(UserViewModel);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<UserViewModel>(responseData_, _settings.Value);
                                    return result_;
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                            }
                            else
                            if (status_ == "404")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Not Found", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            public System.Threading.Tasks.Task DeleteUserAsync(int id)
            {
                return DeleteUserAsync(id, System.Threading.CancellationToken.None);
            }

            /// <returns>Success</returns>
            /// <exception cref="SwaggerException">A server side error occurred.</exception>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            public async System.Threading.Tasks.Task DeleteUserAsync(int id, System.Threading.CancellationToken cancellationToken)
            {
                if (id == null)
                    throw new System.ArgumentNullException("id");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Users/{id}");
                urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

                var client_ = _httpClient;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("DELETE");

                        PrepareRequest(client_, request_, urlBuilder_);
                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = ((int)response_.StatusCode).ToString();
                            if (status_ == "400")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Bad Request", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            if (status_ == "404")
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("Not Found", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                            else
                            if (status_ == "200")
                            {
                                return;
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result_ = default(ProblemDetails);
                                try
                                {
                                    result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                                }
                                catch (System.Exception exception_)
                                {
                                    throw new SwaggerException("Could not deserialize the response body.", (int)response_.StatusCode, responseData_, headers_, exception_);
                                }
                                throw new SwaggerException<ProblemDetails>("A server side error occurred.", (int)response_.StatusCode, responseData_, headers_, result_, null);
                            }
                        }
                        finally
                        {
                            if (response_ != null)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                }
            }

            private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
            {
                if (value is System.Enum)
                {
                    string name = System.Enum.GetName(value.GetType(), value);
                    if (name != null)
                    {
                        var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                        if (field != null)
                        {
                            var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                                as System.Runtime.Serialization.EnumMemberAttribute;
                            if (attribute != null)
                            {
                                return attribute.Value;
                            }
                        }
                    }
                }
                else if (value is bool)
                {
                    return System.Convert.ToString(value, cultureInfo).ToLowerInvariant();
                }
                else if (value is byte[])
                {
                    return System.Convert.ToBase64String((byte[])value);
                }
                else if (value != null && value.GetType().IsArray)
                {
                    var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                    return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
                }

                return System.Convert.ToString(value, cultureInfo);
            }
        }



        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.18.0 (Newtonsoft.Json v11.0.0.0)")]
        public partial class GiftViewModel
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Title { get; set; }

            [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Description { get; set; }

            [Newtonsoft.Json.JsonProperty("orderOfImportance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? OrderOfImportance { get; set; }

            [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Url { get; set; }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static GiftViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<GiftViewModel>(data);
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.18.0 (Newtonsoft.Json v11.0.0.0)")]
        public partial class ProblemDetails
        {
            [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Type { get; set; }

            [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Title { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Status { get; set; }

            [Newtonsoft.Json.JsonProperty("detail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Detail { get; set; }

            [Newtonsoft.Json.JsonProperty("instance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Instance { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties; }
                set { _additionalProperties = value; }
            }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static ProblemDetails FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(data);
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.18.0 (Newtonsoft.Json v11.0.0.0)")]
        public partial class GiftInputViewModel
        {
            [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
            public string Title { get; set; }

            [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Description { get; set; }

            [Newtonsoft.Json.JsonProperty("orderOfImportance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? OrderOfImportance { get; set; }

            [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Url { get; set; }

            [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? UserId { get; set; }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static GiftInputViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<GiftInputViewModel>(data);
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.18.0 (Newtonsoft.Json v11.0.0.0)")]
        public partial class GroupViewModel
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("groupUsers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<GroupUserViewModel> GroupUsers { get; set; }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static GroupViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<GroupViewModel>(data);
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.18.0 (Newtonsoft.Json v11.0.0.0)")]
        public partial class GroupUserViewModel
        {
            [Newtonsoft.Json.JsonProperty("groupId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? GroupId { get; set; }

            [Newtonsoft.Json.JsonProperty("group", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public GroupViewModel Group { get; set; }

            [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? UserId { get; set; }

            [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public UserViewModel User { get; set; }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static GroupUserViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<GroupUserViewModel>(data);
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.18.0 (Newtonsoft.Json v11.0.0.0)")]
        public partial class UserViewModel
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FirstName { get; set; }

            [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LastName { get; set; }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static UserViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserViewModel>(data);
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.18.0 (Newtonsoft.Json v11.0.0.0)")]
        public partial class GroupInputViewModel
        {
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static GroupInputViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<GroupInputViewModel>(data);
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.18.0 (Newtonsoft.Json v11.0.0.0)")]
        public partial class UserInputViewModel
        {
            [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
            public string FirstName { get; set; }

            [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LastName { get; set; }

            public string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            public static UserInputViewModel FromJson(string data)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserInputViewModel>(data);
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.0.14.0 (NJsonSchema v9.13.18.0 (Newtonsoft.Json v11.0.0.0))")]
        public partial class SwaggerException : System.Exception
        {
            public int StatusCode { get; private set; }

            public string Response { get; private set; }

            public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

            public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
                : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
            {
                StatusCode = statusCode;
                Response = response;
                Headers = headers;
            }

            public override string ToString()
            {
                return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.0.14.0 (NJsonSchema v9.13.18.0 (Newtonsoft.Json v11.0.0.0))")]
        public partial class SwaggerException<TResult> : SwaggerException
        {
            public TResult Result { get; private set; }

            public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
                : base(message, statusCode, response, headers, innerException)
            {
                Result = result;
            }
        }

#pragma warning restore


}
