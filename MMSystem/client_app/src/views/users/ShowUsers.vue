<template>
  <div class="h-screen bg-gray-100 overflow-hidden flex">
    <asideComponent></asideComponent>

    <div class="bg-gray-200 h-screen w-full overflow-hidden" dir="rtl">
      <div
        class="min-h-full mx-auto max-w-4xl p-2 flex flex-col mt-4 items-center"
      >
        <div class="flex justify-between w-full">
          <router-link
            :to="{ name: 'Add' }"
            class="
            border border-black
            duration-300
            bg-white
            px-4
            py-2
            rounded-md
            text-gray-900
            font-bold
            hover:bg-green-600 hover:text-white
            focus:outline-none
          "
          >
            إضافة مستخدم جديد +
          </router-link>

          <logout></logout>
        </div>
        <h1 class="font-extrabold text-xl mt-2">عرض المستخدمين</h1>

        <div class="flex mt-6 w-full">
          <div class="ml-2 w-full">
            <label class="font-medium mr-1 text-gray-700"> اسم الإدارة </label>

            <div class="relative">
              <button
                @click="departmentselect = !departmentselect , GetBranchOfDepartment()"
                @keyup.space.prevent
                id="department"
                class="
                text-right
                block
                mt-2
                w-full
                rounded-md
                h-10
                border
                text-sm
                bg-white
                border-gray-300
                hover:shadow-sm
                focus:outline-none focus:border-gray-300
                p-2
              "
              >
              <input
              @click="departmentNameSelected='',departmentIdSelected='',branchdepartmentNameSelected='' "
                          v-model="departmentNameSelected"
                          type="text"
                          class="h-6 w-full"
                          placeholder="إختر الإدارة"
                        />
                <!-- {{ departmentNameSelected }} -->
              </button>

              <div
                v-if="departmentselect"
                class="
                border
                text-sm
                bg-white
                border-gray-300
                p-2
                absolute
                w-full
                z-20
                shadow
                h-24
                overflow-y-scroll
                rounded-b-md
              "
              >
                <button
                  class="block focus:outline-none w-full my-1 text-right"
                  @click="
                    
                    selectdepartment(department.id, department.departmentName);
                    departmentselect = !departmentselect;
                  "
                  v-for="department in filterByTerm1"
                  :key="department.id"
                >
                  {{ department.departmentName }}
                </button>
              </div>
            </div>

            

            <!-- <select class="shadow-sm w-full focus:outline-none rounded-md mt-2 px-2 py-1 " name="mangment_name">
                    <option value="1">التوثيق</option>
                    <option value="2">مكتب</option>

                </select> -->
          </div>

          <div class=" w-full">
            <label class="font-medium mr-1 text-gray-700"> الإدارات الفرعية و الأقسام</label>

            <div class="relative">
              
              <button
                @click="branchdepartmentdelect = !branchdepartmentdelect"
                @keyup.space.prevent
                id="department"
                class="
                
                text-right
                block
                mt-2
                w-full
                rounded-md
                h-10
                border
                text-sm
                bg-white
                border-gray-300
                hover:shadow-sm
                focus:outline-none focus:border-gray-300
                p-2
              "
              
              >
              <input
              @click="branchdepartmentNameSelected='',branchIdSelected=''"
                          v-model="branchdepartmentNameSelected"
                          type="text"
                          class="h-6 w-full"
                          placeholder="إختر الفرع أو القسم"
                        />
                <!-- {{ departmentNameSelected }} -->
              </button>

              <div
                v-if="branchdepartmentdelect"
                class="
                border
                text-sm
                bg-white
                border-gray-300
                
                p-2
                absolute
                w-full
                z-20
                shadow
                h-24
                overflow-y-scroll
                rounded-b-md
              "
              >
              <button v-if="departmentNameSelected != ''"
                    class="block focus:outline-none w-full my-1 text-right"
                    @click="
                      GetUsersOfDepartment()
                      userNameSelected ='';
                      branchdepartmentdelect = !branchdepartmentdelect;
                      branchdepartmentNameSelected='الأمانة الإدارية';
                    "
                  >
                    <!--  <a  class="w-full block " :id="department.id" @click="test(department.id)" > {{ department.departmentName }}</a>-->
                  الأمانة الإدارية 
                  </button>
                <button
                  class="block focus:outline-none w-full my-1 text-right"
                  @click=" 
                    selectbranchdepartment(department.id, department.departmentName);
                    branchdepartmentdelect = !branchdepartmentdelect;
                  "
                  v-for="department in branches"
                  :key="department.id"
                >
                  {{ department.departmentName }}
                </button>
              </div>
            </div>
            

            <!-- <select class="shadow-sm w-full focus:outline-none rounded-md mt-2 px-2 py-1 " name="mangment_name">
                    <option value="1">التوثيق</option>
                    <option value="2">مكتب</option>

                </select> -->
          </div>

          <div class="mr-2 w-full">
            <label for="user_name" class="font-medium mr-1 text-gray-700">
              اسم المستخدم
            </label>

            <input
              class="
              shadow-sm
              w-full
              mt-2
              focus:outline-none
              rounded-md
              px-2
              py-2
            "
              v-model="username"
              type="text"
              id="user_name"
              placeholder="ادخل اسم المستخدم"
            />
          </div>
        </div>

        <div
          v-if="users[0]"
          class="bg-gray-100 mt-3 rounded-md overflow-y-auto max-h-96 w-full"
        >
          <div
            class="
            grid grid-cols-6
            w-full
            border-b
            items-center
            p-1
            sticky
            top-0
            bg-gray-100
          "
          >
            <span class="col-span-2 mx-auto text-lg font-bold"
              >اسم المستخدم</span
            >

            <span class="col-span-2 mx-auto text-lg font-bold">الفرع أو القسم</span>

            


            <span class="col-span-1 mx-auto text-lg font-bold">الحالة</span>

            

            <span> </span>
          </div>

          <div>
            <div
              v-for="user in users"
              :key="user.userId"
              class="grid grid-cols-6 mt-2 border-b pb-4 items-center"
            >
              <router-link
                class="grid grid-cols-5 col-span-5 mt-2 border-b pb-4 items-center"
                :to="{
                  name: 'Add',
                  params: {
                    id: user.userId,
                    departmentName11: departmentNameSelected,
                    branchdepartmentName11:branchdepartmentNameSelected
                  },
                }"
              >
                <span class="col-span-2 mx-auto">{{ user.userName }}</span>

                <span class="col-span-2 mx-auto" v-if="user.department_name">{{
                  user.department_name
                }}</span>
                <span class="col-span-2 mx-auto" v-else>{{
                  branchdepartmentNameSelected
                 
                }}</span>

                <span class="col-span-1 mx-auto" v-if="user.state == true"
                  >مفعل</span
                >
                <span class="col-span-1 mx-auto" v-else>غير مفعل</span>
              </router-link>

              <button
                class="

                hover:text-red-500
                text-black
                p-2
                mx-auto
                rounded-md
              "
                v-if="user.state == true"
                @click="stop_user(user.userId)"
                title="إيقاف المستخدم"
              >
                <svg
                  class="w-8 h-8 inline-block text-center"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z"
                  ></path>
                </svg>
              </button>

              <button
                class="
                hover:text-green-500
                text-black-500
                
                p-2
                mx-auto
                rounded-md
              "
                v-else
                @click="stop_user(user.userId)"
                title="تفعيل المستخدم"
              >
                <svg
                  class="w-8 h-8 inline-block text-center"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M8 11V7a4 4 0 118 0m-4 8v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2z"
                  ></path>
                </svg>
              </button>
            </div>
          </div>
        </div>
        <div v-else class="text-center text-2xl text-red-500 mt-20">
          لا يوجد مستخدمين في هذا القسم
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import asideComponent from "@/components/asideComponent.vue";
import logout from "@/components/logout.vue";

export default {
  watch: {
    departmentIdSelected: function() {
    //  this.GetUsersOfDepartment();
      this.GetBranchOfDepartment()
    },

    branchIdSelected: function() {
      this.GetUsersOfBranchDepartment();
    },

    username: function() {
      this.searchbyname();
    },
  },

  mounted() {
    if (localStorage.getItem("AY_LW") == null || localStorage.getItem("AY_LW") !=29 || localStorage.getItem("chrome")!=17 ) {
      this.$router.push("/");
    }
    // this.$http.mailService
    //   .GetUsersOfDepartmentControl(this.departmentIdSelected)
    //   .then((res) => {
    //     console.log(res.data);
    //     this.users = res.data;
    //   })
    //   .catch((err) => {
    //     console.log(err);
    //   });

    this.GetAllDepartments();
  },

  name: "Show",
  components: {
    asideComponent,
    logout,
  },
  data() {
    return {
      users: [],

      branches: [],
      branchdepartmentdelect: false,
      branchdepartmentNameSelected: "",
      branchIdSelected: "",

      departments: [],
      departmentselect: false,
      departmentNameSelected: " ",
      departmentIdSelected: "",
      username: "",
    };
  },

  computed: {

  filterByTerm1() {
      return this.departments.filter((department) => {
        return department.departmentName.includes(this.departmentNameSelected );
      });
    },

  },
  methods: {
   
  
   GetUsersOfDepartment() {
      // console.log(this.departmentIdSelected)
      
        this.$http.mailService
        .GetUsersOfDepartmentControl(this.departmentIdSelected)
        .then((res) => {
          console.log(res.data);
          this.users = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    GetAllDepartments() {
      this.$http.mailService
        .AllDepartments()
        .then((res) => {
          this.departments = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    GetBranchOfDepartment() {
      // console.log(this.departmentIdSelected)
      this.loading = true;
      this.screenFreeze = true;

      this.$http.mailService
        .GetBranchOfDepartment(this.departmentIdSelected)
        .then((res) => {
          this.loading = false;
          this.screenFreeze = false;
          this.branches = res.data;
        })
        .catch((err) => {
          this.branches=[];
          this.loading = false;
          this.screenFreeze = false;
          console.log(err);
        });
    },

    GetUsersOfBranchDepartment() {
      // console.log(this.departmentIdSelected)
      this.loading = true;
      this.screenFreeze = true;

      this.$http.mailService
        .GetUsersOfBranchDepartment(this.branchIdSelected)
        .then((res) => {
          this.loading = false;
          this.screenFreeze = false;
          this.users = res.data;
        })
        .catch((err) => {
          console.log(err);
          this.loading = false;
          this.screenFreeze = false;
        });
    },

    selectdepartment(id, name) {
      this.departmentNameSelected = name;
      this.departmentIdSelected = id;
    },
    
    selectbranchdepartment(id, name) {
      this.branchdepartmentNameSelected = name;
      this.branchIdSelected = id;
    },

    stop_user(id) {
      var StopActive = {
        UserId: id,
        currentUser: Number(localStorage.getItem("AY_LW")),
      };

      this.$http.usersService
        .StopUser(StopActive)
        .then((res) => {
          setTimeout(() => {
            console.log(res);
            this.GetUsersOfDepartment(this.departmentIdSelected);
            // this.documentSection = true;
            
            // this.proceduresSection = true;
          }, 500);
        })
        .catch(() => {
          setTimeout(() => {}, 500);
        });
    },

    searchbyname() {
      this.$http.usersService
        .GetUsersByName(this.username)
        .then((res) => {
          console.log(res.data);
          this.users = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>

<style></style>
