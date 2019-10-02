<template>
  <div class="timetable">
    <gantt-elastic
      :options="options"
      :tasks="tasks"
      @tasks-changed="tasksUpdate"
      @options-changed="optionsUpdate"
      @dynamic-style-changed="styleUpdate"
    >
      <gantt-header slot="header"></gantt-header>
    </gantt-elastic>
    <div class="q-mt-md" />
    <!--<q-btn @click="addTask" icon="mdi-plus" label="Add task" />-->
  </div>
</template>

<style>
</style>

<script>
import GanttElastic from "gantt-elastic";
import GanttHeader from "gantt-elastic-header";
import dayjs from "dayjs";

// just helper to get current dates
function getDate(hours) {
  const currentDate = new Date();
  const currentYear = currentDate.getFullYear();
  const currentMonth = currentDate.getMonth();
  const currentDay = currentDate.getDate();
  const timeStamp = new Date(
    currentYear,
    currentMonth,
    currentDay,
    0,
    0,
    0
  ).getTime();
  return new Date(timeStamp + hours * 60 * 60 * 1000).getTime();
}
let tasks = [
  {
    id: 1,
    description: "test",
    start: getDate(-24 * 5),
    duration: 15 * 24 * 60 * 60 * 1000,
    percent: 85,
    type: "project",
     style: {
      base: {
        fill: "#1EBC61",
        stroke: "#0EAC51"
      }
    }
    //collapsed: true,
  },
  {
    id: 2,
    parentId: 1,
    start: getDate(-24 * 4),
    duration: 4 * 24 * 60 * 60 * 1000,
    percent: 50,
    type: "milestone",
    style: {
      base: {
        fill: "#1EBC61",
        stroke: "#0EAC51"
      }
    }
  },
  {
    id: 3,
    parentId: 1,
    start: getDate(-24 * 3),
    duration: 2 * 24 * 60 * 60 * 1000,
    percent: 100,
    type: "task",
     style: {
      base: {
        fill: "#1EBC61",
        stroke: "#0EAC51"
      }
    }
  },
  {
    id: 4,
    start: getDate(-24 * 2),
    duration: 2 * 24 * 60 * 60 * 1000,
    percent: 50,
    type: "task",
     style: {
      base: {
        fill: "#1EBC61",
        stroke: "#0EAC51"
      }
    }
  }
];
let options = {
  taskMapping: {
    progress: "percent"
  },
  maxRows: 100,
  maxHeight: 500,
  title: {
    label: "InstaTable",
    html: false
  },
  row: {
    height: 24
  },
  calendar: {
    hour: {
      display: true
    }
  },
  chart: {
    progress: {
      bar: true
    },
    expander: {
      display: false
    }
  },
  taskList: {
    expander: {
      straight: false
    },
    columns: [
      {
        id: 1,
        label: "Tafel nr.",
        value: "id",
        width: 60
      },
      {
        id: 2,
        label: "Omschrijving",
        value: "label",
        width: 200,
        // events: {
        //   click({ data, column }) {
        //     alert("description clicked!\n" + data.label);
        //   }
        // }
      },
    //   {
    //     id: 3,
    //     label: "Assigned to",
    //     value: "user",
    //     width: 130,
    //     html: true
    //   },
      {
        id: 3,
        label: "Start",
        value: task => dayjs(task.start).format("YYYY-MM-DD"),
        width: 78
      }
    ]
  },
  locale: {
    'name':'NL',
    'Now': 'Vandaag \'zal',
    'X-Scale': 'Zoom',
    'Y-Scale': 'Tussen ruimte',
    'Task list width': 'Lijst',
    'Before/After': 'Periode',
    'Display task list': 'Lijst',
    'weekStart':1,
    'weekdays': 'Zondag_Maandag_Dinsdag_Woensdag_Donderdag_Vrijdag_Zaterdag'.split('_'),
    'months': 'Januari_Februari_Maart_April_Mei_Juni_Juli_Augustus_September_Oktober_November_December'.split('_'),
    'monthsShort': 'Jan_Febr_Maart_Apr_Mei_Jun_Jul_Aug_Sep_Okt_Nov_Dec'.split('_'),
    'relativeTime': {
      'future': 'in %s',
      'past': 'er is %s',
      's': 'een paar seconden',
      'm': 'een minuut',
      'mm': '%d minuten',
      'h': 'een uur',
      'hh': '%d uren',
      'd': 'een dag',
      'dd': '%d dagen',
      'M': 'een maand',
      'MM': '%d maanden',
      'y': 'een jaar',
      'yy': '%d jaren'
    },
    'ordinal': (n) => {
      const o = n === 1 ? 'er' : ''
      return `${n}${o}`
    }
  }
};

export default {
  name: "Gantt",
  components: {
    GanttElastic,
    GanttHeader
  },
  data() {
    return {
      tasks,
      options,
      dynamicStyle: {},
      lastId: 16
    };
  },
  methods: {
    addTask() {
      
    },
    tasksUpdate(tasks) {
      this.tasks = tasks;
    },
    optionsUpdate(options) {
      this.options = options;
    },
    styleUpdate(style) {
      this.dynamicStyle = style;
    }
  }
};
</script>