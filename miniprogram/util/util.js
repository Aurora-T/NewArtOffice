const formatTime=date=>{
  const year = date.getFullYear()
  const month = date.getMonth() + 1
  const day=date.getDate()
  const hour = date.getHours()
  const minute = date.getMinutes()
  const second = date.getSeconds()
  return [year,month,day].map(formatNumber).join('-')+' '+[hour,minute,second].map(formatNumber).join(':')
}
const formatNumber=n=>{
  n=n.toString()
  return n[1]?n:'0'+n
}
//控制刷新时重新获取数据
function http(name,callBack)
{
  const db = wx.cloud.database()
  // 查询当前用户所有的 counters
  db.collection(name).get({
    success: res => {
      if (res.data.length != 0)
       callBack(res.data)
      console.log('[数据库] [查询记录] 成功: ', res)
    },
    fail: err => {
      wx.showToast({
        icon: 'none',
        title: '查询记录失败'
      })
      console.error('[数据库] [查询记录] 失败：', err)
    }
  })
}

module.exports = {
  formatTime:formatTime,
  http:http
}
