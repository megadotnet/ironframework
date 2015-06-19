using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataTransferObject.Model
{
    /// <summary>
    /// EasyuiDatagridData
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <example>
    /// <code>
    ///         
    /// $(tabName).datagrid({
    ///    url: StaticSearchUrl,
    ///    title: '发失败记录',
    ///    iconCls: 'icon-view',
    ///    method: 'post',
    ///    columns: [[
    ///         { field: 'MSG_FAILED_EVENT_ID', title: 'ID', width: 80, hidden: true, align: 'center' },
    ///         { field: 'SENDER_ACCOUNT', title: '消息发送者账号', width: 100, align: 'center' },
    ///         { field: 'FAILED_CODE', title: '错误编码', width: 100, align: 'center' },
    ///         { field: 'APP_CODE', title: '应用系统标志', width: 100, align: 'center' },
    ///         { field: 'CLIENT_TX_SEQ', title: '客户端唯一标识', width: 100, align: 'center' },
    ///         { field: 'TERMINAL_TYPE', title: '终端设备类型', width: 100, align: 'center' },
    ///         { field: 'TERMINAL_ACCOUNT', title: '终端设备接收的账号', width: 120, align: 'center' },
    ///         { field: 'TERMINAL_COMMAND', title: '终端设备接收的命令', width: 120, align: 'center' },
    ///         { field: 'MSG_TYPE', title: '消息类型', width: 100, align: 'center' },
    ///         { field: 'MSG_SEND_TYPE', title: '发送类型', width: 120, align: 'center' },
    ///         { field: 'RECEIVER_ACCOUNT_TYPE', title: '消息接受者账号类型', width: 120, align: 'center' },
    ///         { field: 'PRIORITY', title: '优先级', width: 100, align: 'center' },
    ///         { field: 'CREATE_TIME', title: '创建时间', width: 140, align: 'center' },
    ///         { field: 'MSG_TITLE', title: '消息标题', width: 100, align: 'center' },
    ///         { field: 'MSG_CONTENT', title: '消息内容', width: 180, align: 'center' }
    ///    ]],
    ///    onLoadError: function (data) {
    ///        onLoadErrorToSSOLogin(data);
    ///    },
    ///    pageSize: 20,
    ///    rownumbers: true,
    ///    singleSelect: true,
    ///    autoRowHeight: false,
    ///    pagination: true,
    ///    loadMsg: '正在努力加载中...',
    ///    striped: true,
    ///    offset: { width: -20, height: -($('#Search').height() + 45) }
    ///});
    ///
    /// JSON Data:
    /// {
    ///  "Rows": [
    ///    {
    ///      "APP_CODE": "SMP",
    ///      "CLIENT_TX_SEQ": "1",
    ///      "EVENT_STATUS": 0,
    ///      "MSG_CONTENT": "CLR\r\n234 23 23 23 23\r\n2323 23 2",
    ///      "MSG_EVENT_ID": 18439,
    ///      "MSG_SEND_START_TIME": "2014-12-18 13:51:55",
    ///      "beginSTART_TIME": null,
    ///      "endSTART_TIME": null,
    ///      "MSG_TITLE": "SITA",
    ///      "MSG_TYPE": "MessagePackage",
    ///      "ORG_CODE": "数据应用中心",
    ///      "PRIORITY": 1,
    ///      "RECEIVER_ACCOUNT": "234234A",
    ///      "RECEIVER_ACCOUNT_TYPE": "REAL_ACCOUNT",
    ///      "SENDER": "liujunyuan",
    ///      "SENDER_ACCOUNT": "KMGUODR",
    ///      "TERMINAL_COMMAND": "Default",
    ///      "TERMINAL_FLAG": "1",
    ///      "TERMINAL_TYPE": "1",
    ///      "PartialViewList": null
    ///    },
    ///    {
    ///      "APP_CODE": "SMP",
    ///      "CLIENT_TX_SEQ": "1",
    ///      "EVENT_STATUS": 0,
    ///      "MSG_CONTENT": "234324",
    ///      "MSG_EVENT_ID": 18438,
    ///      "MSG_SEND_START_TIME": "2014-12-18 13:50:05",
    ///      "beginSTART_TIME": null,
    ///      "endSTART_TIME": null,
    ///      "MSG_TITLE": "SITA",
    ///      "MSG_TYPE": "MessagePackage",
    ///      "ORG_CODE": "数据应用中心",
    ///      "PRIORITY": 1,
    ///      "RECEIVER_ACCOUNT": "234234",
    ///      "RECEIVER_ACCOUNT_TYPE": "REAL_ACCOUNT",
    ///      "SENDER": "liujunyuan",
    ///      "SENDER_ACCOUNT": "ZPPPUODR",
    ///      "TERMINAL_COMMAND": "Default",
    ///      "TERMINAL_FLAG": "1",
    ///      "TERMINAL_TYPE": "1",
    ///      "PartialViewList": null
    ///    }
    ///  ],
    ///  "Total": 18423
    ///}
    /// 
    /// 
    /// </code>
    /// </example>
    public class EasyuiDatagridData<T>
    {
        /// <summary>
        /// Gets or sets the Rows.
        /// </summary>
        /// <value>
        /// The Rows.
        /// </value>
        [JsonProperty("rows")]
        public T[] Rows { get; set; }

        /// <summary>
        /// Gets or sets the Total.
        /// </summary>
        /// <value>
        /// The Total.
        /// </value>
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("page")]
        public int PageIndex { get; set; }
    }
}
